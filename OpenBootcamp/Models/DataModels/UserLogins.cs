using Microsoft.Build.Framework;

namespace OpenBootcamp.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Rol rol { get; set; }
    }
}
