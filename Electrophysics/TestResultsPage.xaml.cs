using ClassLibrary;
using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для TestResultsPage.xaml
    /// </summary>
    public partial class TestResultsPage : Page
    {
        /// <summary>
        /// страница вывода результатов теста
        /// </summary>
        public TestResultsPage()
        {
            /// инициализация страницы результатов теста
            InitializeComponent();

            int correct = 0;

            int mark;
            /// подсчёт правльных ответов
            foreach (var answer in DataBaseElecrophysics.ResultArr)
            {
                if (answer == true) correct++;
            }

            /// определение оценки
            if (correct > 5 && correct < 7) mark = 3;
            else if (correct > 6 && correct < 9) mark = 4;
            else if (correct > 8) mark = 5;
            else mark = 2;

            ResultTextBlock.Text = $"Дата и время прохождения:\n{DateTime.Now} " +
                $"\nРезультат:      {correct}/10 - {correct * 10}%\nОценка:     {mark}";

            if (CurrentUser.User != null)
            {
                var m_sqlCmd = new SQLiteCommand();
                m_sqlCmd.Connection = DataBaseElecrophysics.MydbConn;
                /// занесение результатов в базу данных
                m_sqlCmd.CommandText = $"UPDATE Users SET LastResult = '{ResultTextBlock.Text}' WHERE Login = '{CurrentUser.User.Login}'";

                m_sqlCmd.ExecuteNonQuery();
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            /// кнопка возврата на главный ответ
            Window.GetWindow(this).Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que10Stack")).FindName("Que10Button")).IsChecked = false;
        }
    }
}
