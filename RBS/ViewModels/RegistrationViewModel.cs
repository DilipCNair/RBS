﻿using RBS.Model;
using RBS.Commands;

namespace RBS.ViewModel
{
    public class RegistrationViewModel : BindableBase
    {
        RegistrationModel RegistrationModelObject;

        public string TextBox_FullName { get; set; }

        public string TextBox_EmployeeID { get; set; }
        
        public string TextBox_EmailID { get; set; }

        public string TextBox_MasterPassword { get; set; }

        public string TextBox_ConfirmMasterPassword { get; set; }

        public MyICommand RegisterCommand { get; private set; }

        public RegistrationViewModel()
        {
            RegistrationModelObject = new RegistrationModel();
            RegisterCommand = new MyICommand(Register);           
        }

        private void Register()
        {
            TextBox_MasterPassword = AppResources.MasterPassword;
            TextBox_ConfirmMasterPassword = AppResources.ConfirmMasterPassword;
            AppResources.MasterPassword = null;
            AppResources.ConfirmMasterPassword = null;
            RegistrationModelObject.FullName = TextBox_FullName;
            RegistrationModelObject.EmployeeID = TextBox_EmployeeID;
            RegistrationModelObject.EmailID = TextBox_EmailID;
            RegistrationModelObject.MasterPassword = TextBox_MasterPassword;
            if(string.Equals(TextBox_MasterPassword,TextBox_ConfirmMasterPassword))
            {
                RegistrationModelObject.Register();
                RBSNavigationSystem.IPressedRegistrationScreenRegisterButton();
            }
        }
    }
}
