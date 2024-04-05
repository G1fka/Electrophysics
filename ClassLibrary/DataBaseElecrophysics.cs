using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Application = System.Windows.Application;

namespace ClassLibrary
{
    public class DataBaseElecrophysics
    {
        /// <summary>
        /// статическое свойство подключения к БД
        /// статическая таблица для теста
        /// статический логический массив ответов на тест
        /// </summary>
        public static SQLiteConnection MydbConn { get; set; }
        public static DataTable TestTable { get; set; }
        public static bool?[] ResultArr { get; set; }

        public DataBaseElecrophysics()
        {
            MydbConn = new SQLiteConnection();
        }

        /// <summary>
        /// функции заполнения окон с вопросами по типам вопросов
        /// функции считывания правильности ответа по типам вопросов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="panel"></param>
        /// <param name="q"></param>
        public static void FirstType(string id, Grid panel, int q)
        {
            /// инициализация и помещение заголовка
            TextBlock textBlock = new TextBlock();
            textBlock.Text = TestTable.Rows[q].ItemArray[2].ToString();
            textBlock.Style = (Style)Application.Current.Resources["Header"];
            panel.Children.Add(textBlock);
            switch (id)
            {
                case "5":
                    {
                        /// инициализация и помещение изображения и полей ввода
                        System.Windows.Controls.Image rFormula = new System.Windows.Controls.Image();
                        rFormula.Source = new BitmapImage(new Uri("pack://application:,,," + "/Resources/TestImages/ParallelRTest.png"));
                        rFormula.Width = 500;

                        rFormula.Margin = new Thickness(0, 100, 0, 20);

                        panel.Children.Add(rFormula);

                        TextBox multiBox = new TextBox();
                        multiBox.Name = "MultiBox";
                        multiBox.VerticalAlignment = VerticalAlignment.Top;
                        multiBox.Margin = new Thickness(150, 330, 0, 0);
                        multiBox.Width = 50;
                        multiBox.Height = 50;
                        multiBox.FontSize = 35;
                        multiBox.MaxLength = 1;
                        multiBox.TextAlignment = TextAlignment.Center;
                        Grid.SetZIndex(multiBox, 1);

                        panel.Children.Add(multiBox);

                        TextBox plusBox = new TextBox();
                        plusBox.Name = "PlusBox";
                        plusBox.VerticalAlignment = VerticalAlignment.Top;
                        plusBox.Margin = new Thickness(150, 450, 0, 0);
                        plusBox.Width = 50;
                        plusBox.Height = 50;
                        plusBox.FontSize = 35;
                        plusBox.MaxLength = 1;
                        plusBox.TextAlignment = TextAlignment.Center;

                        Grid.SetZIndex(plusBox, 1);

                        panel.Children.Add(plusBox);
                    }
                    break;
                case "6":
                    {
                        /// инициализация и помещение изображения и полей ввода
                        System.Windows.Controls.Image iFormula = new System.Windows.Controls.Image();
                        iFormula.Source = new BitmapImage(new Uri("pack://application:,,," + "/Resources/TestImages/StressITest.png"));

                        iFormula.Width = 500;

                        iFormula.Margin = new Thickness(0, 100, 0, 20);

                        panel.Children.Add(iFormula);

                        TextBox minusBox = new TextBox();
                        minusBox.Name = "MinusBox";
                        minusBox.Margin = new Thickness(0, 65, 20, 0);
                        minusBox.Width = 50;
                        minusBox.Height = 50;
                        minusBox.FontSize = 30;
                        minusBox.TextAlignment = TextAlignment.Center;
                        Grid.SetZIndex(minusBox, 1);

                        panel.Children.Add(minusBox);

                        TextBox multiBox = new TextBox();
                        multiBox.Name = "MultiBox";
                        multiBox.Margin = new Thickness(290, 65, 0, 0);
                        multiBox.Width = 50;
                        multiBox.Height = 50;
                        multiBox.FontSize = 30;
                        multiBox.TextAlignment = TextAlignment.Center;
                        Grid.SetZIndex(multiBox, 1);

                        panel.Children.Add(multiBox);
                    }
                    break;
                case "7":
                    {
                        /// инициализация и помещения поля ввода
                        TextBox shuntBox = new TextBox();
                        shuntBox.Name = "ShuntBox";
                        shuntBox.Style = (Style)Application.Current.Resources["SimpleTextBox"];
                        shuntBox.Margin = new Thickness(0, 20, 0, 0);
                        shuntBox.Width = 500;
                        shuntBox.Height = 70;
                        shuntBox.HorizontalAlignment = HorizontalAlignment.Center;
                        panel.Children.Add(shuntBox);
                    }
                    break;
                case "8":
                    {
                        /// /// инициализация и помещение изображения и полей ввода в виде массива
                        System.Windows.Controls.Image uFormula = new System.Windows.Controls.Image();
                        var bIImage = new BitmapImage();
                        bIImage.BeginInit();
                        bIImage.UriSource = new Uri("pack://application:,,," + "/Resources/TestImages/StressUTest.png");
                        bIImage.EndInit();
                        uFormula.Source = bIImage;

                        uFormula.Width = bIImage.Width;
                        uFormula.Height = bIImage.Height;

                        uFormula.Margin = new Thickness(0, 100, 0, 20);

                        panel.Children.Add(uFormula);

                        TextBox[] textBoxes = new TextBox[8];

                        for (int i = 0; i < textBoxes.Length; i++)
                        {
                            textBoxes[i] = new TextBox();
                            textBoxes[i].HorizontalAlignment = HorizontalAlignment.Left;
                            textBoxes[i].FontSize = 18;
                            textBoxes[i].TextAlignment = TextAlignment.Center;
                            textBoxes[i].MaxLength = 1;
                            textBoxes[i].Width = 25;
                            textBoxes[i].Height = 25;
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            Grid.SetZIndex(textBoxes[i], 1);
                            textBoxes[i].Margin = new Thickness(688 + 57 * i, 32, 0, 0);
                            panel.Children.Add(textBoxes[i]);
                        }
                        for (int i = 5; i < 7; i++)
                        {
                            Grid.SetZIndex(textBoxes[i], 1);
                            textBoxes[i].Margin = new Thickness(462 + 60 * i, 120, 0, 0);
                            panel.Children.Add(textBoxes[i]);
                        }

                    }
                    break;
                case "9":
                    {
                        /// инициализация и помещение поля ввода
                        TextBox threeBox = new TextBox();
                        threeBox.Name = "ThreeBox";
                        threeBox.MaxLength = 3;
                        threeBox.Style = (Style)Application.Current.Resources["SimpleTextBox"];
                        threeBox.Width = 100;
                        threeBox.HorizontalAlignment = HorizontalAlignment.Center;
                        threeBox.Margin = new Thickness(0, 0, 0, 0);

                        panel.Children.Add(threeBox);
                    }
                    break;
            }
        }

