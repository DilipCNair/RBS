using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using RBS.Model;

namespace RBS.Authentication
{
    public class AuthenticationLogic
    {
        #region 1.Fields
        private static AuthenticationSystem AuthenticationDataModelObject = new AuthenticationSystem();
        private static string QuerryRegister;
        private static SqlConnection Connection = new SqlConnection();
        private static SqlCommand Command = new SqlCommand();
        private static SqlConnectionStringBuilder ConnectionStringBuilder = new SqlConnectionStringBuilder();
        private static SqlDataReader RowReader;
        #endregion

        public AuthenticationLogic()
        {
            //Selecting the View for Authentication
            switch (AuthenticationDataModelObject.ActivationStatus)
            {
                case false: AuthenticationDataModelObject.ActivationStatus = true;
                            LoadRegistrationView();
                            break;

                case true: 
                    switch(AuthenticationDataModelObject.AdminAccountStatus)
                    {
                        case false: LoadRegistrationView();
                                    break;
                        case true: LoadLoginView();
                                   break;
                        default:
                            break;
                    }
                    break;
                default:break;
            }

        }

        public void LoadRegistrationView()
        {
        }

        public void LoadLoginView()
        {


        }
    }
}
