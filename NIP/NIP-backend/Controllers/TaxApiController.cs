using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NIP_backend.Config;
using NIP_backend.DbContext;
using NIP_backend.Dto;
using NIP_backend.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace NIP_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxApiController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly TaxApiConfig taxApiConfig;
        private readonly NipDatabaseContext dbContext;
        private readonly IMapper mapper;

        private static HttpClient httpClient;

        public TaxApiController(IConfiguration configuration, TaxApiConfig taxApiConfig, NipDatabaseContext dbContext, IMapper mapper)
        {
            this.configuration = configuration;
            this.taxApiConfig = taxApiConfig;
            this.dbContext = dbContext;
            this.mapper = mapper;

            if (httpClient == null)
            {
                httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(configuration.GetConnectionString("TaxApiBase"))
                };
            }
        }

        [HttpGet("Nip/{nip}")]
        public async Task<ActionResult<EntityDto>> GetNipData([FromRoute, RegularExpression(@"^\d{10}$")]string nip)
        {
            var dbEntity = dbContext.Entities
                .Include(e => e.Representatives)
                .Include(e => e.AuthorizedClerks)
                .Include(e => e.Partners)
                .FirstOrDefault(e => e.Nip == nip);

            if (dbEntity == null)
            {
                var result = await GetEntityFromApi(nip);
                
                if (result?.Value?.Nip != null)
                {
                    await SaveEntityInDatabase(result.Value);
                }

                return result;
            }
            else
            {
                return mapper.Map<EntityDto>(dbEntity);
            }
        }

        private async Task<ActionResult<EntityDto>> GetEntityFromApi(string nip)
        {
            var queryBuilder = new QueryBuilder();
            var date = DateTime.Now;
            queryBuilder.Add("date", date.ToString(taxApiConfig.DateFormat));

            var finalEndpoint = string.Format(taxApiConfig.NipEndpoint, nip) + queryBuilder.ToString();

            using (var response = await httpClient.GetAsync(finalEndpoint))
            {
                if (!response.IsSuccessStatusCode)
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    var errorDto = JsonSerializer.Deserialize<ErrorDto>(errorJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return NotFound(errorDto);
                }

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<EntityResponseDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return dto.Result.Subject;
            }
        }

        private async Task SaveEntityInDatabase(EntityDto dto)
        {
            var entity = mapper.Map<Entity>(dto);

            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
