namespace TestAutomat.AutoTesterViewModel
{
    public class AutoTesterViewModel
    {
        private readonly MainWindow _mainWindow;

        public AutoTesterVisuAnzeigen ViAnzeige { get; set; }
        public AutoTesterViewModel(MainWindow mw)
        {
            _mainWindow = mw;
            ViAnzeige = new AutoTesterVisuAnzeigen();
        }
    }
}