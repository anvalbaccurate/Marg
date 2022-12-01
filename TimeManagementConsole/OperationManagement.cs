using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementConsole
{
   public class OperationManagement
    {
        public int checkAvailabilityForOpenApplication(int ApplicationUserID, int ApplicationTimeKeeperID)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ApplicationUserID", ApplicationUserID);
            param[1] = new SqlParameter("@ApplicationTimeKeeprID", ApplicationTimeKeeperID);
            param[2] = new SqlParameter("@IsPending", 0);
            param[3] = new SqlParameter("@Flag", 3);// Check 
            string Error = "";
            DataSet ds = DataBaseAccessLayer.Select("sp_CreateUserRequestForDeskTop", param, out Error);
            if (Error == "")
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

    }
}
