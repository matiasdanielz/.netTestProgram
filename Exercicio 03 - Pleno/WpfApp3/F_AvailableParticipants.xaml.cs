using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica interna para F_AvailableParticipants.xaml
    /// </summary>
    public partial class F_AvailableParticipants : Window
    {
        public IEvent selectedEvent = new IEvent();
        public ObservableCollection<IParticipant> availableParticipants { get; } = new ObservableCollection<IParticipant>();

        public F_AvailableParticipants(IEvent selectedEvent)
        {
            InitializeComponent();
            this.selectedEvent = selectedEvent;
            availableParticipants = GetAvailableParticipants();
     
            dataGrid.ItemsSource = availableParticipants;
        }

        public ObservableCollection<IParticipant> GetAvailableParticipants()
        {
            ObservableCollection<IParticipant> participants = new ObservableCollection<IParticipant>();

            foreach (IParticipant participant in MainWindow.participants)
            {
                if (!MainWindow.events.Any(e => e.participants.Any(p => p.id == participant.id)))
                {
                    participants.Add(participant);
                }
            }

            dataGrid.ItemsSource = availableParticipants;


            return participants;
        }

        public void OnAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            IParticipant selectedParticipant = button.DataContext as IParticipant;

            foreach(IEvent iEvent in MainWindow.events)
            {
                if(iEvent.id == selectedEvent.id)
                {
                    iEvent.participants.Add(selectedParticipant);
                    break;
                }
            }

            this.Close();
        }
    }
}
