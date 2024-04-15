using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Systems.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; } 
        public string Message { get; set; } = null!;
        public DateTime Date { get; set; }

        public Users Sender { get; set; } = null!;

        public Notification(int notificationId, int userId, string message, DateTime date)
        {
            NotificationId = notificationId;
            UserId = userId;
            Message = message;
            Date = date;
        }
        public Notification()
        {
        }
    }
}
