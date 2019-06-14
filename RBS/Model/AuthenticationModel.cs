using System.ComponentModel;
using RBS.Authentication;

namespace RBS.Model
{
    public class AuthenticationModel : INotifyPropertyChanged
    {
        private string _EmployeeID;

        private string _MasterPassword;

        public string EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                if (_EmployeeID != value)
                {
                    _EmployeeID = value;
                    RaisePropertyChanged("Employee ID");
                }
            }
        }

        public string MasterPassword
        {
            get
            {
                return _MasterPassword;
            }
            set
            {
                if (_MasterPassword != value)
                {
                    _MasterPassword = value;
                    RaisePropertyChanged("Master Password");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string Property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        public AuthenticationModel()
        {
            AuthenticationSystem Au = new AuthenticationSystem();
            Au.GetAdminAccount();
            EmployeeID = Au.EmployeeID;
            MasterPassword = Au.MasterPassword;
        }
    }
}
