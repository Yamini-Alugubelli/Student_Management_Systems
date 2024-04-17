using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace Student_Management_Systems
{
    /// <summary>
    /// Interaction logic for ProfessorDashboard.xaml
    /// </summary>
    public partial class ProfessorDashboard : Page
    {
        public ProfessorDashboard()
        {
            InitializeComponent();
            LoadProfessorDetails();
            LoadStudentGrades();
        }
        private string connectionString = "server=localhost;user=root;database=yourdatabase;password=yourpassword;";

        private void LoadProfessorDetails()
        {
            // Example: Load professor details from database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName, Gender, DateOfBirth FROM Professors WHERE ProfessorId = 1;";  // Assume a logged-in professor ID
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                         FirstName.Text = reader["FirstName"].ToString();
                        LastName.Text = reader["LastName"].ToString();
                        Gender.Text = reader["Gender"].ToString();
                        DateOfBirth.Text = DateTime.Parse(reader["DateOfBirth"].ToString()).ToString("MM/dd/yyyy");
                    }
                }
            }
        }

        private void LoadStudentGrades()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StudentName, Grade FROM Grades;";  // Simplified query
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                StudentsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void PostNotification_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Notifications (Message, DatePosted) VALUES (@Message, NOW());";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Message", NotificationTextBox.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Notification posted.");
            }
        }

        private void UpdateGrade_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected item and update grades
            DataRowView row = (DataRowView)StudentsDataGrid.SelectedItem;
            string studentName = row["StudentName"].ToString();
            string grade = ((TextBox)((Button)sender).Tag).Text;  // Assuming Tag contains reference to the TextBox

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Grades SET Grade = @Grade WHERE StudentName = @StudentName;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@StudentName", studentName);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade updated.");
            }
        }

        private void EditDetails_Click(object sender, RoutedEventArgs e)
        {
            // Allow editing of details, such as first name, last name, etc.
            FirstName.IsEnabled = true;
            LastName.IsEnabled = true;
            Gender.IsEnabled = true;
            SaveButton.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Professors SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender WHERE ProfessorId = 1;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Details updated.");
                SaveButton.Visibility = Visibility.Collapsed;
                FirstName.IsEnabled = false;
                LastName.IsEnabled = false;
                Gender.IsEnabled = false;
            }
        }
        
            private void NotificationTextBox_GotFocus(object sender, RoutedEventArgs e)
            {
            }
        private void NotificationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement logout logic, possibly navigating back to a login page
            NavigationService.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));
        }
    }
}
