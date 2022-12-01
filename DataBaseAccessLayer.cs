using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeRecordingManagement
{
    public class DataBaseAccessLayer
    {

        /// <summary>
        /// ConStr is Variable which stores Connection String from Web Cconfig file.
        /// </summary>
        //public static string ConStr = @"Data Source=DESKTOP-MET2U5M\ULTIMATE;Initial Catalog=esh_db;Integrated Security=True";
        public static string ConStr = ConfigurationManager.AppSettings["sqldb"];
        //public static string ConStr = @"Data Source=13.92.131.114;Initial Catalog=LIVE_WILLISLAWGROUP;Persist Security Info=True;User ID=alb2user;Password=admin@alb2";
        //public static string ConStr = @"Data Source=13.92.131.114;Initial Catalog=LIVE_TWORIVERS;User ID=alb2user;Password=admin@alb2";

        #region Check Database Connection
        /// <summary>
        /// Check Database Connection
        /// </summary>
        /// <returns>String value for Success /Error Messages </returns>
        public static string checkConnection()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConStr))
                {
                    try
                    {
                        cn.Open();
                        return "";
                    }
                    catch (Exception ex)
                    { return ex.Message; }
                    finally
                    {
                        cn.Close();
                    }
                }

            }
            catch (Exception ex)
            { return ex.Message; }
        }
        #endregion

        #region insert data to database
        ///<summary>This function is usefull for insert/Update data
        ///</summary>
        ///<param name="storedProcedure">
        /// Write Stored Procedure Name
        /// </param>
        /// <param name="param">
        /// Pass SqlParameter array
        /// </param>
        /// <param name="result">
        /// Get boolean value for record insert or not
        /// </param>
        /// <param name="error">
        /// Get detailed error description from this parameter
        /// </param>
        public static void InsertUpdate(string storedProcedure, SqlParameter[] param, out bool result, out string error)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                        error = "";
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                { cn.Close(); }
            }
        }
        /// <summary>
        /// This function is overloaded method. which supports Insert/ Update with database.
        /// </summary>
        /// <param name="storedProcedure">Write Stored Procedure Name</param>
        /// <param name="param">Pass SqlParameter array</param>
        /// <param name="result">Get boolean value for record insert or not</param>
        public static void InsertUpdate(string storedProcedure, SqlParameter[] param, out bool result)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                    //  InsertError(null, MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace.ToString(), ex.Source.ToString(), "Framework", null, storedProcedure, -1);
                }
                finally
                { cn.Close(); }
            }
        }
        /// <summary>
        /// This function is overloaded method. which supports Insert/ Update with database.
        /// </summary>
        /// <param name="storedProcedure">Write Stored Procedure Name</param>
        /// <param name="param">Pass SqlParameter array</param>
        public static void InsertUpdate(string storedProcedure, SqlParameter[] param)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                { cn.Close(); }
            }
        }

        #endregion

        #region select dataset from database

        public static int ExecuteNonQuery(string statement)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(statement, cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.Text;
                        return cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        /// <summary>
        /// This function using for select dataset from database and return value in dataset
        /// </summary>
        /// <param name="storedProcedure">Write stored procedure name</param>
        /// <param name="param">Pass parameter if any otherwise pass NULL</param>
        /// <param name="result">Return result value in true/false, If dataset null or no any table contain then result return false value</param>
        /// <param name="error">Get detailed error description in this parameter</param>
        /// <returns>Dataset Object</returns>
        public static DataSet Select(string storedProcedure, SqlParameter[] param, out bool result, out string error)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            // error = CommonMessage.NoError;
                            result = true;
                            error = null;
                            return ds;
                        }
                        else
                        {
                            // error = CommonMessage.NullDataSet;
                            result = false;
                            error = null;
                            return ds;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        /// <summary>
        /// This function using for select dataset from database and return value in dataset
        /// </summary>
        /// <param name="storedProcedure">Write stored procedure name</param>
        /// <param name="param">Pass parameter if any otherwise pass NULL</param>
        /// <param name="result">Return result value in true/false, If dataset null or no any table contain then result return false value</param>
        /// <returns>Dataset Object</returns>
        public static DataSet Select(string storedProcedure, SqlParameter[] param, out bool result)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            result = true;
                            return ds;
                        }
                        else
                        {
                            result = false;
                            return ds;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        /// <summary>
        /// This function using for select dataset from database and return value in dataset
        /// </summary>
        /// <param name="storedProcedure">Write stored procedure name</param>
        /// <param name="param">Pass parameter if any otherwise pass NULL</param>
        /// <returns>Dataset Object</returns>
        public static DataSet Select(string storedProcedure, SqlParameter[] param)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            return ds;
                        }
                        else
                        {
                            return ds;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        public static DataSet Select(string storedProcedure, SqlParameter[] param, out string error)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            error = "";
                            return ds;
                        }
                        else
                        {
                            error = "";
                            return ds;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        #endregion

        #region select dataTable from database
        #endregion
        /// <summary>
        /// This function using for select datatable from database and return value in dataset
        /// </summary>
        /// <param name="storedProcedure">Write stored procedure name</param>
        /// <param name="param">Pass parameter if any otherwise pass NULL</param>
        /// <param name="result">Return result value in true/false, If dataset null or no any table contain then result return false value</param>
        /// <param name="error">Get detailed error description in this parameter</param>
        /// <param name="tableIndexNumber">Pass table index number, its starting from 0[Zero]</param>
        /// <returns>Datatable Object</returns>
        public static DataTable Select(string storedProcedure, SqlParameter[] param, int tableIndexNumber, out bool result, out string error)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables.Count > tableIndexNumber)
                            {
                                error = "";
                                result = true;
                                return ds.Tables[tableIndexNumber];
                            }
                            else
                            {
                                error = "";
                                result = false;
                                return new DataTable();
                            }
                        }
                        else
                        {
                            error = "";
                            result = false;
                            return new DataTable();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        /// <summary>
        /// This function using for select datatable from database and return value in dataset
        /// </summary>
        /// <param name="storedProcedure">Write stored procedure name</param>
        /// <param name="param">Pass parameter if any otherwise pass NULL</param>
        /// <param name="result">Return result value in true/false, If dataset null or no any table contain then result return false value</param>
        /// <param name="tableIndexNumber">Pass table index number, its starting from 0[Zero]</param>
        /// <returns>Datatable Object</returns>
        public static DataTable Select(string storedProcedure, SqlParameter[] param, int tableIndexNumber, out bool result)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables.Count > tableIndexNumber)
                            {
                                result = true;
                                return ds.Tables[tableIndexNumber];
                            }
                            else
                            {
                                result = false;
                                return new DataTable();
                            }
                        }
                        else
                        {
                            result = false;
                            return new DataTable();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        /// <summary>
        /// This function using for select datatable from database and return value in dataset
        /// </summary>
        /// <param name="storedProcedure">Write stored procedure name</param>
        /// <param name="param">Pass parameter if any otherwise pass NULL</param>
        /// <param name="tableIndexNumber">Pass table index number, its starting from 0[Zero]</param>
        /// <returns>Datatable Object</returns>
        public static DataTable Select(string storedProcedure, SqlParameter[] param, int tableIndexNumber)
        {
            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (SqlParameter p in param)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        DataSet ds = new DataSet();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables.Count > tableIndexNumber)
                            {
                                return ds.Tables[tableIndexNumber];
                            }
                            else
                            {
                                return new DataTable();
                            }
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

    }
}
