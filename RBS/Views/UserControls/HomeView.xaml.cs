using System.Windows;
using System.Windows.Controls;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        #region 1. Fields

        private static bool ME_Status = false;
        private static bool BL_Status = false;
        private static bool Restrictions_Status = false;
        private static bool MDS_Status = false;
        private static bool TDS_Status = false;
        private static bool AntiMalware_Status = false;
        private static bool PdnE_Status = false;
        private static bool Non_PdnE_Status = false;

        #endregion

        public HomeView()
        {
            InitializeComponent();
            string Username = AppResources.CurrentUser.UserName;
            TextBlock_CurrentUser.Text = " : " + Username;
        }

        private void Button_ME_Clicked(object sender, RoutedEventArgs e)
        {
            if (ME_Status == false)
            {
                Button_ME.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                ME_Status = true;
                ToggleButton_ME.IsChecked = true;
            }
            else
            {
                Button_ME.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                ME_Status = false;
                ToggleButton_ME.IsChecked = false;
            }
            
        }

        private void Button_BH_Clicked(object sender, RoutedEventArgs e)
        {
            if(BL_Status == false)
            {
                Button_BH.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                BL_Status = true;
                ToggleButton_BL.IsChecked = true;
            }
            else
            {
                Button_BH.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                BL_Status = false;
                ToggleButton_BL.IsChecked = false;
            }
        }

        private void Button_TDS_Clicked(object sender, RoutedEventArgs e)
        {
            if (TDS_Status == false)
            {
                Button_TDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                TDS_Status = true;
                ToggleButton_TDS.IsChecked = true;
            }
            else
            {
                Button_TDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                TDS_Status = false;
                ToggleButton_TDS.IsChecked = false;
            }

        }

        private void Button_Restrictions_Clicked(object sender, RoutedEventArgs e)
        {
            if (Restrictions_Status == false)
            {
                Button_Restrictions.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                ToggleButton_Restrictions.IsChecked = true;
                Restrictions_Status = true;
                AppResources.IsRestrictionsMonitoringSet = true;
            }
            else
            {
                Button_Restrictions.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                ToggleButton_Restrictions.IsChecked = false;
                Restrictions_Status = false;
                AppResources.IsRestrictionsMonitoringSet = false;
            }

        }

        private void Button_MDS_Clicked(object sender, RoutedEventArgs e)
        {
            if (MDS_Status == false)
            {
                Button_MDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                ToggleButton_MDS.IsChecked = true;
                MDS_Status = true;
            }
            else
            {
                Button_MDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                ToggleButton_MDS.IsChecked = false;
                MDS_Status = false;

            }
            
        }

        private void Button_AntiMalware_Clicked(object sender, RoutedEventArgs e)
        {
            if (AntiMalware_Status == false)
            {
                Button_AntiMalware.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                AntiMalware_Status = true;
                ToggleButton_AntiMalware.IsChecked = true;
            }
            else if (AntiMalware_Status == true)
            {
                Button_AntiMalware.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                AntiMalware_Status = false;
                ToggleButton_AntiMalware.IsChecked = false;
            }
        }

        private void Button_Production_Clicked(object sender, RoutedEventArgs e)
        {
            if (PdnE_Status == false)
            {
                Button_Production.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                PdnE_Status = true;
            }
            else
            {
                Button_Production.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                PdnE_Status = false;
            }
        }

        private void Button_NonProduction_Clicked(object sender, RoutedEventArgs e)
        {
            if (Non_PdnE_Status == false)
            {
                Button_NonProduction.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
                Non_PdnE_Status = true;
            }
            else
            {
                Button_NonProduction.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
                Non_PdnE_Status = false;
            }
        }

        private void ToggleButton_ME_Checked(object sender, RoutedEventArgs e)
        {
            Button_ME.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
            ME_Status = true;
        }

        private void ToggleButton_ME_Unchecked(object sender, RoutedEventArgs e)
        {
            Button_ME.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
            ME_Status = false;
        }

        private void ToggleButton_BL_Checked(object sender, RoutedEventArgs e)
        {
            Button_BH.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
            BL_Status = true;
        }

        private void ToggleButton_BL_Unchecked(object sender, RoutedEventArgs e)
        {
            Button_BH.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
            BL_Status = false;
        }

        private void ToggleButton_AntiMalware_Checked(object sender, RoutedEventArgs e)
        {
            Button_AntiMalware.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
            AntiMalware_Status = true;
        }

        private void ToggleButton_AntiMalware_UnChecked(object sender, RoutedEventArgs e)
        {
            Button_AntiMalware.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
            AntiMalware_Status = false;
        }

        private void ToggleButton_Restrictions_Checked(object sender, RoutedEventArgs e)
        {
            Button_Restrictions.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
            Restrictions_Status = true;
        }

        private void ToggleButton_Restrictions_UnChecked(object sender, RoutedEventArgs e)
        {
            Button_Restrictions.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
            Restrictions_Status = false;
        }
  
        private void ToggleButton_MDS_Checked(object sender, RoutedEventArgs e)
        {
            Button_MDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
            MDS_Status = true;
        }

        private void ToggleButton_MDS_UnChecked(object sender, RoutedEventArgs e)
        {
            Button_MDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
            MDS_Status = false;
        }

        private void ToggleButton_TDS_Checked(object sender, RoutedEventArgs e)
        {
            Button_TDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsSelected");
            TDS_Status = true;
        }

        private void ToggleButton_TDS_UnChecked(object sender, RoutedEventArgs e)
        {
            Button_TDS.Style = (Style)TryFindResource("StyleHomeScreenButtonsDefault");
            TDS_Status = false;
        }

    }
}
