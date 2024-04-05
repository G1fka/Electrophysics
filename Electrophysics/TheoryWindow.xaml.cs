using System.Windows;
using System.Windows.Media;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для TheoryWindow.xaml
    /// </summary>
    public partial class TheoryWindow : Window
    {
        /// <summary>
        /// окно с теорией
        /// </summary>
        public TheoryWindow()
        {
            /// инициализация окна с теорией
            InitializeComponent();
            ManagerNavigator.TheoryFrame = TheoryFrame;
            Q1Button.IsChecked = true;
        }

        /// <summary>
        /// обработчики событий радиокнопок переключения страниц с теорией
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Q1Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q1Stack.Background = Brushes.Transparent;
            Q1.Fill = Brushes.Transparent;
        }

        private void Q1Button_Checked(object sender, RoutedEventArgs e)
        {
            Q1Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q1.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new ISUPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q2Stack.Background = Brushes.Transparent;
            Q2.Fill = Brushes.Transparent;
        }

        private void Q2Button_Checked(object sender, RoutedEventArgs e)
        {
            Q2Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q2.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new DaisyWiringPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q3Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q3Stack.Background = Brushes.Transparent;
            Q3.Fill = Brushes.Transparent;
        }

        private void Q3Button_Checked(object sender, RoutedEventArgs e)
        {
            Q3Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q3.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new ParallelConnectionPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q4Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q4Stack.Background = Brushes.Transparent;
            Q4.Fill = Brushes.Transparent;
        }

        private void Q4Button_Checked(object sender, RoutedEventArgs e)
        {
            Q4Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q4.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new BasicElemPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q5Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q5Stack.Background = Brushes.Transparent;
            Q5.Fill = Brushes.Transparent;
        }

        private void Q5Button_Checked(object sender, RoutedEventArgs e)
        {
            Q5Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q5.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new ComplexElemPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q6Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q6Stack.Background = Brushes.Transparent;
            Q6.Fill = Brushes.Transparent;
        }

        private void Q6Button_Checked(object sender, RoutedEventArgs e)
        {
            Q6Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q6.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new OhmKirchhoffPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q7Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q7Stack.Background = Brushes.Transparent;
            Q7.Fill = Brushes.Transparent;
        }

        private void Q7Button_Checked(object sender, RoutedEventArgs e)
        {
            Q7Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q7.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new OverlayMethodPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q8Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q8Stack.Background = Brushes.Transparent;
            Q8.Fill = Brushes.Transparent;
        }

        private void Q8Button_Checked(object sender, RoutedEventArgs e)
        {
            Q8Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q8.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new NodalStressMethodPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q9Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q9Stack.Background = Brushes.Transparent;
            Q9.Fill = Brushes.Transparent;
        }

        private void Q9Button_Checked(object sender, RoutedEventArgs e)
        {
            Q9Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q9.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new AmVoltMeterPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void Q10Button_Unchecked(object sender, RoutedEventArgs e)
        {
            Q10Stack.Background = Brushes.Transparent;
            Q10.Fill = Brushes.Transparent;
        }

        private void Q10Button_Checked(object sender, RoutedEventArgs e)
        {
            Q10Stack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#454545");
            Q10.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC");
            ManagerNavigator.TheoryFrame.Navigate(new RadioReceiverPage());
            if (TheoryFrame.CanGoBack)
                TheoryFrame.RemoveBackEntry();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            TestWindow test = new TestWindow();
            test.Show();
        }
    }
}
