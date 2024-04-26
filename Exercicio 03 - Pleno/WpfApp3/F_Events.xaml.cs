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

namespace WpfApp3
{
    /// <summary>
    /// Lógica interna para F_Events.xaml
    /// </summary>
    public partial class F_Events : Window
    {
        public F_Events()
        {
            InitializeComponent();
            dataGrid.ItemsSource = MainWindow.events;
        }

        private void OnNewEventButton_Click(object sender, RoutedEventArgs e)
        {
            F_NewEvent f_NewEvent = new F_NewEvent();
            f_NewEvent.ShowDialog();
        }

        public void OnAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            IEvent selectedEvent = button.DataContext as IEvent;

            F_AvailableParticipants f_availableParticipants = new F_AvailableParticipants(selectedEvent);
            f_availableParticipants.Show();
        }
    }
}
