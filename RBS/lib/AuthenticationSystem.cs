using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;

namespace RBS.Authentication
{
    public class AuthenticationSystem : INotifyPropertyChanged
    {
        #region 1. Fields
        private bool _ActivationStatus;
        private bool _AdminAccountStatus;
        private string _FullName;
        private string _MasterPassword;
        private string _EmployeeID;
        private string _EmailID;
        private int _RowCount;

        private static string Querry_GetAdminAccount;
        private static string Querry_CreateAdminAccount;
        private static string Querry_UpdateAdminAccount;
        private static string Querry_Count;
        private static string Querry_ResetAdmin;

        private static SqlConnection Connection;
        private static SqlCommand Command;
        private static SqlConnectionStringBuilder ConnectionStringBuilder;
        private static SqlDataReader RowReader;

        #endregion

        #region 2. Properties
        public bool ActivationStatus
        {
            get { return _ActivationStatus; }
            set
            {
                if (_ActivationStatus != value)
                    _ActivationStatus = value;
                RaisePropertyChanged("Activation Status");
            }

        }

        public bool AdminAccountStatus
        {
            get { return _AdminAccountStatus; }
            set
            {
                if (_AdminAccountStatus != value)
                    _AdminAccountStatus = value;
                RaisePropertyChanged("Admin Account Status");
            }

        }

        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (_FullName != value)
                    _FullName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string MasterPassword
        {
            get { return _MasterPassword; }
            set
            {
                if (_MasterPassword != value)
                    _MasterPassword = value;
                RaisePropertyChanged("Password");
            }
        }

        public string EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                if (_EmployeeID != value)
                    _EmployeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        public string EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                if (_EmailID != value)
                    _EmailID = value;
                RaisePropertyChanged("EmailID");
            }
        }

        public int RowCount
        {
            get { return _RowCount; }
            set
            {
                if (_RowCount != value)
                    _RowCount = value;
                RaisePropertyChanged("RowCount");
            }
        }

        #endregion

        #region 3. Constructors
        public AuthenticationSystem()
        {
            InitialiseAuthenticationResources();
        }
        #endregion

        #region 4. Events
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region 5. Methods

        public void InitialiseAuthenticationResources()
        {
            //Initializing required fields
            Connection = new SqlConnection();
            Command = new SqlCommand();
            ConnectionStringBuilder = new SqlConnectionStringBuilder();

            //Building the Connection String using Windows Authentication
            ConnectionStringBuilder.Encrypt = true;
            ConnectionStringBuilder.TrustServerCertificate = true;
            ConnectionStringBuilder.IntegratedSecurity = true;
            ConnectionStringBuilder.InitialCatalog = "RBS_Database";

            //Assigning Connection String Builder to Connection Object
            Connection.ConnectionString = ConnectionStringBuilder.ToString();

            //Assigning Connection to the Command
            Command.Connection = Connection;

            //Getting total row count
            try
            {
                Querry_Count = "SELECT COUNT(*) FROM [AdminAccount]";
                Command.CommandText = Querry_Count;
                Connection.Open();
                RowCount = Convert.ToInt32(Command.ExecuteScalar());
                Connection.Close();
            }
            catch(Exception e)
            {
                MessageBoxResult result = MessageBox.Show(e.Message,"Database Error",MessageBoxButton.OK,
                    MessageBoxImage.Error);
                if (result == MessageBoxResult.OK)
                    AppResources.Shutdown();
            }

        }

        public void GetAdminAccount()
        {

            //Initializing Query String
            Querry_GetAdminAccount = "SELECT TOP(1) * FROM [AdminAccount]";

            //Reading from the Database
            Connection.Open();
            Command.CommandText = Querry_GetAdminAccount;
            using (RowReader = Command.ExecuteReader())
            {
                while (RowReader.Read())
                {
                    AdminAccountStatus = (bool)RowReader["Admin Account Status"];
                    ActivationStatus = (bool)RowReader["Activation Status"];
                    if (AdminAccountStatus)
                    {
                        EmployeeID = RowReader["Employee ID"].ToString();
                        MasterPassword = RowReader["Master Password"].ToString();
                        EmailID = RowReader["Email ID"].ToString();
                        break;
                    }
                }
            }
        }

        public void CreateAdminAccount()
        {

            Querry_CreateAdminAccount = "INSERT INTO [AdminAccount]" +"" +
                "([Activation Status],[Full Name],[Master Password],[Email ID],[Employee ID],[Admin Account Status])" +
                "VALUES ('" + ActivationStatus + "','" + FullName + "','" + MasterPassword + "','" + EmailID + "','" + 
                EmployeeID + "','" + AdminAccountStatus + "')";

            RemoveAdminAccount();
            Command.CommandText = Querry_CreateAdminAccount;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        public void UpdateAdminAccount()
        {

            Querry_UpdateAdminAccount = "UPDATE [AdminAccount]" +
                "SET [Activation Status]='" + ActivationStatus +
                "',[Full Name]='" + FullName +
                "',[Master Password]='" + MasterPassword +
                "',[Email ID]='" + EmailID +
                "',[Employee ID]='" + EmployeeID +
                "',[Admin Account Status]='" + AdminAccountStatus + "'";

            RemoveAdminAccount();
            Command.CommandText = Querry_UpdateAdminAccount;
            Command.Connection = Connection;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        public void RemoveAdminAccount()
        {
            Querry_ResetAdmin = "DELETE FROM [AdminAccount]";
            Command.CommandText = Querry_ResetAdmin;
            Command.Connection = Connection;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        #endregion
    }
}
