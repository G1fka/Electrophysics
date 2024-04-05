using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для ExerciseWindow.xaml
    /// </summary>
    public partial class ExerciseWindow : Window
    {
        /// <summary>
        /// Окно упражнений
        /// </summary>
        public DataTable dTable = new DataTable();
        public int q = 0;
        public ExerciseWindow()
        {
            /// упражнения
            InitializeComponent();

            /// рандомная сортировка задач
            String sqlQuery;
            sqlQuery = "SELECT * FROM Exercises ORDER BY RANDOM()";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);

            adapter.Fill(dTable);
            DataBaseElecrophysics.TestTable = dTable;

            ConditionImage.Source = new BitmapImage(new Uri("pack://application:,,," + dTable.Rows[q].ItemArray[1]));

            AnswerImage.Source = new BitmapImage(new Uri("pack://application:,,," + dTable.Rows[q].ItemArray[2]));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            /// возврат на главный экран
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ShowAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            /// кнопка показа правильного ответа
            ShowAnswerButton.Visibility = Visibility.Hidden;
            AnswerImage.Visibility = Visibility.Visible;
        }

        private void NextExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            /// кнопка следующей задачи
            if (q < 4)
            {
                q++;
                ConditionImage.Source = new BitmapImage(new Uri("pack://application:,,," + dTable.Rows[q].ItemArray[1]));

                AnswerImage.Source = new BitmapImage(new Uri("pack://application:,,," + dTable.Rows[q].ItemArray[2]));

                AnswerImage.Visibility = Visibility.Collapsed;

                ShowAnswerButton.Visibility = Visibility.Visible;
                AnswerImage.Visibility = Visibility.Hidden;

                foreach (var child in AnswerSpaceGrid.Children)
                {
                    try
                    {
                        /// очистка введенных данных
                        TextBox textBox = (TextBox)child;
                        textBox.Text = "";
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            else
                MessageBox.Show("Упражнения закончились :(", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
