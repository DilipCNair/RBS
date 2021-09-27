using System.ComponentModel;
using RBS.Authentication;

namespace RBS.Model
{
    public class RegistrationModel : INotifyPropertyChanged
    {
        private string _FullName;

        private string _EmployeeID;

        private string _EmailID;

        private string _MasterPassword;


        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                if(_FullName!=value)
                {
                    _FullName = value;
                    RaisePropertyChanged("Full Name");
                }
            }
        }

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

        public string EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                if (_EmailID != value)
                {
                    _EmailID = value;
                    RaisePropertyChanged("Email ID");
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

        public void Register()
        {
            AuthenticationSystem Au = new AuthenticationSystem();
            Au.ActivationStatus = true;
            Au.AdminAccountStatus = true;
            Au.FullName = FullName;
            Au.EmployeeID = EmployeeID;
            Au.MasterPassword = MasterPassword;
            Au.EmailID = EmailID;
            Au.CreateAdminAccount();
        }

    }
}
