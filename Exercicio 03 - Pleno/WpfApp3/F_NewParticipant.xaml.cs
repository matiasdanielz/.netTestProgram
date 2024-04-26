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
using static MaterialDesignThemes.Wpf.Theme;


namespace WpfApp3
{
    /// <summary>
    /// Lógica interna para F_NewParticipant.xaml
    /// </summary>
    public partial class F_NewParticipant : Window
    {
        public F_NewParticipant()
        {
            InitializeComponent();
        }

        private void OnCloseNewParticipantWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnAddNewParticipant_Click(object sender, RoutedEventArgs e)
        {
            var participant = new IParticipant();
            participant.name = newParticipantNameTextField.Text;
            participant.email = newParticipantEmailTextField.Text;
            participant.phone = newParticipantPhoneTextField.Text;

            MainWindow.participants.Add(participant);
            this.Close();
        }
    }
}
