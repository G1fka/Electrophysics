using System.Windows;

namespace Electrophysics
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StartWindow startWindow = new StartWindow(); // создание экземпляра вашего стартового окна
        }
    }
}
