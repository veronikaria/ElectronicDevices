
namespace ElectronicDevices.Models
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; } = "https://localhost:44348/images/icons/user_icon.png";
    }
}
