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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsProfessor { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }

        public Users(int userId, string firstName, string lastName, DateTime dateOfBirth, string gender, string userName, string password, bool isProfessor, ICollection<Grade> grades)
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
        }
    }
}
