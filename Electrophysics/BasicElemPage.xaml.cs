using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Application = System.Windows.Application;
using Image = System.Windows.Controls.Image;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для BasicElemPage.xaml
    /// </summary>
    public partial class BasicElemPage : Page
    {
        public BasicElemPage()
        {
            /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
            ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 4";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    foreach (var paragraph in contentArr)
                    {
                        if (paragraph[0] == '/') ///если картинка
                        {
                            Image image = new Image();
                            image.Source = new BitmapImage(new Uri("pack://application:,,," + paragraph));
                            image.Width = 700;
                            image.Margin = new Thickness(0, 50, 0, 20);
                            BasicElemStack.Children.Add(image);
                        }
                        else ///если текст - в данном случае только заголовок
                        {
                            TextBlock textBlock = new TextBlock();
                            textBlock.Style = (Style)Application.Current.Resources["Header"];
                            textBlock.Text = paragraph.Substring(1, paragraph.Length - 1);
                            BasicElemStack.Children.Add(textBlock);
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
