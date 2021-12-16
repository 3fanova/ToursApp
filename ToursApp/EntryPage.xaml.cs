using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для EntryPage.xaml
    /// </summary>
    public partial class EntryPage : Page
    {
       
        
        public EntryPage()
        {
            InitializeComponent();
            
        }

        /*
         счетчик начинаем с нуля - он же не ввел пока что пароля
         */

        private int i = 0; 
        private void cbPassword_Checked(object sender, RoutedEventArgs e)
        {
            pswPassword.Visibility = Visibility.Hidden;
            tbPassword.Visibility = Visibility.Visible;
            tbPassword.Text = pswPassword.Password;

        }
        
        private void cbPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            pswPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Hidden;

            pswPassword.Password = tbPassword.Text;
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            /*Ты создала слишком много условий - в итоге путаешься в них, твой таймер работает, а вот проверки нет*/
            
            /*
             * 1) Проверяем, есть ли логин
             */
            if(tbLogin.Text == "")
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            /*
             * 2) Проверяем, есть ли пароль
             */
            if (pswPassword.Password == "")
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            /*
             * 2) Проверяем, правильный ли ввод
             */
            if (tbLogin.Text == "Администратор" && tbPassword.Text == "Администратор" && pswPassword.Password == "Администратор")
            {
                MessageBox.Show("Авторизация прошла успешно!", "Вход выполнен", MessageBoxButton.OK, MessageBoxImage.Information);
                Meneger.MainFrame.Navigate(new AdministratorPage());
                tbLogin.Clear();
                tbPassword.Clear();
                pswPassword.Clear();
            }
            else if (tbLogin.Text == "Менеджер" && tbPassword.Text == "Менеджер" && pswPassword.Password == "Менеджер")
            {
                MessageBox.Show("Авторизация прощла успешно!", "Вход выполнен", MessageBoxButton.OK, MessageBoxImage.Information);
                Meneger.MainFrame.Navigate(new MenegarPage());
                tbLogin.Clear();
                tbPassword.Clear();
                pswPassword.Clear();
            }
            else
            {
                i++;
                MessageBox.Show($"{i}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                if (i < 4)
                {
                    MessageBox.Show("Логин и пароль неверны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbPassword.Clear();
                    pswPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Блокирую доступ на 8 сек", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    btnEntry.IsEnabled = false;
                    Timer timer = new Timer();
                    timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                    timer.Interval = 8000;
                    timer.Enabled = true;
                }
            }
            
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                btnEntry.IsEnabled = true;

              
            });
        
        }
    }
}
