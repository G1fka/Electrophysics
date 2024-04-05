using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question1Page.xaml
    /// </summary>
    public partial class Question1Page : Page
    {
        public Question1Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[0];

            ContinueButton.Click -= ContinueButton_Click;
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q1Grid, 0);
                ContinueButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q1Grid, 0);
                ContinueButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q1Grid, 0);
                ContinueButton.Click += ThirdContinueButton_Click;
            }

        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigator.TestFrame.Navigate(new Question2Page());
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[0].ItemArray[0].ToString()), Q1Grid, 0);
            ManagerNavigator.TestFrame.Navigate(new Question2Page());
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q1Grid, 0);
            ManagerNavigator.TestFrame.Navigate(new Question2Page());
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q1Grid, 0);
            ManagerNavigator.TestFrame.Navigate(new Question2Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que1Stack")).FindName("Que1Button")).IsChecked = true;
        }
    }
}
