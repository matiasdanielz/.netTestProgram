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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculeButton_Click(object sender, RoutedEventArgs e)
        {
            float cathet1 = float.Parse(width.Text);
            float cathet2 = float.Parse(height.Text);

            bool isCathet1Invalid = cathet1 < 0;
            bool isCathet2Invalid = cathet2 < 0;

            double anguloRad = Math.Atan(cathet1 / cathet2);

            if (isCathet1Invalid || isCathet2Invalid)
                MessageBox.Show("Os valores devem ser inteiros (maior ou igual a 1) e nenhum dos campos deve estar vazio");
            else
            {
                hypotenuseValue.Content = Math.Sqrt(Math.Pow(cathet1, 2) + Math.Pow(cathet2, 2));
                angleValue.Content = anguloRad * (180 / Math.PI);
            }
        }

        private void OnConvertToRadiansButton_Click(object sender, RoutedEventArgs e)
        {
            float cathet1ValueDegrees = float.Parse(width.Text);
            float cathet2ValueDegrees = float.Parse(height.Text);
            double cathet1ValueRadians = cathet1ValueDegrees * Math.PI / 180;
            double cathet2ValueRadians = cathet2ValueDegrees * Math.PI / 180;

            width.Text = cathet1ValueRadians.ToString();
            height.Text = cathet2ValueRadians.ToString();
        }
    }
}
