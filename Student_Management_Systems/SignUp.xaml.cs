using MySql.Data.MySqlClient;
using Student_Management_Systems.Models; // Adjust with your actual namespace for the DbContext
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Student_Management_Systems
{
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            // Read input from the form
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            DateTime? dateOfBirth = DateOfBirthPicker.SelectedDate;
            string gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string username = UserNameTextBox.Text;
            string password = PasswordBox.Password; // Consider hashing this password
            bool isProfessor = ProfessorCheckBox.IsChecked ?? false;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || !dateOfBirth.HasValue)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Insert into the database
            if (AddUserToDatabase(firstName, lastName, dateOfBirth.Value, gender, username, password, isProfessor))
            {
                MessageBox.Show("Signup successful! Please login.", "Success");
                NavigateToLogin();
            }
            else
            {
                MessageBox.Show("Error signing up. User may already exist or there was a database error.", "Error");
            }
        }

        private bool AddUserToDatabase(string firstName, string lastName, DateTime dateOfBirth, string gender, string username, string password, bool isProfessor)
        {
            string connectionString = "server=127.0.0.1;User=root;password=;database=student_management_system";
            
            string query = "INSERT INTO Users (FirstName, LastName, DateOfBirth, Gender, UserName, Password, IsProfessor)" +
                             "VALUES ('"+ firstName + "', '"+ lastName +"', '"+ dateOfBirth +"', '"+ gender +"', '"+ username +"', '"+ password +"', "+ (isProfessor ? 1 : 0) + ");";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("FirstName", firstName);
                //cmd.Parameters.AddWithValue("LastName", lastName);
                //cmd.Parameters.AddWithValue("DateOfBirth", dateOfBirth);
                //cmd.Parameters.AddWithValue("Gender", gender);
                //cmd.Parameters.AddWithValue("UserName", username);
                //cmd.Parameters.AddWithValue("Password", password); // Consider using a hashed password
                //cmd.Parameters.AddWithValue("IsProfessor", isProfessor);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}");
                    return false;
                }
            }
        }

        private void NavigateToLogin()
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }
    }
}