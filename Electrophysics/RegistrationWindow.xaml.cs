using ClassLibrary;
using System.Data.SQLite;
using System.Windows;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        /// <summary>
        /// окно авторизации
        /// </summary>
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            /// кнопка возврата на главный экран
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void RegistrizeButton_Click(object sender, RoutedEventArgs e)
        {
            /// регистрация
            var m_sqlCmd = new SQLiteCommand();
            m_sqlCmd.Connection = DataBaseElecrophysics.MydbConn;

            try
            {
                if (PasswordTextBox.Password != RepeatPasswordTextBox.Password) /// проверка на корректные данные
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    User user = new User() { Login = LoginTextBox.Text, Password = PasswordTextBox.Password }; /// создание нового пользователя

                    CurrentUser.User = user; /// инициализация текущего пользователя

                    m_sqlCmd.CommandText = $"INSERT INTO Users (Login, Password) VALUES ('{LoginTextBox.Text}', '{PasswordTextBox.Password}')";

                    m_sqlCmd.ExecuteNonQuery();
                    this.Close();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
            }
            catch
            {
                MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
