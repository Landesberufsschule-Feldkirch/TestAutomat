using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TestAutomat
{
    public partial class MainWindow : Window
    {
        public bool TestWindowAktiv { get; set; }
        public DirectoryInfo AktuellesProjekt { get; set; }
        public TestAutomat.Model.OrdnerLesen AlleOrdnerLesen;

        private TestWindow _testWindow;
        private readonly TestAutomat.ViewModel.AutoTesterViewModel _viewModel;

        public MainWindow()
        {
            AlleOrdnerLesen = new Model.OrdnerLesen();

            _viewModel = new ViewModel.AutoTesterViewModel(this);

            InitializeComponent();
            DataContext = _viewModel;

            ProjekteAnzeigen();

            btnTestWindow.Visibility = System.Diagnostics.Debugger.IsAttached ? Visibility.Visible : Visibility.Hidden;
        }

        private void ProjekteAnzeigen()
        {
            foreach (var Projekt in AlleOrdnerLesen.AlleTestOrdner)
            {
                var rdo = new RadioButton
                {
                    GroupName = "TestProjekte",
                    Name = Projekt.Name,
                    FontSize = 14,
                    Content = Projekt.Name,
                    VerticalAlignment = VerticalAlignment.Top,                    
                    Tag = Projekt
                };
                rdo.Checked += RadioButton_Checked;
                this.StackPanel.Children.Add(rdo);
            }
        }

        public void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton rb && rb.Tag is DirectoryInfo)
            {
                btnTestWindow.IsEnabled = true;

                AktuellesProjekt = rb.Tag as DirectoryInfo;
                
                var dateiName = $@"{AktuellesProjekt.FullName}\index.html";

                var htmlSeite = File.Exists(dateiName) ? File.ReadAllText(dateiName) : "--??--";

                var dataHtmlSeite = Encoding.UTF8.GetBytes(htmlSeite);
                var stmHtmlSeite = new MemoryStream(dataHtmlSeite, 0, dataHtmlSeite.Length);

                WebBrowser.NavigateToStream(stmHtmlSeite);                
            }
        }

        private void TestWindowOeffnen(object sender, RoutedEventArgs e)
        {
            TestWindowAktiv = true;
            _testWindow = new TestWindow();
            _testWindow.Show();

        }
    }
}
