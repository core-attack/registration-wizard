namespace RegistrationWizard.Dal.DbContext.DbModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Dal.DbContext.DbModels;

    public class CountryDb : BaseEntityDb
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<ProvinceDb> Provinces { get; set; }
    }
}
