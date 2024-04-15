using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Systems.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsProfessor { get; set; }
        public virtual ICollection<Grade> Grades { get; set; } = null!;

        public virtual ICollection<Notification> Notifications { get; set; } = null!;

        public Users(int userId, string firstName, string lastName, DateTime dateOfBirth, string gender, string userName, string password, bool isProfessor, ICollection<Grade> grades, ICollection<Notification> notifications)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            UserName = userName;
            Password = password;
            IsProfessor = isProfessor;
            Grades = grades;
            Notifications = notifications;
        }

        public Users()
        {
        }
    }
}
