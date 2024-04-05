using System.Windows.Controls;

namespace Electrophysics
{
    class ManagerNavigator
    {
        public static Frame TheoryFrame { get; set; }
        public static Frame TestFrame { get; set; }
        public ManagerNavigator()
        {
            TheoryFrame = new Frame();
            TestFrame = new Frame();
        }
    }
}
