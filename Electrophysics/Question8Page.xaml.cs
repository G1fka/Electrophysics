using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question8Page.xaml
    /// </summary>
    public partial class Question8Page : Page
    {
        public Question8Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[7];
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q8Grid, 7);
                ContinueButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q8Grid, 7);
                ContinueButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q8Grid, 7);
                ContinueButton.Click += ThirdContinueButton_Click;
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigator.TestFrame.Navigate(new Question9Page());
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[7].ItemArray[0].ToString()), Q8Grid, 7);
            ManagerNavigator.TestFrame.Navigate(new Question9Page());
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q8Grid, 7);
            ManagerNavigator.TestFrame.Navigate(new Question9Page());
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q8Grid, 7);
            ManagerNavigator.TestFrame.Navigate(new Question9Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que8Stack")).FindName("Que8Button")).IsChecked = true;
        }
    }
}
