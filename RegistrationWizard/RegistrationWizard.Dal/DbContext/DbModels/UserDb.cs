namespace RegistrationWizard.Dal.DbContext.DbModels
{
    using System.ComponentModel.DataAnnotations;
    using Core.Dal.DbContext.DbModels;

    public class UserDb : BaseEntityDb
    {
        [MaxLength(255)]
        [EmailAddress]
        [Required]
        public string Login { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        public long ProvinceId { get; set; }

        public bool IsAgreeToWorkForFood { get; set; }

        public ProvinceDb Province { get; set; }
    }
}
