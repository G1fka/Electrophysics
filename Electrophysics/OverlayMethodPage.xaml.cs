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
    /// Логика взаимодействия для OverlayMethodPage.xaml
    /// </summary>
    public partial class OverlayMethodPage : Page
    {
        public OverlayMethodPage()
        {
            /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
            ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 7";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    foreach (var paragraph in contentArr)
                    {
                        if (paragraph[0] == '/') /// если картинка
                        {
                            Image image = new Image();
                            image.Source = new BitmapImage(new Uri("pack://application:,,," + paragraph));
                            image.Width = 700;
                            image.Margin = new Thickness(0, 50, 0, 20);
                            OverlayStack.Children.Add(image);
                        }
                        else /// если текст
                        {
                            TextBlock textBlock = new TextBlock();
                            if (paragraph[0] == 'H') /// если заголовок
                            {
                                textBlock.Style = (Style)Application.Current.Resources["Header"];
                                textBlock.Text = paragraph.Substring(1, paragraph.Length - 1);
                            }
                            else /// если обычный абзац
                            {
                                textBlock.Style = (Style)Application.Current.Resources["Paragraph"];
                                textBlock.Text = paragraph;
                            }
                            OverlayStack.Children.Add(textBlock);
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
