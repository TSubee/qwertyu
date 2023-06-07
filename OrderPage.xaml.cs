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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow window = new AddOrderWindow();
            window.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ordersForRemoving = DGridOrder.SelectedItems.Cast<Ordder>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие ", " элементов?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ProcatEntities.GetContext().Ordder.RemoveRange(ordersForRemoving);
                    ProcatEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridOrder.ItemsSource = ProcatEntities.GetContext().Ordder.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            AddOrderWindow window = new AddOrderWindow((sender as Button).DataContext as Ordder);
            window.ShowDialog();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ProcatEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridOrder.ItemsSource = ProcatEntities.GetContext().Ordder.ToList();
            }
        }
    }
}
