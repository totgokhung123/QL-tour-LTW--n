using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public class database
    {
        private string connectionString = @"Data Source=DESKTOP-MLDEV2T\NHATTAN;Initial Catalog=QLTOURLTW;Integrated Security=True";
       // string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        private SqlConnection conn;
        // private string sql;
        private DataTable dt;
        private SqlCommand cmd;
        public database()
        {
            try
            {
                conn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connected failled: " + ex.Message);
            }
        }
        public DataTable SelectData(string sql, List<CustomParameter> lstPara)
        {
            try
            {

                conn.Open();

                // conn.Close();
                //sql = "EXEC SELECTALLNHANVIEN";
                cmd = new SqlCommand(sql, conn);//nội dung được truyền vào
                cmd.CommandType = CommandType.StoredProcedure; // set comand type cho cmd
                foreach (var para in lstPara)// gán các tham số cho cmd
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi load dữ liệu: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataRow Select(string sql)
        {
            try
            {

                conn.Open();

                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thông tin chi tiết: " + ex.Message);
                return null;
            }
            finally
            {

                conn.Close();

            }
        }

        public int ExeCute(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                // string sql,List<CustomParameter> lspara là tham số truyền vào
                // custom đã được định nghĩa

                conn.Open();

                cmd = new SqlCommand(sql, conn);//thuc thi lệnh sql
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in lstPara)//gán tham số cho cmd
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery(); // lấy kết quả thực thi truy vấn
                return (int)rs;//trả về kết quả
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                return -100;
            }
            finally
            {
                // kieemr tra trạng thái kết nối , nếu mở thì tiến hành đóng

                conn.Close();

            }
        }
    }
}
