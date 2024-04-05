using ClassLibrary;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для ComplexElemPage.xaml
    /// </summary>
    public partial class ComplexElemPage : Page
    {
        public ComplexElemPage()
        {
            ///Инициализация окна, проверяется соединение с базой данных, затем формируется и 
            ///выполняется запрос, выбирающий из таблицы Theory строку с данной темой  
            InitializeComponent();

            DataTable dTable = new DataTable();
            String sqlQuery;
            try
            {
                sqlQuery = "SELECT * FROM Theory WHERE Lesson = 5";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, DataBaseElecrophysics.MydbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    var content = dTable.Rows[0].ItemArray[1].ToString();
                    string[] contentArr = content.Split(';');

                    foreach (var paragraph in contentArr)
                    {
                        TextBlock textBlock = new TextBlock();
                        if (paragraph[0] == 'R') ///выделение цветом
                        {
                            textBlock.Style = (Style)Application.Current.Resources["Paragraph"];
                            textBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#2CE8DC"); ;
                            textBlock.Text = paragraph.Substring(1, paragraph.Length - 1);
                        }
                        else if (paragraph[0] == 'H') ///заголовок
                        {
                            textBlock.Style = (Style)Application.Current.Resources["Header"];
                            textBlock.Text = paragraph.Substring(1, paragraph.Length - 1);
                        }
                        else ///обычный абзац
                        {
                            textBlock.Style = (Style)Application.Current.Resources["Paragraph"];
                            textBlock.Text = paragraph;
                        }
                        ComplexElemStack.Children.Add(textBlock);
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
