using PersonRepository.Factory;
using PersonRepository.Interface;
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
            Populate("Service");
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {

            Populate("CSV");

        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {

            Populate("SQL");
        }

        private void Populate(string repository)
        {
            ClearListBox();


            IPersonRepository personRepository = RepositoryFactory.GetRepository(repository);
            var persons = personRepository.GetPeople();
            foreach (var person in persons)
            {
                PersonListBox.Items.Add(person);
            }
            ShowRepositoryType(personRepository);
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
