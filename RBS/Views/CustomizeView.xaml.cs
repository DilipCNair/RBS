using RBS.Model.ReportsChildModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace RBS.Views
{
    /// <summary>
    /// Interaction logic for CustomizeView.xaml
    /// </summary>
    public partial class CustomizeView : System.Windows.Controls.UserControl
    {
        string _File;
        string _Directory;
             
        public CustomizeView()
        {
            InitializeComponent();
            Restrictions.InitialiseRestrictions();
            Button_Load.IsEnabled = false;
            Button_SelectAll.IsEnabled = false;
            Button_AddToSignature.IsEnabled = false;
            GlobalResources.GettingAllProcesses += GlobalResources_GettingAllProcesses;
        }

        private void GlobalResources_GettingAllProcesses(object sender, System.EventArgs e)
        {
            Button_Load.IsEnabled = true;
            Button_SelectAll.IsEnabled = true;
            Button_AddToSignature.IsEnabled = true;
        }

        private void Button_AddFile_Clicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ++Restrictions.ID;
                _File = openFileDialog.FileName;
                Restrictions.AllFSC_Restritions.Add(new FSC_Restrictions { ID = Restrictions.ID, File = _File, Directory = "null",FileORDty=_File });             
            }
        }

        private void Button_AddDirectory_Clicked(object sender, RoutedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    ++Restrictions.ID;
                    _Directory = folderDialog.SelectedPath;
                    Restrictions.AllFSC_Restritions.Add(new FSC_Restrictions { ID = Restrictions.ID, File = "null", Directory = _Directory,FileORDty=_Directory });
                    foreach (string file in Directory.GetFiles(_Directory))
                    {
                        ++Restrictions.ID;
                        Restrictions.AllFSC_Restritions.Add(new FSC_Restrictions { ID = Restrictions.ID, File = file, Directory = "null", FileORDty=file });
                    }
                    DirSearch(_Directory);
                }
            }
        }

        private void DirSearch(string Path)
        {
            foreach (string Dir in Directory.GetDirectories(Path))
            {
                ++Restrictions.ID;
                Restrictions.AllFSC_Restritions.Add(new FSC_Restrictions { ID = Restrictions.ID, File = "null", Directory = Dir,FileORDty=Dir });
                DirSearch(Dir);
                foreach (string file in Directory.GetFiles(Dir))
                {
                    ++Restrictions.ID;
                    Restrictions.AllFSC_Restritions.Add(new FSC_Restrictions { ID = Restrictions.ID, File = file, Directory = "null",FileORDty=file });
                }
            }       
        }

        private void Textbox_Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Datagrid_Process.ItemsSource);
                view.Filter = UserFilter;
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Textbox_Search.Text))
                return true;
            else
                return ((item as ProcessReportsModel).Name.IndexOf(Textbox_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Button_Load_Clicked(object sender, RoutedEventArgs e)
        {
            Button_Load.Content = "Refresh";
        }
    }
}
