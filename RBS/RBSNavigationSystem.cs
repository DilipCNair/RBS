using System;

namespace RBS
{
    public class RBSNavigationSystem
    {
        public static event EventHandler SplashScreenRegisterButtonPressed;

        public static void IPressedSplashScreenRegisterButton()
        {
            SplashScreenRegisterButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler SplashScreenModifyButtonPressed;

        public static void IPressedSplashScreenModifyButton()
        {
            SplashScreenModifyButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler SplashScreenLoginButtonPressed;

        public static void IPressedSplashScreenLoginButton()
        {
            SplashScreenLoginButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler RegistrationScreenCancelButtonPressed;

        public static void IPressedRegistrationScreenCancelButton()
        {
            RegistrationScreenCancelButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler RegistrationScreenRegisterButtonClicked;

        public static void IPressedRegistrationScreenRegisterButton()
        {
            RegistrationScreenRegisterButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ModifyViewCancelButtonPressed;

        public static void IPressedModifyViewCancelButton()
        {
            ModifyViewCancelButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ModifyViewDoneButtonPressed;

        public static void IPressedModifyViewDoneButton()
        {
            ModifyViewDoneButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler AuthenticationViewLoginButtonPressed;

        public static void IPressedAuthenticationViewLoginButton()
        {
            AuthenticationViewLoginButtonPressed?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ParentMenuHomeButtonClicked;

        public static void IClickedParentMenuHomeButton()
        {
            ParentMenuHomeButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ParentMenuAlertsButtonClicked;

        public static void IClickedParentMenuAlertsButton()
        {
            ParentMenuAlertsButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ParentMenuReportsButtonClicked;

        public static void IClickedParentMenuReportsButton()
        {
            ParentMenuReportsButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ParentMenuCustomizeButtonClicked;

        public static void IClickedParentMenuCustomizeButton()
        {
            ParentMenuCustomizeButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ParentMenuSettingsButtonClicked;

        public static void IClickedParentMenuSettingsButton()
        {
            ParentMenuSettingsButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }


        public static event EventHandler ParentMenuHelpButtonClicked;

        public static void IClickedParentMenuHelpsButton()
        {
            ParentMenuHelpButtonClicked?.Invoke(typeof(RBSNavigationSystem), EventArgs.Empty);
        }

    }
}