        public static void SecondType(Grid grid, int q)
        {
            string[] text = (TestTable.Rows[q].ItemArray[2].ToString()).Split(';');

            StackPanel panel = new StackPanel();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i][0] == '/')
                {
                    /// инициализация и помещение картинки с обозначением элемента
                    System.Windows.Controls.Image schema = new System.Windows.Controls.Image();
                    schema.Width = 300;
                    schema.Source = new BitmapImage(new Uri("pack://application:,,," + text[i]));
                    schema.Margin = new Thickness(0, 0, 0, 20);
                    panel.Children.Add(schema);
                }
                else
                {
                    /// инициализация и помещение заголовка
                    TextBlock header = new TextBlock();
                    header.Text = text[i];
                    header.Style = (Style)Application.Current.Resources["Header"];
                    panel.Children.Add(header);
                }
            }

            string[] vars = (TestTable.Rows[q].ItemArray[3].ToString()).Split(';');
            RadioButton[] radioButtons = new RadioButton[4];

            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtons[i] = new RadioButton();
            }

            /// инициализация и помещение системы stackpanel'ей для красивого вывода radiobutton'ов
            StackPanel radioButtonsHorizontalStack = new StackPanel();
            radioButtonsHorizontalStack.Orientation = Orientation.Horizontal;
            radioButtonsHorizontalStack.HorizontalAlignment = HorizontalAlignment.Center;
            radioButtonsHorizontalStack.Margin = new Thickness(0, 100, 0, 0);
            StackPanel verticalStack1 = new StackPanel();
            verticalStack1.Margin = new Thickness(0, 0, 50, 0);
            verticalStack1.VerticalAlignment = VerticalAlignment.Center;
            StackPanel verticalStack2 = new StackPanel();
            verticalStack2.Margin = new Thickness(50, 0, 0, 0);
            verticalStack2.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < 2; i++)
            {
                /// помещение radiobutton'ов в stackpanel'и
                radioButtons[i].GroupName = "TestGroup";
                radioButtons[i].Style = (Style)Application.Current.Resources["BlueRadioButton"];
                if (vars[i].Length > 20)
                {
                    TextBlock wrapTextBlock = new TextBlock();
                    wrapTextBlock.Text = vars[i];
                    wrapTextBlock.TextWrapping = TextWrapping.Wrap;
                    wrapTextBlock.Width = 600;
                    radioButtons[i].Content = wrapTextBlock;
                }
                else
                {
                    radioButtons[i].Content = vars[i];
                }
                verticalStack1.Children.Add(radioButtons[i]);
            }
            for (int i = 2; i < 4; i++)
            {
                radioButtons[i].GroupName = "TestGroup";
                radioButtons[i].Content = vars[i];
                radioButtons[i].Style = (Style)Application.Current.Resources["BlueRadioButton"];
                verticalStack2.Children.Add(radioButtons[i]);
            }
            radioButtonsHorizontalStack.Children.Add(verticalStack1);
            radioButtonsHorizontalStack.Children.Add(verticalStack2);
            panel.Children.Add(radioButtonsHorizontalStack);
            grid.Children.Add(panel);
        }

        public static void ThirdType(Grid grid, int q)
        {
            /// заголовок и  stackpanel
            string header = (string)TestTable.Rows[q].ItemArray[2];
            StackPanel panel = new StackPanel();
            panel.Name = "panel";

            TextBlock textBlock = new TextBlock();
            textBlock.Text = header;
            textBlock.Style = (Style)Application.Current.Resources["Header"];
            panel.Children.Add(textBlock);

            string[] vars = (TestTable.Rows[q].ItemArray[3].ToString()).Split(';');
            /// инициализация массива с checkBox'ами
            CheckBox[] checkboxes = new CheckBox[vars.Length];

            for (int i = 0; i < checkboxes.Length; i++)
            {
                checkboxes[i] = new CheckBox();
                checkboxes[i].Style = (Style)Application.Current.Resources["BlueCheckBox"];
            }

            /// разные сценарии помещения checkBox'ов в зависимости от их количества
            if (vars.Length == 6)
            {
                StackPanel checkBoxesHorizontalStack = new StackPanel();
                checkBoxesHorizontalStack.Orientation = Orientation.Horizontal;
                checkBoxesHorizontalStack.HorizontalAlignment = HorizontalAlignment.Center;
                checkBoxesHorizontalStack.Margin = new Thickness(0, 100, 0, 0);
                StackPanel verticalStack1 = new StackPanel();
                verticalStack1.Margin = new Thickness(0, 0, 50, 0);
                verticalStack1.HorizontalAlignment = HorizontalAlignment.Center;
                StackPanel verticalStack2 = new StackPanel();
                verticalStack2.Margin = new Thickness(50, 0, 0, 0);
                verticalStack2.HorizontalAlignment = HorizontalAlignment.Center;

                for (int i = 0; i < 3; i++)
                {
                    checkboxes[i].Content = vars[i];
                    verticalStack1.Children.Add(checkboxes[i]);
                }
                for (int i = 3; i < 6; i++)
                {
                    checkboxes[i].Content = vars[i];
                    verticalStack2.Children.Add(checkboxes[i]);
                }
                checkBoxesHorizontalStack.Children.Add(verticalStack1);
                checkBoxesHorizontalStack.Children.Add(verticalStack2);
                panel.Children.Add(checkBoxesHorizontalStack);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    checkboxes[i].Content = vars[i];
                    checkboxes[i].Margin = new Thickness(20, 50, 0, 0);
                    panel.Children.Add(checkboxes[i]);
                }
            }
            grid.Children.Add(panel);
        }

        public static void FirstContinue(int id, Grid grid, int q)
        {
            /// проверки правильности ответов для первого типа вопроса
            switch (id)
            {
                case 5:
                    {
                        /// если поля ввода не равны нужным значениям, то неправильный ответ
                        var multiBox = ((TextBox)grid.Children[3]).Text;
                        var plusBox = ((TextBox)grid.Children[4]).Text;

                        if (multiBox != "*" || plusBox != "+")
                        {
                            ResultArr[q] = false;
                            return;
                        }
                        ResultArr[q] = true;
                    }
                    break;
                case 6:
                    {
                        /// если поля ввода не равны нужным значениям, то неправильный ответ
                        var minusBox = ((TextBox)grid.Children[3]).Text;
                        var multiBox = ((TextBox)grid.Children[4]).Text;

                        if (multiBox != "*" || minusBox != "-")
                        {
                            ResultArr[q] = false;
                            return;
                        }
                        ResultArr[q] = true;
                    }
                    break;
                case 7:
                    {
                        /// если поле ввода не равен нужному значению,, то неправильный ответ
                        var shuntBox = ((TextBox)grid.Children[2]).Text.ToLower();

                        if (shuntBox != "шунт")
                        {
                            ResultArr[q] = false;
                            return;
                        }
                        ResultArr[q] = true;
                    }
                    break;
                case 8:
                    {
                        /// если поля ввода не равны нужным значениям, то неправильный ответ
                        string[] answers = TestTable.Rows[q].ItemArray[4].ToString().Split(';');
                        int j = 0;
                        for (int i = 3; i < 10; i++)
                        {
                            if (((TextBox)grid.Children[i]).Text != answers[j])
                            {
                                ResultArr[q] = false;
                                return;
                            }
                            j++;

                        }

                        ResultArr[q] = true;
                    }
                    break;
                case 9:
                    {
                        /// если поле ввода не равен нужному значению,, то неправильный ответ
                        if (((TextBox)grid.Children[2]).Text != "3")
                        {
                            ResultArr[q] = false;
                            return;
                        }
                        ResultArr[q] = true;
                    }
                    break;
            }
        }

        public static void SecondContinue(Grid grid, int q)
        {
            /// проверки правильности ответов для второго типа вопроса
            string answer = TestTable.Rows[q].ItemArray[4].ToString();

            var panel1 = (StackPanel)grid.Children[1];
            StackPanel panel11;
            try
            {
                panel11 = (StackPanel)((panel1).Children[1]);
            }
            catch
            {
                panel11 = (StackPanel)((panel1).Children[2]);
            }
            var panel120 = (StackPanel)panel11.Children[0];
            int countV1 = panel120.Children.Count;
            var panel121 = (StackPanel)panel11.Children[1];

            for (int i = 0; i < countV1; i++)
            {
                var obj = panel120.Children[i];
                var radioButton = (RadioButton)obj;
                string content;
                try
                {
                    content = (string)radioButton.Content;
                }
                catch
                {
                    content = ((TextBlock)radioButton.Content).Text;
                }
                if (content == answer)
                {
                    if (radioButton.IsChecked == false)
                    {
                        ResultArr[q] = false;
                        return;
                    }
                }
                obj = panel121.Children[i];
                radioButton = (RadioButton)obj;
                if (radioButton.Content.ToString() == answer)
                {
                    if (radioButton.IsChecked == false)
                    {
                        ResultArr[q] = false;
                        return;
                    }
                }
            }
            ResultArr[q] = true;
        }

        public static void ThirdContinue(Grid grid, int q)
        {
            /// проверки правильности ответов для третьего типа вопроса
            string[] answers = TestTable.Rows[q].ItemArray[4].ToString().Split(';');
            var panel1 = (StackPanel)grid.Children[1];
            int count;
            try
            {
                panel1 = (StackPanel)((panel1).Children[1]);
                var panel10 = (StackPanel)panel1.Children[0];
                count = panel10.Children.Count;
                var panel11 = (StackPanel)panel1.Children[1];

                for (int i = 0; i < count; i++)
                {
                    var value = panel10.Children[i];
                    var checkBox = (CheckBox)value;
                    if (answers.Contains(checkBox.Content))
                    {
                        if (checkBox.IsChecked == false)
                        {
                            ResultArr[q] = false;
                            return;
                        }
                    }
                    else
                    {
                        if (checkBox.IsChecked == true)
                        {
                            ResultArr[q] = false;
                            return;
                        }
                    }

                    value = panel11.Children[i];
                    checkBox = (CheckBox)value;

                    if (answers.Contains(checkBox.Content))
                    {
                        if (checkBox.IsChecked == false)
                        {
                            ResultArr[q] = false;
                            return;
                        }
                    }
                    else
                    {
                        if (checkBox.IsChecked == true)
                        {
                            ResultArr[q] = false;
                            return;
                        }
                    }
                }
            }
            catch
            {
                count = ((StackPanel)grid.Children[1]).Children.Count;

                for (int i = 0; i < count; i++)
                {
                    var obj = ((StackPanel)grid.Children[1]).Children[i];
                    try
                    {
                        var checkBox = (CheckBox)obj;
                        if (answers.Contains(checkBox.Content))
                        {
                            if (checkBox.IsChecked == false)
                            {
                                ResultArr[q] = false;
                                return;
                            }
                        }
                        else
                        {
                            if (checkBox.IsChecked == true)
                            {
                                ResultArr[q] = false;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }


                }
            }

            ResultArr[q] = true;
        }
    }
}
