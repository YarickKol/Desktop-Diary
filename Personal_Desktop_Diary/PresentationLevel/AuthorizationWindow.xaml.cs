using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLevel
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private UnitOfWork _unitOfWork;
        public AuthorizationWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            User user = _unitOfWork.Users.GetSingleItem(u => u.UserName == UsernameTextbox.Text &&
            u.Password == Password_box.Password);

            if (user != null)
            {                  
                MainWindow mainWindow = new MainWindow(user);                
                mainWindow.Show();
                Close();
            }
            else
                MessageBox.Show("User doesnt exist");
        }
    }
}
