using NIP_backend.Dto;
using System.ComponentModel.DataAnnotations;

namespace NIP_backend.Model
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [MinLength(10), MaxLength(10)]
        public string? Nip { get; set; }
        public string? StatusVat { get; set; }
        public string? Regon { get; set; }
        [MinLength(11), MaxLength(11)]
        public string? Pesel { get; set; }
        public string? Krs { get; set; }
        [MaxLength(200)]
        public string? ResidenceAddress { get; set; }
        [MaxLength(200)]
        public string? WorkingAddress { get; set; }

        public ICollection<EntityPerson> Representatives { get; set; }
        public ICollection<EntityPerson> AuthorizedClerks { get; set; }
        public ICollection<EntityPerson> Partners { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RegistrationLegalDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RegistrationDenialDate { get; set; }
        [MaxLength(200)]
        public string? RegistrationDenialBasis { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RestorationDate { get; set; }
        [MaxLength(200)]
        public string? RestorationBasis { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RemovalDate { get; set; }
        [MaxLength(200)]
        public string? RemovalBasis { get; set; }

        public ICollection<string> AccountNumbers { get; set; }
        public bool HasVirtualAccounts { get; set; }
    }
}
