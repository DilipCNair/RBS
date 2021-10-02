using RBS.Model.ReportsChildModels;
using System.Collections.ObjectModel;
using System.IO;
using System;
using RBS.Agents;
using System.Security.Principal;
using System.Windows;

namespace RBS.Monitoring_Engine
{
    public static class File_System_Monitoring
    {
        private static ObservableCollection<FileSystemReportsModel> _FSMListHolder;

        public static ObservableCollection<FileSystemReportsModel> FSMListHolder
        {
            get
            {
                return _FSMListHolder;
            }
            set
            {
                if(_FSMListHolder!=value)
                {
                    _FSMListHolder = value;
                }
            }
        }

        private static FileSystemWatcher CWatcher;
        private static FileSystemWatcher DWatcher;
        private static FileSystemWatcher EWatcher;
        private static FileSystemWatcher FWatcher;

        public static void InitialiseFileSystemMonitoring()
        {
            FSMListHolder = new ObservableCollection<FileSystemReportsModel>();
            AppResources.FileSystemMonitoringIsOn += AppResources_FileSystemMonitoringIsOn;
            AppResources.FileSystemMonitoringIsOff += AppResources_FileSystemMonitoringIsOff;
            
        }    

        private static void AppResources_FileSystemMonitoringIsOn(object sender, System.EventArgs e)
        {
            StartFSM();
        }

        private static void AppResources_FileSystemMonitoringIsOff(object sender, System.EventArgs e)
        {
            StopFSM();
        }

