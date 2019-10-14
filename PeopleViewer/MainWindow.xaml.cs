using PersonRepository.CSV;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.SQL;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            Populate(new ServiceRepository());
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {

            Populate(new CSVRepository());

        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {

            Populate(new SQLRepository());
        }

        private void Populate(IPersonRepository repository)
        {
            ClearListBox();

            var persons = repository.GetPeople();
            foreach (var person in persons)
            {
                PersonListBox.Items.Add(person);
            }
            ShowRepositoryType(repository);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
            RepositoryTypeTextBlock.Text = string.Empty;
        }

        private void ShowRepositoryType(IPersonRepository repository)
        {
            RepositoryTypeTextBlock.Text = repository.GetType().ToString();
        }
    }
}
