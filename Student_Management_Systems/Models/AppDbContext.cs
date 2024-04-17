using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Student_Management_Systems.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AppDbContext 
{
    public DbSet<Users> users { get; set; }
    public DbSet<Grade> grade { get; set; }
    public DbSet<Notification> notification { get; set; }


    MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=student_management_system");
    MySqlCommand cmd;

    public void insertData(string query)
    {
        con.Open();


        cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;

        cmd.ExecuteNonQuery();


        con.Close();

    }
}