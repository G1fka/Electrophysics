using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question4Page.xaml
    /// </summary>
    public partial class Question4Page : Page
    {
        public Question4Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[3];
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q4Grid, 3);
                ContinueButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q4Grid, 3);
                ContinueButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q4Grid, 3);
                ContinueButton.Click += ThirdContinueButton_Click;
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigator.TestFrame.Navigate(new Question5Page());
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[3].ItemArray[0].ToString()), Q4Grid, 3);
            ManagerNavigator.TestFrame.Navigate(new Question5Page());
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q4Grid, 3);
            ManagerNavigator.TestFrame.Navigate(new Question5Page());
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q4Grid, 3);
            ManagerNavigator.TestFrame.Navigate(new Question5Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que4Stack")).FindName("Que4Button")).IsChecked = true;
        }
    }
}
