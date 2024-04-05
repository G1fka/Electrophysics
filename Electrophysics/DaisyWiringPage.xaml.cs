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
    /// Логика взаимодействия для DaisyWiringPage.xaml
    /// </summary>
    public partial class DaisyWiringPage : Page
    {
        public DaisyWiringPage()
        {
            /// инициализация окна, проверяется соединение с базой данных, затем формируется и 
            ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 2";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    bool horizontal = false;

                    for (int i = 0; i < contentArr.Length; i++)
                    {
                        if (!horizontal) /// если обычные условия помещения объекта
                        {
                            if (contentArr[i][0] == '/' || contentArr[i][1] == '/')
                            {
                                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                                image.Width = 300;
                                if (contentArr[i][0] == '/') /// если обычные условия помещения картинки
                                {
                                    image.Source = new BitmapImage(new Uri("pack://application:,,," +
                                        contentArr[i]));
                                    image.Margin = new Thickness(0, 0, 0, 20);
                                    DaisyWiringStack.Children.Add(image);
                                }
                                else /// если картинка параллельна тексту
                                {
                                    image.Source = new BitmapImage(new Uri("pack://application:,,," +
                                        contentArr[i].Substring(1, contentArr[i].Length - 1)));
                                    image.Margin = new Thickness(0, 0, 0, 0);
                                    StackPanel stackPanel = new StackPanel();
                                    stackPanel.Orientation = Orientation.Horizontal;

                                    TextBlock text = new TextBlock();
                                    text.Style = (Style)System.Windows.Application.Current.Resources["Paragraph"];
                                    text.Text = contentArr[i + 1];
                                    text.Width = 500;
                                    horizontal = true;

                                    stackPanel.Children.Add(image);
                                    stackPanel.Children.Add(text);

                                    DaisyWiringStack.Children.Add(stackPanel);
                                }
                            }
                            else /// если текст
                            {
                                TextBlock textBlock = new TextBlock();
                                textBlock.Width = 1000;
                                if (contentArr[i][0] == 'H') /// заголовок
                                {
                                    textBlock.Text = contentArr[i].Substring(1, contentArr[i].Length - 1);
                                    textBlock.Style = (Style)System.Windows.Application.Current.Resources["Header"];
                                }
                                else
                                {
                                    textBlock.Text = contentArr[i];
                                    textBlock.Style = (Style)System.Windows.Application.Current.Resources["Paragraph"];
                                }
                                DaisyWiringStack.Children.Add(textBlock);
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
