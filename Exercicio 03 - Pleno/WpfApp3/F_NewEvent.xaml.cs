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
    /// Lógica interna para F_NewEvent.xaml
    /// </summary>
    public partial class F_NewEvent : Window
    {
        public F_NewEvent()
        {
            InitializeComponent();
        }

        private void OnNewEventAddButton_Click(object sender, RoutedEventArgs e)
        {
            var eventItem = new IEvent();
            eventItem.name = newEventNameTextField.Text;
            eventItem.date = newEventDateTextField.Text;
            eventItem.localization = newEventLocalizationTextField.Text;
            eventItem.description = newEventDescriptionTextField.Text;

            MainWindow.events.Add(eventItem);
            this.Close();
        }

        private void OnCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
