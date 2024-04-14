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
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public Users Sender { get; set; }

        public Notification(int notificationId, int userId, string message, DateTime date, Users sender)
        {
            NotificationId = notificationId;
            UserId = userId;
            Message = message;
            Date = date;
            Sender = sender;
        }
    }
}
