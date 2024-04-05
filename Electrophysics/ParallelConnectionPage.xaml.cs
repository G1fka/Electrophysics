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
    /// Логика взаимодействия для ParallelConnectionPage.xaml
    /// </summary>
    public partial class ParallelConnectionPage : Page
    {
        public ParallelConnectionPage()
        {
            /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
            ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 3";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    bool horizontal = false;

                    for (int i = 0; i < contentArr.Length; i++)
                    {
                        if (!horizontal) /// условие для пропуска текста для параллельного расположения с картинкой
                        {
                            if (contentArr[i][0] == '/' || contentArr[i][1] == '/') /// картинка
                            {
                                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                                var bIImage = new BitmapImage();
                                if (contentArr[i][0] == '/') /// обычные условия
                                {
                                    bIImage.BeginInit();
                                    bIImage.UriSource = new Uri("pack://application:,,," + contentArr[i]);
                                    bIImage.EndInit();

                                    image.Source = bIImage;

                                    image.Width = bIImage.Width;
                                    image.Height = bIImage.Height;

                                    image.Margin = new Thickness(0, 0, 0, 20);

                                    ParallelStack.Children.Add(image);
                                }
                                else /// картинка параллельна тексту
                                {
                                    bIImage.BeginInit();
                                    bIImage.UriSource = new Uri("pack://application:,,," + contentArr[i].Substring(1, contentArr[i].Length - 1));
                                    bIImage.EndInit();

                                    image.Source = bIImage;

                                    image.Width = bIImage.Width;
                                    image.Height = bIImage.Height;

                                    image.Margin = new Thickness(0, 20, 0, 20);
                                    StackPanel stackPanel = new StackPanel();
                                    stackPanel.Orientation = Orientation.Horizontal;
                                    stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

                                    TextBlock text = new TextBlock();
                                    text.Style = (Style)System.Windows.Application.Current.Resources["Paragraph"];
                                    text.Text = contentArr[i + 1];
                                    text.Width = 500;
                                    text.Margin = new Thickness(20, 40, 0, 20);
                                    horizontal = true;

                                    stackPanel.Children.Add(image);
                                    stackPanel.Children.Add(text);

                                    ParallelStack.Children.Add(stackPanel);
                                }
                            }
                            else /// текст
                            {
                                TextBlock textBlock = new TextBlock();
                                textBlock.Width = 900;
                                if (contentArr[i][0] == 'H') /// заголовок
                                {
                                    textBlock.Text = contentArr[i].Substring(1, contentArr[i].Length - 1);
                                    textBlock.Style = (Style)System.Windows.Application.Current.Resources["Header"];
                                }
                                else /// обычный текст
                                {
                                    textBlock.Text = contentArr[i];
                                    textBlock.Style = (Style)System.Windows.Application.Current.Resources["Paragraph"];
                                }
                                ParallelStack.Children.Add(textBlock);
                            }
                        }
                        else
                            horizontal = false;
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
