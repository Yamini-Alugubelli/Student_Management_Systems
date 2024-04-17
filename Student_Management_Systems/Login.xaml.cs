using MySql.Data.MySqlClient;
using Student_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Student_Management_Systems.Login;

namespace Student_Management_Systems
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
           
        }
    public class User
    {
            public String user;
        }
    private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Password;
            User u = new User();
            u.user = UserName.Text;

            if (AuthenticateUser(username, password))
            {

                
                MessageBox.Show("Login successful!", "Success");
                NavigateToDashboard();  // Navigate to the dashboard or main area of your application
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            string connectionString = "server=localhost;User=root;password=;database=student_management_system";
            string query = "SELECT Password FROM Users WHERE FirstName =" + "'"+ username + "'";
                

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
               // cmd.Parameters.AddWithValue("@UserName", username);

                var dbPassword = cmd.ExecuteScalar() as string;

                if (dbPassword != null && dbPassword == password) // Consider using hashed passwords
                {
                    return true;
                }
                return false;
            }
        }

        private void NavigateToDashboard()
        {
            // Assuming DashboardPage is the next page after successful login
            NavigationService.Navigate(new Uri("/StudentDashboard.xaml", UriKind.Relative));
        }

        private void SignupLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SignUp.xaml", UriKind.Relative));
        }
    }
}
