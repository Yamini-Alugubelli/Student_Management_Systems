using Student_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Management_Systems.UI_design
{
    /// <summary>
    /// Interaction logic for SignUP.xaml
    /// </summary>
    public partial class SignUP : Window
    {
        public SignUP()
        {
            InitializeComponent();
        }
        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming your input fields are named accordingly
            var user = new Users
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                DateOfBirth = DateOfBirthPicker.SelectedDate.Value,
                Gender = GenderComboBox.Text,
                UserName = UserNameTextBox.Text,
                Password = PasswordBox.Password, // You should hash this
                IsProfessor = ProfessorCheckBox.IsChecked.Value
            };
            AddUserToDatabase(user);
        }

        private void AddUserToDatabase(Users user)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
