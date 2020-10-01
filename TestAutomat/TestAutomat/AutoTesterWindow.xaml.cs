using System.Windows;

namespace TestAutomat
{
    public partial class AutoTesterWindow : Window
    {
        private readonly System.IO.DirectoryInfo _aktuellesProjekt;
        public AutoTester.AutoTester AutoTester;

        public AutoTesterWindow(System.IO.DirectoryInfo aktuellesProjekt)
        {
            _aktuellesProjekt = aktuellesProjekt;

            AutoTester = new AutoTester.AutoTester(_aktuellesProjekt);

            InitializeComponent();
        }
    }
}
