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
        public string Score { get; set; }
        public string Course { get; set; }
        public Users User { get; set; }

        public Grade(int gradeId, int userId, string score, string course, Users user)
        {
            GradeId = gradeId;
            UserId = userId;
            Score = score;
            Course = course;
            User = user;
        }
    }
}
