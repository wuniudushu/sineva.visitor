using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}