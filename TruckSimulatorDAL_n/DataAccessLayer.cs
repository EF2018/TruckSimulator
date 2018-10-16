using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TruckSimulatorDAL_n
{
    public class DataAccessLayer
    {
        //Constructor by default
        public DataAccessLayer()
        {

        }

        public DataAccessLayer(string Strcon)
        {
            _strCon = StrCon;
        }

        public string StrCon
        {
            get { return _strCon; }
            set { _strCon = value; }
        }

        /// <summary>
        /// Method use for insert or update or delete
        /// </summary>
        /// <param name="cmdtext">Command Text</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="P">Array of SQL Parameters</param>
        /// <returns>int Number of Rows</returns>
        public int ExNonQuery(string cmdtext, CommandType cmdType=CommandType.Text, SqlParameter[] P=null)
        {
            using (SqlConnection con = new SqlConnection(StrCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdtext, con);
                if (cmdType == CommandType.StoredProcedure)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                if (P != null)
                {
                    for (int i = 0; i < P.Length; i++)
                    {
                        cmd.Parameters.Add(P[i]);
                    }
                }
                //cmd.ExecuteNonQuery();
                var Result = cmd.ExecuteScalar();//ExecuteNonQuery();
                return (int)Result;
            }
        }

        //Read One - All
        /// <summary>
        /// this method use to select, select with Where 
        /// </summary>
        /// <param name="cmdtext">Command Text</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="P">Array of SQL Parameters</param>
        /// <returns>Data Table</returns>
        public DataTable ExReader(string cmdtext, CommandType cmdType = CommandType.Text, SqlParameter[] P = null)
        {
            using (SqlConnection con = new SqlConnection(StrCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdtext, con);
                if (cmdType == CommandType.StoredProcedure)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                if (P != null)
                {
                    for (int i = 0; i < P.Length; i++)
                    {
                        cmd.Parameters.Add(P[i]);
                    }
                }
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        private string _strCon = ConfigurationManager.ConnectionStrings["MyCon2"].ConnectionString;
    }
}
