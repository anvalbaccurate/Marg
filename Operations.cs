using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeRecordingManagement
{
    public class Operations
    {
        public int SaveRecords(int TypeOfTaskID,string TaskName,string ToTime,string TimeStatus, int userID,int Timekeeperid,int TimeManagementID,string purpose,string participants,string documentname,string pageno,int matterid)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@TypeOfTaskID", TypeOfTaskID);
            param[1] = new SqlParameter("@TaskName", TaskName);
            param[2] = new SqlParameter("@ToTime", ToTime);
            param[3] = new SqlParameter("@TimeStatus", TimeStatus);// Check 
            param[4] = new SqlParameter("@UserID", userID);// Check 
            param[5] = new SqlParameter("@TimeKeeperId", Timekeeperid);// Check 
            param[6] = new SqlParameter("@TimeManagementID", TimeManagementID);// Check 
            param[7] = new SqlParameter("@Purpose", purpose);// Check 
            param[8] = new SqlParameter("@DocumentName", documentname);// Check 
            param[9] = new SqlParameter("@Participants", participants);// Check 
            param[10] = new SqlParameter("@NoPage", pageno);// Check 
            param[11] = new SqlParameter("@ClientMatterId", matterid);// Check 
            string Error = "";
            DataSet ds = DataBaseAccessLayer.Select("sp_InsertTaskTimeManagementFromDeskTopApplication", param, out Error);
            if (Error == "")
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32( ds.Tables[0].Rows[0][0]);
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

        public DataSet getRecords(int userID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", userID);
         
            string Error = "";
            DataSet ds = DataBaseAccessLayer.Select("sp_getActiveTimerrecords", param, out Error);
            if (Error == "")
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return ds;
                }
            }
            else
            {
                return ds;
            }
        }
      
        public DataSet getClientMatter(int timekeeperid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@timekeeperid", timekeeperid);
            string Error = "";
            DataSet ds = DataBaseAccessLayer.Select("GetMatters", param, out Error);
            if (Error == "")
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return ds;
                }
            }
            else
            {
                return ds;
            }
        }
        public DataSet getUserRecords(string username,string password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", username);
            param[1] = new SqlParameter("@Password", password);

            string Error = "";
            DataSet ds = DataBaseAccessLayer.Select("spValidateUserGetDetails", param, out Error);
            if (Error == "")
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return ds;
                }
            }
            else
            {
                return ds;
            }
        }
        public DataSet getRecordsForPaused(int TimeKeeperId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TimeKeeperID", TimeKeeperId);

            string Error = "";
            DataSet ds = DataBaseAccessLayer.Select("sp_getPausedTimerrecords", param, out Error);
            if (Error == "")
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return ds;
                }
            }
            else
            {
                return ds;
            }
        }
        public void OpenPausedEntry(int userID, int TimeManagementID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@userID", userID);
            param[1] = new SqlParameter("@TaskTimeManagementId", TimeManagementID);
            string Error = "";
           DataBaseAccessLayer.Select("sp_InsertActiveTime", param, out Error);
            
        }
        
    }
}
