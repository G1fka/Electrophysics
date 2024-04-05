using ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для Question5Page.xaml
    /// </summary>
    public partial class Question5Page : Page
    {
        public Question5Page()
        {
            InitializeComponent();

            var row = DataBaseElecrophysics.TestTable.Rows[4];
            int value = int.Parse(row.ItemArray[1].ToString());

            if (value == 1)
            {
                DataBaseElecrophysics.FirstType(row.ItemArray[0].ToString(), Q5Grid, 4);
                ContinueButton.Click += FirstContinueButton_Click;
            }
            else if (value == 2)
            {
                DataBaseElecrophysics.SecondType(Q5Grid, 4);
                ContinueButton.Click += SecondContinueButton_Click;
            }
            else if (value == 3)
            {
                DataBaseElecrophysics.ThirdType(Q5Grid, 4);
                ContinueButton.Click += ThirdContinueButton_Click;
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerNavigator.TestFrame.Navigate(new Question6Page());
        }

        private void FirstContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.FirstContinue(int.Parse(DataBaseElecrophysics.TestTable.Rows[4].ItemArray[0].ToString()), Q5Grid, 4);
            ManagerNavigator.TestFrame.Navigate(new Question6Page());
        }

        private void SecondContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.SecondContinue(Q5Grid, 4);
            ManagerNavigator.TestFrame.Navigate(new Question6Page());
        }

        private void ThirdContinueButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseElecrophysics.ThirdContinue(Q5Grid, 4);
            ManagerNavigator.TestFrame.Navigate(new Question6Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            ((RadioButton)((StackPanel)parent.FindName("Que5Stack")).FindName("Que5Button")).IsChecked = true;
        }
    }
}
