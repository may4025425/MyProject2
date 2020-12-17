using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyProject2.Models
{
    public class LabTablesService
    {
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        //LendRecord
        public List<Models.LabTables> GetRecordByCondtioin()
        {
            //sql更改
            DataTable dt = new DataTable();
            string sql = @"select
                            PB.HHISNUM AS '病歷號',
							PRH.PRH_ORDER_DT AS '檢驗日期',
							PB.HNAME AS '姓名',
							PRH.PRH_BED_NO AS '床位號',
                            PRD.PRD_TEST_NAME AS '檢驗項目',
                            PRD.PRD_RESULT_VALUE AS '檢驗值'
                           from
                            PAT_BASIC PB 
                            INNER JOIN PAT_RESULTH PRH ON PB.HHISNUM = PRH.PRH_PAT_ID
                            INNER JOIN PAT_RESULTD PRD ON PRH.PRH_TRX_NUM= PRD.PRD_TRX_NUM";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);


                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.LabSearch(dt);
        }

        private List<LabTables> LabSearch(DataTable dt)
        {
            List<Models.LabTables> result = new List<LabTables>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new LabTables()
                {
                    HHISNUM = row["LabTables"].ToString(),
                    HNAME = row["HNAME"].ToString()
                });
            }
            return result;
        }
    }
}