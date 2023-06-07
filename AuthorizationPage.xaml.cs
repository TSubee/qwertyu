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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {       
            ProcatEntities userContext = new ProcatEntities();         

            try
            {
                var userObj = userContext.Worker.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password==PasswordBox.Password);

                if (userObj==null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IDRole)
                    {
                        case 1:MessageBox.Show("Здравствуйте, Администратор " + userObj.LastName + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new AdminPage());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Старший смены " + userObj.LastName + "!",
                     "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new OldWorkerPage());
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, Продавец " + userObj.LastName + "!",
                     "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new WorkerPage());
                            break;
                        default: MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
