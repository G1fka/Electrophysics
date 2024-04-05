using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Media;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        /// <summary>
        /// окно с тестом
        /// </summary>
        public static string[] AnswerArr { get; set; }
        public TestWindow()
        {
            /// инициализация окна с тестом
            InitializeComponent();
            ManagerNavigator.TestFrame = TestFrame;
            AnswerArr = new string[10];

            var m_sqlCmd = new SQLiteCommand();
            m_sqlCmd.Connection = DataBaseElecrophysics.MydbConn;

            /// отбор случайных вопросов теста
            String sqlQuery;
            sqlQuery = "SELECT * FROM TestQuestions ORDER BY RANDOM() limit 10";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
            DataTable dTable = new DataTable();

            adapter.Fill(dTable);
            DataBaseElecrophysics.TestTable = dTable;

            DataBaseElecrophysics.ResultArr = new bool?[10];

            Que1Button.IsChecked = true;
        }
        /// <summary>
        /// Обработчики событий переключения страниц теста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Que1Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que1Stack.Background = Brushes.Transparent;
            Que1.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que1Button_Checked(object sender, RoutedEventArgs e)
        {
            Que1Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que1.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question1Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que2Stack.Background = Brushes.Transparent;
            Que2.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que2Button_Checked(object sender, RoutedEventArgs e)
        {
            Que2Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que2.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question2Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que3Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que3Stack.Background = Brushes.Transparent;
            Que3.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que3Button_Checked(object sender, RoutedEventArgs e)
        {
            Que3Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que3.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question3Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que4Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que4Stack.Background = Brushes.Transparent;
            Que4.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que4Button_Checked(object sender, RoutedEventArgs e)
        {
            Que4Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que4.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question4Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que5Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que5Stack.Background = Brushes.Transparent;
            Que5.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que5Button_Checked(object sender, RoutedEventArgs e)
        {
            Que5Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que5.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question5Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que6Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que6Stack.Background = Brushes.Transparent;
            Que6.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que6Button_Checked(object sender, RoutedEventArgs e)
        {
            Que6Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que6.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question6Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que7Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que7Stack.Background = Brushes.Transparent;
            Que7.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que7Button_Checked(object sender, RoutedEventArgs e)
        {
            Que7Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que7.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question7Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que8Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que8Stack.Background = Brushes.Transparent;
            Que8.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que8Button_Checked(object sender, RoutedEventArgs e)
        {
            Que8Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que8.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question8Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que9Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que9Stack.Background = Brushes.Transparent;
            Que9.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que9Button_Checked(object sender, RoutedEventArgs e)
        {
            Que9Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que9.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question9Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }

        private void Que10Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Que10Stack.Background = Brushes.Transparent;
            Que10.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
        }

        private void Que10Button_Checked(object sender, RoutedEventArgs e)
        {
            Que10Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Que10.Fill = Brushes.Transparent;
            ManagerNavigator.TestFrame.Navigate(new Question10Page());
            if (TestFrame.CanGoBack)
                TestFrame.RemoveBackEntry();
        }
    }
}
