using System.ComponentModel.DataAnnotations;

namespace PIS.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }

    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rol seçiniz.")]
        public string Role { get; set; } = "user";
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }

    public class UserListItem
    {
        public string Id { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string Roles { get; set; } = string.Empty;
    }
}
