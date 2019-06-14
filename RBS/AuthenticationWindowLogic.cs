using System;
using RBS.ViewModel;

namespace RBS
{
    public class AuthenticationWindowLogic : BindableBase
    {
        #region 1.Fields

        private BindableBase _CurrentViewModelWhole;
        private SplashScreenViewModel _SplashScreenViewModel;
        private RegistrationViewModel _RegistrationViewModel;
        private ModifyViewModel _ModifyViewModel;
        private AuthenticationViewModel _AuthenticationViewModel;

        #endregion

        #region 2.Properties

        public BindableBase CurrentViewModelWhole
        {
            get { return _CurrentViewModelWhole; }
            set { SetProperty(ref _CurrentViewModelWhole, value); }
        }

        #endregion

        #region 3.Constructors
        public AuthenticationWindowLogic()
        {
            InitialiseAllViewModels();
            NavigationEventsHookUp();
            CurrentViewModelWhole = _SplashScreenViewModel;
            
        }
        #endregion

        #region 4. Methods

        private void InitialiseAllViewModels()
        {
            _SplashScreenViewModel = new SplashScreenViewModel();
            _RegistrationViewModel = new RegistrationViewModel();
            _ModifyViewModel = new ModifyViewModel();
            _AuthenticationViewModel = new AuthenticationViewModel();
        }

        private void NavigationEventsHookUp()
        {
            RBSNavigationSystem.SplashScreenRegisterButtonPressed += RBSNavigationSystem_RegisterButtonPressed;
            RBSNavigationSystem.SplashScreenModifyButtonPressed += RBSNavigationSystem_SplashScreenModifyButtonPressed;
            RBSNavigationSystem.SplashScreenLoginButtonPressed += RBSNavigationSystem_SplashScreenLoginButtonPressed;

            RBSNavigationSystem.RegistrationScreenCancelButtonPressed += RBSNavigationSystem_RegistrationScreenCancelButtonPressed;
            RBSNavigationSystem.RegistrationScreenRegisterButtonClicked += RBSNavigationSystem_RegistrationScreenRegisterButtonClicked;

            RBSNavigationSystem.ModifyViewCancelButtonPressed += RBSNavigationSystem_ModifyViewCancelButtonPressed;
            RBSNavigationSystem.ModifyViewDoneButtonPressed += RBSNavigationSystem_ModifyViewDoneButtonPressed;

        }
        #endregion

        #region 5. EventHandlers

        private void RBSNavigationSystem_RegisterButtonPressed(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _RegistrationViewModel;
        }

        private void RBSNavigationSystem_SplashScreenModifyButtonPressed(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _ModifyViewModel;
        }

        private void RBSNavigationSystem_SplashScreenLoginButtonPressed(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _AuthenticationViewModel;
        }



        private void RBSNavigationSystem_RegistrationScreenCancelButtonPressed(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _SplashScreenViewModel;
        }

        private void RBSNavigationSystem_RegistrationScreenRegisterButtonClicked(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _AuthenticationViewModel;
        }

        


        private void RBSNavigationSystem_ModifyViewCancelButtonPressed(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _SplashScreenViewModel;
        }

        private void RBSNavigationSystem_ModifyViewDoneButtonPressed(object sender, EventArgs e)
        {
            CurrentViewModelWhole = _RegistrationViewModel;
        }


        #endregion

    }
}
