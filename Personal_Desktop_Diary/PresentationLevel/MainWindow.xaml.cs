using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLevel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserDTO _user;
        private EventService _service;
        private ObservableCollection<EventDTO> events;
        public ObservableCollection<EventDTO> Events
        {
            get
            {
                events = new ObservableCollection<EventDTO>(_service.GetProducts(_user));
                return events;
            }
            set
            {
                events = value;
            }
        }
         public MainWindow(UserDTO user)
        {           
            InitializeComponent();            
            _user = user;
            welcomeTextblock.Text += $" {user.Name}  {user.Surname}";
            eventList.ItemsSource = Events;
            
        }

        private void AddNewEvent_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEventWindow = new AddEvent();
            if(addEventWindow.ShowDialog() == true)
            {
                EventDTO event1 = new EventDTO
                {
                    EventName = addEventWindow.EventName,
                    EventStart = addEventWindow.StartEvent,
                    EventEnd = addEventWindow.EndEvent,
                    User = _user
                };
                _service.AddEvent(event1);
                events.Add(event1);
                MessageBox.Show($"EventDTO {event1.EventName} was added succesfully");
            }            
        }

        
    }
}
