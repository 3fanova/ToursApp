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

        int i = 1;
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
            

            if (tbPassword.Text.Length != 0 && tbLogin.Text.Length != 0 && pswPassword.Password.Length != 0)
            {
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
                    if (i < 4)
                    {
                        MessageBox.Show("Логин и пароль неверны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        tbPassword.Clear();
                        pswPassword.Clear();
                    }
                    else
                    {
                        btnEntry.IsEnabled = false;
                        Timer timer = new Timer();
                        timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                        timer.Interval = 8000;
                        timer.Enabled = true;
                    }
                }
            }
            else if (tbPassword.Text.Length != 0 && pswPassword.Password.Length != 0 && tbLogin.Text.Length == 0)
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPassword.Clear();
                pswPassword.Clear();
            }
            else if (tbPassword.Text.Length == 0 && pswPassword.Password.Length == 0 && tbLogin.Text.Length != 0)
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPassword.Clear();
                pswPassword.Clear();
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPassword.Clear();
                pswPassword.Clear();
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
