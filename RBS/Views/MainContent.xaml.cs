using System;
using System.Windows.Controls;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        public MainContent()
        {
            InitializeComponent();
            EventHandlerHookUp();        
        }

        private void EventHandlerHookUp()
        {
            RBSNavigationSystem.ParentMenuHomeButtonClicked += RBSNavigationSystem_ParentMenuHomeButtonClicked;
            RBSNavigationSystem.ParentMenuAlertsButtonClicked += RBSNavigationSystem_ParentMenuAlertsButtonClicked;
            RBSNavigationSystem.ParentMenuReportsButtonClicked += RBSNavigationSystem_ParentMenuReportsButtonClicked;
            RBSNavigationSystem.ParentMenuCustomizeButtonClicked += RBSNavigationSystem_ParentMenuCustomizeButtonClicked;
            RBSNavigationSystem.ParentMenuSettingsButtonClicked += RBSNavigationSystem_ParentMenuSettingsButtonClicked;
            RBSNavigationSystem.ParentMenuHelpButtonClicked += RBSNavigationSystem_ParentMenuHelpButtonClicked;

        }

        private void RBSNavigationSystem_ParentMenuHomeButtonClicked(object sender, EventArgs e)
        {
            TabItemHome.IsSelected = true;
        }

        private void RBSNavigationSystem_ParentMenuAlertsButtonClicked(object sender, EventArgs e)
        {
            TabItemAlerts.IsSelected = true;
        }

        private void RBSNavigationSystem_ParentMenuReportsButtonClicked(object sender, EventArgs e)
        {
            TabItemReports.IsSelected = true;
        }

        private void RBSNavigationSystem_ParentMenuCustomizeButtonClicked(object sender, EventArgs e)
        {
            TabItemCustomize.IsSelected = true;
        }

        private void RBSNavigationSystem_ParentMenuSettingsButtonClicked(object sender, EventArgs e)
        {
            TabItemSettings.IsSelected = true;
        }

        private void RBSNavigationSystem_ParentMenuHelpButtonClicked(object sender, EventArgs e)
        {
            TabItemHelp.IsSelected = true;
        }
    }
}
