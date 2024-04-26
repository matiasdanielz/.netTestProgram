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
    /// Lógica interna para F_Participants.xaml
    /// </summary>
    public partial class F_Participants : Window
    {
       public F_Participants()
        {
            InitializeComponent();
            dataGrid.ItemsSource = MainWindow.participants;
        }

        private void OnParticipantAdd_Click(object sender, RoutedEventArgs e)
        {
            F_NewParticipant f_NewParticipant = new F_NewParticipant();
            f_NewParticipant.ShowDialog();
        }

    }
}
