using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question10Page.xaml
    /// </summary>
    public partial class Question10Page : Page
    {
        public Question10Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[9];
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q10Grid, 9);
                EndTestButton.Click -= EndTestButton_Click;
                EndTestButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q10Grid, 9);
                EndTestButton.Click -= EndTestButton_Click;
                EndTestButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q10Grid, 9);
                EndTestButton.Click -= EndTestButton_Click;
                EndTestButton.Click += ThirdContinueButton_Click;
            }
        }

        private void EndTestButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите завершить тест?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ManagerNavigator.TestFrame.Navigate(new TestResultsPage());
            }
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[9].ItemArray[0].ToString()), Q10Grid, 9);
            EndTestButton_Click(sender, e);
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q10Grid, 9);
            EndTestButton_Click(sender, e);
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q10Grid, 9);
            EndTestButton_Click(sender, e);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que10Stack")).FindName("Que10Button")).IsChecked = true;
        }
    }
}
