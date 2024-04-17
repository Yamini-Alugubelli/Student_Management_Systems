using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Systems.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int UserId { get; set; }
        public string Score { get; set; } = null!;
        public string Instructor { get; set; } = null!;
        public string Course { get; set; } = null!;
        public Users User { get; set; } = null!;

        public Grade(int gradeId, int userId, string score, string Instructor, string course, Users user)
        {
            GradeId = gradeId;
            UserId = userId;
            Score = score;
            Instructor = Instructor;
            Course = course;
            User = user;
        }

        public Grade()
        {
        }
    }
}
