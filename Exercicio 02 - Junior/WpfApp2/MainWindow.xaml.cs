using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        private readonly WeatherService weatherService = new WeatherService();
        public ObservableCollection<Person> Persons { get; } = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = Persons;
            InitializeWeatherForecast();
        }

        private async void InitializeWeatherForecast()
        {
            try
            {
                WeatherData weatherData = await weatherService.GetWeatherDataAsync();
                if (weatherData != null)
                {
                    weatherDescription.Text = "Clima: " + weatherData.Description;
                    weatherTemperature.Text = "Temperatura: " + weatherData.Temperature;
                    weatherHumidity.Text = "Umidade: " + weatherData.Humidity;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao obter os dados meteorológicos: {ex.Message}");
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Informe um arquivo no formato TXT, o conteudo deve obrigatoriamente ser um array de json, com as possiveis propertys (colunas) sendo: " +
                "\n'name': 'string', " +
                "\n'age': 'int', " +
                "\n'email': 'string', " +
                "\n'phone': 'string'!",
                "Atenção!",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            ImportDataFromFile();
        }

        private void ImportDataFromFile()
        {
            openFileDialog.Filter = "Arquivos de Texto|*.txt";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    List<Person> people = JsonConvert.DeserializeObject<List<Person>>(fileContent);

                    foreach (Person person in people)
                    {
                        Persons.Add(person);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Erro ao ler o arquivo: " + ex.Message,
                        "Erro de Leitura",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Houve um erro na leitura do arquivo, reveja as regras desse programa e tente novamente",
                    "Erro de Leitura",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }

    public class WeatherService
    {
        private readonly string latitude = "-29.1678";
        private readonly string longitude = "-51.1794";
        private readonly string language = "pt_br";
        private readonly string apiKey = "7835a9b40f5ecd915e7b08bfc9433f6b";
        private readonly string apiUrl;

        public WeatherService()
        {
            apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric&lang={language}";
        }

        public async Task<WeatherData> GetWeatherDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic weatherData = JsonConvert.DeserializeObject(jsonResponse);

                    return new WeatherData
                    {
                        Description = weatherData.weather[0].description.ToString(),
                        Temperature = weatherData.main.temp.ToString(),
                        Humidity = weatherData.main.humidity.ToString()
                    };
                }
                else
                {
                    Console.WriteLine($"Erro ao obter dados. Código de status: {response.StatusCode}");
                    return null;
                }
            }
        }
    }

    public class WeatherData
    {
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
