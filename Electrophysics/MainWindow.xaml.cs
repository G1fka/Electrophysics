using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (CurrentUser.User != null)
            {
                UserIcon.Source = new BitmapImage(new Uri("pack://application:,,," + "/Resources/user_icon.png"));
                RegistrationButton.Visibility = Visibility.Hidden;
                AuthorizationButton.Visibility = Visibility.Collapsed;

                VerticalLineBlock.Text = CurrentUser.User.Login;

                LightningImage.Visibility = Visibility.Collapsed;

                DataTable dTable = new DataTable();
                String sqlQuery;
                sqlQuery = $"SELECT * FROM Users WHERE Login = '{CurrentUser.User.Login}'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                var lastRes = dTable.Rows[0].ItemArray[2];

                if (lastRes != null)
                {
                    TextBlock header = new TextBlock();
                    header.Style = (Style)Application.Current.Resources["Header"];
                    header.Text = "Последний результат";
                    LastResStack.Children.Add(header);

                    TextBlock resBlock = new TextBlock();
                    resBlock.Style = (Style)Application.Current.Resources["Header"];
                    resBlock.FontSize = 40;
                    resBlock.Margin = new Thickness(0, 200, 0, 0);
                    resBlock.Text = lastRes.ToString();

                    LastResStack.Children.Add(resBlock);
                }
            }

            DataBaseElecrophysics.MydbConn = new SQLiteConnection("Data Source=Electrophysics.db;Version=3;");
            DataBaseElecrophysics.MydbConn.Open();
            var m_sqlCmd = new SQLiteCommand();
            m_sqlCmd.Connection = DataBaseElecrophysics.MydbConn;

        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AuthorizationWindow authorization = new AuthorizationWindow();
            authorization.Show();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();
        }

        private void TheoryButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            TheoryWindow theory = new TheoryWindow();
            theory.Show();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            TestWindow test = new TestWindow();
            test.Show();
        }

        private void SimulatorButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ExerciseWindow simulator = new ExerciseWindow();
            simulator.Show();
        }

        private void ExitAccount_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.User = null;
            this.Close();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void UserIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.Style = (Style)Application.Current.Resources["ImageContextMenu"];
            MenuItem exitAppMenuItem = new MenuItem();
            exitAppMenuItem.Header = "Выйти из \nприложения";
            exitAppMenuItem.Style = (Style)Application.Current.Resources["ImageMenuItem"];
            exitAppMenuItem.Click += ExitApp_Click;
            contextMenu.Items.Add(exitAppMenuItem);
            if (CurrentUser.User != null)
            {
                Separator separator = new Separator();
                contextMenu.Items.Add(separator);
                MenuItem exitAccMenuItem = new MenuItem();
                exitAccMenuItem.Header = "Выйти из \nаккаунта";
                exitAccMenuItem.Style = (Style)Application.Current.Resources["ImageMenuItem"];
                exitAccMenuItem.Click += ExitAccount_Click;
                contextMenu.Items.Add(exitAccMenuItem);
            }
            contextMenu.IsOpen = true;
        }
    }
}
