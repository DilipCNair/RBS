using System.ComponentModel;
using System.IO;
using System.Reflection;
using RBS.Model.ReportsChildModels;

namespace RBS.ViewModel.ReportsChildViewModels
{
    public class UIM_ReportsViewModel : INotifyPropertyChanged
    {
        private string path = Assembly.GetExecutingAssembly().Location;

        private UIMModel UIMModelObject;

        private string _TextBoxKeylogger;

        private string _TextBoxMouselogger;

        public string TextBoxKeylogger
        {
            get
            {
                return _TextBoxKeylogger;
            }
            set
            {
                if(_TextBoxKeylogger!=value)
                {
                    _TextBoxKeylogger = value;
                    RaisePropertyChanged("TextBoxKeyLogger");
                }
            }
        }

        public string TextBoxMouselogger
        {
            get
            {
                return _TextBoxMouselogger;
            }
            set
            {
                if (_TextBoxMouselogger != value)
                {
                    _TextBoxMouselogger = value;
                    RaisePropertyChanged("TextBoxMouseLogger");
                }
            }
        }

        public UIM_ReportsViewModel()
        {
            UIMModelObject = new UIMModel();
            AppResources.NewKeyStrokesCaptured += AppResources_NewKeyStrokesCaptured;
            AppResources.NewMouseStrokesCaptured += AppResources_NewMouseStrokesCaptured;      
        }

       
        private void AppResources_NewKeyStrokesCaptured(object sender, System.EventArgs e)
        {
            try
            {
                UIMModelObject.KeyStrokesCaptured = File.ReadAllText(path + "Keylogger.txt");
                TextBoxKeylogger = UIMModelObject.KeyStrokesCaptured;
            }
            catch (FileNotFoundException)
            { }
        }
        private void AppResources_NewMouseStrokesCaptured(object sender, System.EventArgs e)
        {
            try
            {
                UIMModelObject.MouseStrokesCaptured = File.ReadAllText(path + "Mouselogger.txt");
                TextBoxMouselogger = UIMModelObject.MouseStrokesCaptured;
            }
            catch (FileNotFoundException)
            { }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
