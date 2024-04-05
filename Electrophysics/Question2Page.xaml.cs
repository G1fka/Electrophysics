using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question2Page.xaml
    /// </summary>
    public partial class Question2Page : Page
    {
        public Question2Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[1];
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q2Grid, 1);
                ContinueButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q2Grid, 1);
                ContinueButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q2Grid, 1);
                ContinueButton.Click += ThirdContinueButton_Click;
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigator.TestFrame.Navigate(new Question3Page());
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[1].ItemArray[0].ToString()), Q2Grid, 1);
            ManagerNavigator.TestFrame.Navigate(new Question3Page());
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q2Grid, 1);
            ManagerNavigator.TestFrame.Navigate(new Question3Page());
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q2Grid, 1);
            ManagerNavigator.TestFrame.Navigate(new Question3Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que2Stack")).FindName("Que2Button")).IsChecked = true;
        }
    }
}
