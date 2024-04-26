using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Lógica interna para F_Reports.xaml
    /// </summary>
    /// 

    public partial class F_Reports : Window
    {
        public ObservableCollection<IEventReport> eventsReport { get; } = new ObservableCollection<IEventReport>();
        public F_Reports()
        {
            InitializeComponent();
            eventsReport = GetEventsReport();
            dataGrid.ItemsSource = eventsReport;
        }

        public ObservableCollection<IEventReport> GetEventsReport()
        {
            ObservableCollection<IEventReport> eventsReport = new ObservableCollection<IEventReport>();

            foreach(IEvent eventItem in MainWindow.events)
            {
                IEventReport eventReport = new IEventReport();
                eventReport.name = eventItem.name;

                eventReport.participantsCount = eventItem.participants.Count();
                
                eventsReport.Add(eventReport);
            }

            return eventsReport;
        }

        private void OnDownloadReportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Salvar como CSV";

            if (saveFileDialog.ShowDialog() == true)
            {
                string outputPath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("Nome do Evento;Quantidade de Participantes");

                    foreach (var ev in eventsReport)
                    {
                        writer.WriteLine($"{ev.name};{ev.participantsCount}");
                    }
                }

                MessageBox.Show("Arquivo CSV gerado com sucesso!");
            }
        }
    }
}
