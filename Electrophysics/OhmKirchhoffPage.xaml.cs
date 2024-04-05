using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Application = System.Windows.Application;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для OhmKirchhoffPage.xaml
    /// </summary>
    public partial class OhmKirchhoffPage : Page
    {
        public OhmKirchhoffPage()
        {
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
                ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 6";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    for (int i = 0; i < contentArr.Length; i++)
                    {
                        if (contentArr[i][0] == '/' || contentArr[i][1] == '/') /// если картинка
                        {
                            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                            var bIImage = new BitmapImage();
                            if (contentArr[i][0] == '/') /// обычные условия размещения
                            {
                                bIImage.BeginInit();
                                bIImage.UriSource = new Uri("pack://application:,,," + contentArr[i]);
                                bIImage.EndInit();

                                image.Source = bIImage;

                                image.Width = bIImage.Width;
                                image.Height = bIImage.Height;

                                image.Margin = new Thickness(0, 0, 0, 20);

                                OhmKirchhoffStack.Children.Add(image);
                            }
                            else /// картинка и текст на одном уровне
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

                                stackPanel.Children.Add(image);
                                stackPanel.Children.Add(text);

                                OhmKirchhoffStack.Children.Add(stackPanel);
                            }
                        }
                        else /// если текст
                        {
                            TextBlock textBlock = new TextBlock();
                            textBlock.Margin = new Thickness(20, 20, 0, 20);
                            if (contentArr[i][0] == 'R') /// если выделение цветом
                            {
                                StackPanel stackPanel = new StackPanel();
                                textBlock.Style = (Style)Application.Current.Resources["Paragraph"];
                                textBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC"); ;
                                textBlock.Text = contentArr[i].Substring(1, contentArr[i].Length - 1);
                            }
                            else if (contentArr[i][0] == 'H') /// если заголовок
                            {
                                textBlock.Style = (Style)Application.Current.Resources["Header"];
                                textBlock.Text = contentArr[i].Substring(1, contentArr[i].Length - 1);
                            }
                            else /// если обычный абзац
                            {
                                textBlock.Style = (Style)Application.Current.Resources["Paragraph"];
                                textBlock.Text = contentArr[i];
                            }
                            OhmKirchhoffStack.Children.Add(textBlock);
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