        private static void StartFSM()
        {
            #region FOR C: Drive
            if (AppResources.C_CheckBox == true)
            {
                CWatcher = new FileSystemWatcher
                {
                    Path = @"C:\\",
                    NotifyFilter = NotifyFilters.Attributes    | NotifyFilters.Attributes |
                                   NotifyFilters.DirectoryName | NotifyFilters.FileName   |
                                   NotifyFilters.LastAccess    | NotifyFilters.LastWrite  |
                                   NotifyFilters.Security      | NotifyFilters.Size,
                    EnableRaisingEvents = true,
                    Filter = "*.*",
                    IncludeSubdirectories = true
                };
                CWatcher.Changed += new FileSystemEventHandler(OnChanged);
                CWatcher.Created += new FileSystemEventHandler(OnCreated);
                CWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                CWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            #endregion

            #region FSW D: Drive
            if (AppResources.D_CheckBox == true)
            {
                DWatcher = new FileSystemWatcher
                {
                    Path = "D:\\",
                    NotifyFilter = NotifyFilters.Attributes    | NotifyFilters.Attributes |
                                   NotifyFilters.DirectoryName | NotifyFilters.FileName   |
                                   NotifyFilters.LastAccess    | NotifyFilters.LastWrite  |
                                   NotifyFilters.Security      | NotifyFilters.Size,
                    EnableRaisingEvents = true,
                    Filter = "*.*",
                    IncludeSubdirectories = true
                };
                DWatcher.Changed += new FileSystemEventHandler(OnChanged);
                DWatcher.Created += new FileSystemEventHandler(OnCreated);
                DWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                DWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            #endregion

            #region FSW E: Drive
            if (AppResources.E_CheckBox == true)
            {
                EWatcher = new FileSystemWatcher
                {
                    Path = "E:\\",
                    NotifyFilter = NotifyFilters.Attributes         | NotifyFilters.Attributes |
                                        NotifyFilters.DirectoryName | NotifyFilters.FileName   |
                                        NotifyFilters.LastAccess    | NotifyFilters.LastWrite  |
                                        NotifyFilters.Security      | NotifyFilters.Size,
                    EnableRaisingEvents = true,
                    Filter = "*.*",
                    IncludeSubdirectories = true
                };
                EWatcher.Changed += new FileSystemEventHandler(OnChanged);
                EWatcher.Created += new FileSystemEventHandler(OnCreated);
                EWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                EWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            #endregion

            #region FSW F: Drive
            if (AppResources.F_CheckBox == true)
            {
                FWatcher = new FileSystemWatcher
                {
                    Path = "F:\\",
                    NotifyFilter = NotifyFilters.Attributes         | NotifyFilters.Attributes |
                                        NotifyFilters.DirectoryName | NotifyFilters.FileName   |
                                        NotifyFilters.LastAccess    | NotifyFilters.LastWrite  |
                                        NotifyFilters.Security      | NotifyFilters.Size,
                    EnableRaisingEvents = true,
                    Filter = "*.*",
                    IncludeSubdirectories = true
                };
                FWatcher.Changed += new FileSystemEventHandler(OnChanged);
                FWatcher.Created += new FileSystemEventHandler(OnCreated);
                FWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                FWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            #endregion
        }      

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string _Size;
            string _Type = null;
            string _FileName;
            string _Permissions;
            string _Author = null;
            if (Path.HasExtension(e.FullPath))
            {
                try
                {
                    _Author = File.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    _Author = Directory.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
                _Type = "Folder";
            }
            if (_Author != null)
                _Author = _Author.Remove(0, 12);
            try
            {
                _Size = new FileInfo(e.FullPath).Length.ToString();
            }
            catch (Exception)
            {
                _Size = "Unknown";
            }
            try
            {
                _Type = new FileInfo(e.FullPath).Extension;
            }
            catch (Exception)
            {
                if (_Type == null)
                    _Type = "Unknown Type";
                else
                    _Type = "Unknown Type";

            }
            try
            {
                _FileName = Path.GetFileName(e.Name);
            }
            catch (Exception)
            {
                _FileName = "Unknown";
            }
            try
            {
                _Permissions = new FileInfo(e.FullPath).IsReadOnly.ToString();
            }
            catch (Exception ex)
            {
                _Permissions = "Unknown";
                GlobalException.No++;
                GlobalException.AllExceptions.Add(new Model.ExceptionModel 
                { 
                    No = GlobalException.No, 
                    Date = DateTime.Now.ToShortDateString(), 
                    Time = DateTime.Now.ToShortTimeString(), 
                    Message = ex.Message
                });
                GlobalException.LogTheException();
            }
            if (AppResources.IsRestrictionsMonitoringSet & AppResources.IsFileSytemRestrictionSet)
                Agent_FileSystem.Analyse(e.FullPath, _Author);
            try
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    FSMListHolder.Add(new FileSystemReportsModel()
                    {
                        Time = DateTime.Now.ToString(),
                        ChangeType = e.ChangeType.ToString() + "...",
                        FileType = _Type,
                        Name = _FileName,
                        Size = _Size.ToString() + " bytes",
                        FullPath = e.FullPath,
                        Permissions = _Permissions,
                        Author = _Author
                    });
                });
            }
            catch (Exception)
            {
            }
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            string _Size;
            string _Type = null;
            string _FileName;
            string _Permissions;
            string _Author = null;
            if (Path.HasExtension(e.FullPath))
            {
                try
                {
                    _Author = File.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    _Author = Directory.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
                _Type = "Folder";
            }
            if(_Author!=null)
                _Author = _Author.Remove(0, 12);
            try
            {
                _Size = new FileInfo(e.FullPath).Length.ToString();
            }
            catch (Exception)
            {
                _Size = "Unknown";
            }
            try
            {
                _FileName = Path.GetFileName(e.Name);
            }
            catch (Exception)
            {
                _FileName = "Unknown";
            }
            try
            {
                _Permissions = new FileInfo(e.FullPath).IsReadOnly.ToString();
            }
            catch (Exception ex)
            {
                _Permissions = "Unknown";
                GlobalException.No++;
                GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = ex.Message });
                GlobalException.LogTheException();
            }
            if (AppResources.IsRestrictionsMonitoringSet & AppResources.IsFileSytemRestrictionSet)
                Agent_FileSystem.Analyse(e.FullPath, _Author);
            try
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    FSMListHolder.Add(new FileSystemReportsModel()
                    {
                        Time = DateTime.Now.ToString(),
                        ChangeType = e.ChangeType.ToString() + "...",
                        FileType = _Type,
                        Name = _FileName,
                        Size = _Size.ToString() + " bytes",
                        FullPath = e.FullPath,
                        Permissions = _Permissions,
                        Author = _Author
                    });
                });
            }
            catch (Exception)
            {
            }
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            string _Size;
            string _Type = null;
            string _FileName;
            string _Permissions;
            string Parent = Directory.GetParent(e.FullPath).ToString();
            string _Author = null;
            if (Path.HasExtension(e.FullPath))
            {
                try
                {
                    _Author = File.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    _Author = Directory.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
                _Type = "Folder";
            }
            if (_Author != null)
                _Author = _Author.Remove(0, 12);
            try
            {
                _Size = new FileInfo(e.FullPath).Length.ToString();
            }
            catch (Exception)
            {
                _Size = "Unknown";
            }
            try
            {
                _Type = new FileInfo(e.FullPath).Extension;
            }
            catch (Exception)
            {
                if (_Type == null)
                    _Type = "Unknown Type";
                else
                    _Type = "Unknown Type";

            }
            try
            {
                _FileName = Path.GetFileName(e.Name);
            }
            catch (Exception)
            {
                _FileName = "Unknown";
            }
            try
            {
                _Permissions = new FileInfo(e.FullPath).IsReadOnly.ToString();
            }
            catch (Exception ex)
            {
                _Permissions = "Unknown";
                GlobalException.No++;
                GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = ex.Message });
                GlobalException.LogTheException();
            }
            if (AppResources.IsRestrictionsMonitoringSet & AppResources.IsFileSytemRestrictionSet)
                Agent_FileSystem.Analyse(e.FullPath, _Author);
            try
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    FSMListHolder.Add(new FileSystemReportsModel()
                    {
                        Time = DateTime.Now.ToString(),
                        ChangeType = e.ChangeType.ToString() + "...",
                        FileType = _Type,
                        Name = _FileName,
                        Size = _Size.ToString() + " bytes",
                        FullPath = e.FullPath,
                        Permissions = _Permissions,
                        Author = _Author
                    });
                });
            }
            catch (Exception)
            {
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            string _Size;
            string _Type = null;
            string _FileName;
            string _Permissions;
            string _Author = null;
            if (Path.HasExtension(e.FullPath))
            {
                try
                {
                    _Author = File.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    _Author = Directory.GetAccessControl(e.FullPath).GetOwner(typeof(NTAccount)).ToString();
                }
                catch (Exception) { }
                _Type = "Folder";
            }
            if (_Author != null)
                _Author = _Author.Remove(0, 12);
            try
            {
                _Size = new FileInfo(e.FullPath).Length.ToString();
            }
            catch (Exception)
            {
                _Size = "Unknown";
            }
            try
            {
                _Type = new FileInfo(e.FullPath).Extension;
            }
            catch (Exception)
            {
                if (_Type == null)
                    _Type = "Unknown Type";
                else
                    _Type = "Unknown Type";

            }
            try
            {
                _FileName = Path.GetFileName(e.Name);
            }
            catch (Exception)
            {
                _FileName = "Unknown";
            }
            try
            {
                _Permissions = new FileInfo(e.FullPath).IsReadOnly.ToString();
            }
            catch (Exception ex)
            {
                _Permissions = "Unknown";
                GlobalException.No++;
                GlobalException.AllExceptions.Add(new Model.ExceptionModel { No = GlobalException.No, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Message = ex.Message });
                GlobalException.LogTheException();
            }
            if (AppResources.IsRestrictionsMonitoringSet & AppResources.IsFileSytemRestrictionSet)
                Agent_FileSystem.Analyse(e.OldFullPath, _Author);
            try
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    FSMListHolder.Add(new FileSystemReportsModel()
                    {
                        Time = DateTime.Now.ToString(),
                        ChangeType = e.ChangeType.ToString() + "...",
                        FileType = _Type,
                        Name = _FileName,
                        Size = _Size.ToString() + " bytes",
                        FullPath = e.OldFullPath,
                        Permissions = _Permissions,
                        Author = _Author
                    });
                });
            }
            catch (Exception)
            { }
        }

        private static void StopFSM()
        {
            try
            {
                if (AppResources.C_CheckBox == true)
                {
                    CWatcher.EnableRaisingEvents = false;
                    CWatcher.Dispose();
                }
                if (AppResources.D_CheckBox == true)
                {
                    DWatcher.EnableRaisingEvents = false;
                    DWatcher.Dispose();
                }
                if (AppResources.E_CheckBox == true)
                {
                    EWatcher.EnableRaisingEvents = false;
                    EWatcher.Dispose();
                }
                if (AppResources.F_CheckBox == true)
                {
                    FWatcher.EnableRaisingEvents = false;
                    AppResources.TurnOffUIM();
                    FWatcher.Dispose();
                }
            }
            catch (Exception)
            { }

        }
    }
}
