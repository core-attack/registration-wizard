namespace RegistrationWizard.Dal.DbContext.DbModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Dal.DbContext.DbModels;

    public class ProvinceDb : BaseEntityDb
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public long CountryId { get; set; }

        public CountryDb Country { get; set; }

        public ICollection<UserDb> Users { get; set; }
    }
}
