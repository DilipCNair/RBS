﻿using System.ComponentModel;
using RBS.Authentication;

namespace RBS.Model
{
    public class ModifyModel : INotifyPropertyChanged
    {
        private string _EmployeeID;

        private string _EmailID;

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

        public ModifyModel()
        {
            //By passing authentication system from MSSQL Server Database
            //AuthenticationSystem Au = new AuthenticationSystem();
            //Au.GetAdminAccount();
            //EmployeeID = Au.EmployeeID;
            //EmailID = Au.EmailID;
            //MasterPassword = Au.MasterPassword;
        }
    }
}
