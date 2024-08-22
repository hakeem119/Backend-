using System.ComponentModel.DataAnnotations;

namespace ToDoMyApp.ViewModels
{
    public class SignInVM
    {
        [Required]
        public string UsernameOrEmail
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
  
    }

    public class RegisterVM
    {
        [Required]
        public string Username
        {
            get;
            set;
        }
        [Required]
        public string Email
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
        [Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }

    public class CreateToDoItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class UpdateToDoItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
    public class CreateTagModel
    {
        public string Name { get; internal set; }
    }
    public class UpdateTagModel
    {
        public string Name { get; internal set; }
    }
}
