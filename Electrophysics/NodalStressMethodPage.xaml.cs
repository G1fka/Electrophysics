using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для NodalStressMethodPage.xaml
    /// </summary>
    public partial class NodalStressMethodPage : Page
    {
        /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
        ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
        public NodalStressMethodPage()
        {
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 8";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    for (int i = 0; i < contentArr.Length; i++)
                    {
                        if (contentArr[i][0] == '/') /// если картинка
                        {
                            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                            var bIImage = new BitmapImage();
                            bIImage.BeginInit();
                            bIImage.UriSource = new Uri("pack://application:,,," + contentArr[i]);
                            bIImage.EndInit();

                            image.Source = bIImage;

                            image.Width = bIImage.Width;
                            image.Height = bIImage.Height;

                            image.Margin = new Thickness(0, 0, 0, 20);

                            StressStack.Children.Add(image);
                        }
                        else /// если текст
                        {
                            TextBlock textBlock = new TextBlock();
                            textBlock.Width = 800;
                            if (contentArr[i][0] == 'H') /// если заголовок
                            {
                                textBlock.Text = contentArr[i].Substring(1, contentArr[i].Length - 1);
                                textBlock.Style = (Style)System.Windows.Application.Current.Resources["Header"];
                            }
                            else if (contentArr[i][0] == 'R') /// если выделение цветом
                            {
                                textBlock.Text = contentArr[i].Substring(1, contentArr[i].Length - 1);
                                textBlock.Style = (Style)Application.Current.Resources["Paragraph"];
                                textBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC"); ;
                            }
                            else /// если обычный абзац
                            {
                                textBlock.Text = contentArr[i];
                                textBlock.Style = (Style)System.Windows.Application.Current.Resources["Paragraph"];
                            }
                            StressStack.Children.Add(textBlock);
                        }
                    }
                }
                else
                    MessageBox.Show("Database is empty");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
