using RBS.Commands;

namespace RBS.ViewModel
{
    public class SplashScreenViewModel : BindableBase
    {
        private bool _AdminAccountStatus;

        private int _RowCount;

        public bool AdminAccountStatus
        {
            get => _AdminAccountStatus;
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
            get => _RowCount;
            set
            {
                if (_RowCount != value)
                {
                    _RowCount = value;
                }
            }
        }

        public MyICommand RegisterCommand { get; set; }

        public MyICommand ModifyCommand { get; set; }

        public MyICommand LoginCommand { get; set; }

        public SplashScreenViewModel()
        {
            RegisterCommand = new MyICommand(CanRegister, Register);
            ModifyCommand = new MyICommand(CanModify, Modify);
            LoginCommand = new MyICommand(CanLogin, Login);
        }

        private bool CanRegister()
        {
            //By passing authentication system from MSSQL Server Database
            //AuthenticationSystem AS = new AuthenticationSystem();
            //AS.GetAdminAccount();
            //AdminAccountStatus = AS.AdminAccountStatus;
            //RowCount = AS.RowCount;

            //if (RowCount == 0 | AdminAccountStatus == false)
            //    return true;
            //else
            //    return false;

            return true;
        }

        private void Register()
        {
            RBSNavigationSystem.IPressedSplashScreenRegisterButton();
        }

        private bool CanModify()
        {
            //By passing authentication system from MSSQL Server Database
            //if (AdminAccountStatus)
            //    return true;
            //return false;

            return true;
        }

        private void Modify()
        {
            RBSNavigationSystem.IPressedSplashScreenModifyButton();
        }

        private bool CanLogin()
        {
            //By passing authentication system from MSSQL Server Database
            //if (AdminAccountStatus)
            //    return true;
            //return false;

            return true;
        }

        private void Login()
        {
            RBSNavigationSystem.IPressedSplashScreenLoginButton();
        }
    }
}
