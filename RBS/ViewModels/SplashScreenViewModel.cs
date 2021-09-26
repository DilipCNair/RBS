using RBS.Commands;
using RBS.Authentication;

namespace RBS.ViewModel
{
    public class SplashScreenViewModel : BindableBase
    {
        private bool _AdminAccountStatus;

        private int _RowCount;


        public bool AdminAccountStatus
        {
            get
            {
                return _AdminAccountStatus;
            }
            set
            {
                if (_AdminAccountStatus != value)
                {
                    _AdminAccountStatus = value;
                }
            }
        }       

        public int RowCount
        {
            get
            {
                return _RowCount;
            }
            set
            {
                if (_RowCount != value)
                {
                    _RowCount = value;
                }
            }
        }

        public MyICommand RegisterCommand { get; set; }

        public MyICommand ModifyCommand { get; private set; }

        public MyICommand LoginCommand { get; private set; }



        public SplashScreenViewModel()
        {
            RegisterCommand = new MyICommand(CanRegister, Register);
            ModifyCommand = new MyICommand(CanModify, Modify);
            LoginCommand = new MyICommand(CanLogin, Login);
        }

        private bool CanRegister()
        {
            AuthenticationSystem AS = new AuthenticationSystem();
            AS.GetAdminAccount();
            AdminAccountStatus = AS.AdminAccountStatus;
            RowCount = AS.RowCount;

            if (RowCount == 0 | AdminAccountStatus == false)
                return true;
            else
                return false;
        } 

        private void Register()
        {
            RBSNavigationSystem.IPressedSplashScreenRegisterButton();
        }

        private bool CanModify()
        {
            if (AdminAccountStatus)
                return true;
            return false;
        }

        private void Modify()
        {
            RBSNavigationSystem.IPressedSplashScreenModifyButton();
        }

        private bool CanLogin()
        {
            if (AdminAccountStatus)
                return true;
            return false;
        }

        private void Login()
        {
            RBSNavigationSystem.IPressedSplashScreenLoginButton();
        }
    }
}
