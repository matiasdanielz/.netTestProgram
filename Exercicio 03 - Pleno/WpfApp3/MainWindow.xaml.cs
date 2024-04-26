using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<IParticipant> participants { get; } = new ObservableCollection<IParticipant>();
        public static ObservableCollection<IEvent> events { get; } = new ObservableCollection<IEvent>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnEventsBtn_Click(object sender, RoutedEventArgs e)
        {
            F_Events f_events= new F_Events();
            f_events.ShowDialog();
        }

        private void OnParticipantsBtn_Click(object sender, RoutedEventArgs e)
        {
            F_Participants f_Participants = new F_Participants();
            f_Participants.ShowDialog();
        }

        private void OnReportsBtn_Click(object sender, RoutedEventArgs e)
        {
            F_Reports f_reports = new F_Reports();
            f_reports.ShowDialog();
        }
    }
}