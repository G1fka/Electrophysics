using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        /// <summary>
        /// окно регистрации
        /// </summary>
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            /// кнопка возврата на начальный экран
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            /// авторизация
            var m_sqlCmd = new SQLiteCommand();
            m_sqlCmd.Connection = DataBaseElecrophysics.MydbConn;

            DataTable dTable = new DataTable();
            String sqlQuery;
            sqlQuery = $"SELECT * FROM Users";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
            adapter.Fill(dTable);

            bool exists = false;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if ((string)dTable.Rows[i].ItemArray[0] == LoginTextBox.Text) ///найден пользователь
                {
                    exists = true;
                    if ((string)dTable.Rows[i].ItemArray[1] == PasswordTextBox.Password) /// совпадает пароль
                    {
                        User user = new User() { Login = LoginTextBox.Text, Password = PasswordTextBox.Password };
                        CurrentUser.User = user;
                        this.Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    else MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (!exists) MessageBox.Show("Нет такого пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
