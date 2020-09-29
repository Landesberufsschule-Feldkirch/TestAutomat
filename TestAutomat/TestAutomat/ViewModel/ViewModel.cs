using SPS_Starter.Commands;
using System.Windows.Input;

namespace TestAutomat.ViewModel
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
        
     
        private ICommand _btnProjektStarten;
        // ReSharper disable once UnusedMember.Global
        public ICommand BtnProjektStarten => _btnProjektStarten ?? (_btnProjektStarten = new RelayCommand(_mainWindow.ProjektStarten));
        
        
    }
}