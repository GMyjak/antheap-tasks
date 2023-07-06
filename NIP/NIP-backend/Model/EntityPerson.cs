using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIP_backend.Model
{
    public class EntityPerson
    {
        [Key]
        public int Id { get; set; }

        public string? CompanyName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [MinLength(11), MaxLength(11)]
        public string? Pesel { get; set; }
        [MinLength(10), MaxLength(10)]
        public string? Nip { get; set; }

        public int? EntityAsRepresentativeId { get; set; }
        public Entity? EntityAsRepresentative { get; set; }

        public int? EntityAsClerkId { get; set; }
        public Entity? EntityAsClerk { get; set; }

        public int? EntityAsPartnerId { get; set; }
        public Entity? EntityAsPartner { get; set; }
    }
}
