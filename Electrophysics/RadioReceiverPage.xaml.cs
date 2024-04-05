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
    /// Логика взаимодействия для RadioReceiverPage.xaml
    /// </summary>
    public partial class RadioReceiverPage : Page
    {
        public RadioReceiverPage()
        {
            /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
            ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 10";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    for (int i = 0; i < contentArr.Length; i++)
                    {
                        if (contentArr[i][0] == '/') /// картинка
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

                            ReceiverStack.Children.Add(image);
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
                            else /// обычный абзац
                            {
                                textBlock.Text = contentArr[i];
                                textBlock.Style = (Style)System.Windows.Application.Current.Resources["Paragraph"];
                            }
                            ReceiverStack.Children.Add(textBlock);
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
