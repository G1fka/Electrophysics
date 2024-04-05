using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question9Page.xaml
    /// </summary>
    public partial class Question9Page : Page
    {
        public Question9Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[8];
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q9Grid, 8);
                ContinueButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q9Grid, 8);
                ContinueButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q9Grid, 8);
                ContinueButton.Click += ThirdContinueButton_Click;
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigator.TestFrame.Navigate(new Question10Page());
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[8].ItemArray[0].ToString()), Q9Grid, 8);
            ManagerNavigator.TestFrame.Navigate(new Question10Page());
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q9Grid, 8);
            ManagerNavigator.TestFrame.Navigate(new Question10Page());
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q9Grid, 8);
            ManagerNavigator.TestFrame.Navigate(new Question10Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que9Stack")).FindName("Que9Button")).IsChecked = true;
        }
    }
}
