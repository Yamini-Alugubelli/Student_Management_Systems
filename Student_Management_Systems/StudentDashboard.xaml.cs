using Student_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Page
    {
       // Student_Management_Systems.Login.User user;
        //String userName;
         string connectionString = @"server=127.0.0.1;User=root;password=;database=student_management_system";

        public StudentDashboard()
        {
            InitializeComponent();
            LoadStudentDetails();
            LoadCoursesAndGrades();
            //user = u;
        }
        private bool LoadStudentDetails()
        {
            //userName = user.user;

            // Securely parameterized query to fetch student details who are not professors
            //var query = "SELECT FirstName, LastName, Gender, DateOfBirth FROM Users WHERE IsProfessor = 0 AND FirstName =" + "'" + userName + "'";
            var query = "SELECT FirstName, LastName, Gender, DateOfBirth FROM Users WHERE IsProfessor = 0 AND FirstName = @FirstName";
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);
                   // cmd.Parameters.AddWithValue("@FirstName", username); // Secure parameter addition

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FirstName.Text = reader["FirstName"].ToString();
                            LastName.Text = reader["LastName"].ToString();
                            Gender.Text = reader["Gender"].ToString();
                            DateOfBirth.Text = Convert.ToDateTime(reader["DateOfBirth"]).ToString("MM/dd/yyyy");
                            return true; // Data found and loaded
                        }
                        else
                        {
                            return false; // No data found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load student details: " + ex.Message);
                return false; // Exception handling
            }
        }

        private bool LoadCoursesAndGrades()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string username = FirstName.Text; // Retrieve the username from a TextBox
                    conn.Open();

                    // Parameterized query to prevent SQL injection
                    var query = "SELECT Course, Instructor FROM grades g INNER JOIN users u ON g.UserId = u.UserId WHERE u.IsProfessor = 0 AND u.FirstName = @FirstName";

                    var adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FirstName", username); // Securely adding parameter

                    var coursesTable = new DataTable();
                    adapter.Fill(coursesTable);

                    // Checking if courses data was loaded
                    if (coursesTable.Rows.Count == 0)
                        return false; // No courses data found

                    CoursesList.ItemsSource = coursesTable.DefaultView; // Bind data to the UI

                    // Reusing the adapter for another query
                    query = "SELECT Course, Score FROM grades g INNER JOIN users u ON g.UserId = u.UserId WHERE u.IsProfessor = 0 AND u.FirstName = @FirstName";
                    adapter.SelectCommand.CommandText = query;

                    var gradesTable = new DataTable();
                    adapter.Fill(gradesTable);

                    // Checking if grades data was loaded
                    if (gradesTable.Rows.Count == 0)
                        return false; // No grades data found

                    GradesList.ItemsSource = gradesTable.DefaultView; // Bind data to the UI

                    return true; // Data was successfully loaded
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading courses and grades: " + ex.Message);
                return false; // Return false if an exception occurs
            }
        }

        private void EditDetails_Click(object sender, RoutedEventArgs e)
        {
            // Toggle between TextBlock and TextBox visibility
          //  FirstNameText.Visibility = Visibility.Collapsed;  // Hide the TextBlock
           // FirstNameEdit.Visibility = Visibility.Visible;    // Show the TextBox

            //LastNameText.Visibility = Visibility.Collapsed;   // Hide the TextBlock
            //LastNameEdit.Visibility = Visibility.Visible;     // Show the TextBox

            // Show the Save button
            SaveButton.Visibility = Visibility.Visible;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //using (var conn = new SqlConnection(connectionString))
            //{
              //  conn.Open();
               // var query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName WHERE UserId = @StudentId";
                //var cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                //cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                //cmd.Parameters.AddWithValue("@StudentId", 1); // The student's ID

                //cmd.ExecuteNonQuery();
                //MessageBox.Show("Details updated successfully!");
                //SaveButton.Visibility = Visibility.Collapsed;
            //}
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Optionally clear any session data or perform other cleanup

            // Create an instance of the login window
            //var loginWindow = new LoginWindow();  // Assuming your login window class is named LoginWindow
            //loginWindow.Show();  // Show the login window

            // Close the current main window
            // This assumes that the Logout button is part of the main window
            //Window.GetWindow(this).Close();

        }
    }
}
