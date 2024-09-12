using System.ComponentModel.DataAnnotations;
namespace Task.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }

        public string RoleModel { get; set; }
    }
}
