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

namespace CPKIO
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow window = new AddClientWindow();
            window.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemoving = DGridClient.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие ", " элементов?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ProcatEntities.GetContext().Client.RemoveRange(clientsForRemoving);
                    ProcatEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridClient.ItemsSource = ProcatEntities.GetContext().Client.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            AddClientWindow window = new AddClientWindow((sender as Button).DataContext as Client);
            window.ShowDialog();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ProcatEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridClient.ItemsSource = ProcatEntities.GetContext().Client.ToList();
            }
        }
    }
}
