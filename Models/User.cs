﻿namespace Task.API.Models
{
    public class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
            Tasks = new HashSet<TaskModel>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Ts { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
