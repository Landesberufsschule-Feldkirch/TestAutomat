using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestAutomat
{
    public partial class MainWindow
    {
        public bool TestWindowAktiv { get; set; }
        public DirectoryInfo AktuellesProjekt { get; set; }
        public Model.OrdnerLesen AlleOrdnerLesen;

        private AutoTesterWindow _autoTesterWindow;

        public MainWindow()
        {
            AlleOrdnerLesen = new Model.OrdnerLesen();

            var viewModel = new ViewModel.AutoTesterViewModel(this);

            InitializeComponent();
            DataContext = viewModel;

            ProjekteAnzeigen();

            BtnTestWindow.Visibility = System.Diagnostics.Debugger.IsAttached ? Visibility.Visible : Visibility.Hidden;
        }

        private void ProjekteAnzeigen()
        {
            foreach (var projekt in AlleOrdnerLesen.AlleTestOrdner)
            {
                var rdo = new RadioButton
                {
                    GroupName = "TestProjekte",
                    Name = projekt.Name,
                    FontSize = 14,
                    Content = projekt.Name,
                    VerticalAlignment = VerticalAlignment.Top,                    
                    Tag = projekt
                };
                rdo.Checked += RadioButton_Checked;
                StackPanel.Children.Add(rdo);
            }
        }

        public void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton rb) || !(rb.Tag is DirectoryInfo)) return;
            BtnTestWindow.IsEnabled = true;
            BtnTestWindow.Background=new SolidColorBrush(Colors.LawnGreen);

            AktuellesProjekt = rb.Tag as DirectoryInfo;

            if (AktuellesProjekt == null) return;
            var dateiName = $@"{AktuellesProjekt.FullName}\index.html";

            var htmlSeite = File.Exists(dateiName) ? File.ReadAllText(dateiName) : "--??--";

            var dataHtmlSeite = Encoding.UTF8.GetBytes(htmlSeite);
            var stmHtmlSeite = new MemoryStream(dataHtmlSeite, 0, dataHtmlSeite.Length);

            WebBrowser.NavigateToStream(stmHtmlSeite);
        }

        private void TestWindowOeffnen(object sender, RoutedEventArgs e)
        {
            TestWindowAktiv = true;
            _autoTesterWindow = new AutoTesterWindow(AktuellesProjekt);
            _autoTesterWindow.Show();

        }
    }
}