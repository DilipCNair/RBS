using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBS.Model;
using RBS.Commands;

namespace RBS.ViewModel
{
    public class ModifyViewModel : BindableBase
    {
        public string TextBox_EmployeeID { get; set; }

        public string TextBox_EmailID { get; set; }

        public string TextBox_MasterPassword { get; set; }

        public MyICommand ContinueCommand { get; private set; }


        ModifyModel ModifyModelObject;
        public ModifyViewModel()
        {
            ModifyModelObject = new ModifyModel();
            ContinueCommand = new MyICommand(Continue);
        }

        private void Continue()
        {
            TextBox_MasterPassword = GlobalResources.MasterPassword;
            GlobalResources.MasterPassword = null;
            if(string.Equals(ModifyModelObject.EmployeeID,TextBox_EmployeeID) & string.Equals(ModifyModelObject.EmailID,TextBox_EmailID) & string.Equals(ModifyModelObject.MasterPassword,TextBox_MasterPassword))
            {
                RBSNavigationSystem.IPressedModifyViewDoneButton();
            }
        }
    }
}
