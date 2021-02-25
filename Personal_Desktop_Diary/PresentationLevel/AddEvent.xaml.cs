using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
       

        public string EventName { get { return EventnameTextbox.Text; } }

        public DateTime StartEvent { get { return DateTime.ParseExact(startDayTime.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture); } }

        public DateTime EndEvent { get { return DateTime.ParseExact(endDayTime.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture); } }

        public AddEvent()
        {
            InitializeComponent();                        
        }       


        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
