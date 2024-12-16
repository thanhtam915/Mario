using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Mario
{
    internal class Database
    {
        // Chuỗi kết nối cơ sở dữ liệu
        private static string con_string = @"Data Source=THANHTAM\SQLEXPRESS;Initial Catalog=Question;Integrated Security=True;Encrypt=False";
        private static SqlConnection connection;
        private static SqlCommand command;

        // Tạo kết nối tới cơ sở dữ liệu
        public static SqlConnection CreateConnection()
        {
            try
            {
                connection = new SqlConnection(con_string);
                connection.Open();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                connection = null;
            }
            return connection;
        }

        // Tạo lệnh SQL
        public static SqlCommand CreateCommand(string commandtext, SqlConnection connection)
        {
            try
            {
                command = new SqlCommand(commandtext, connection);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi tạo command
                Console.WriteLine($"Lỗi tạo command: {ex.Message}");
                command = null;
            }
            return command;
        }

        // Thực thi truy vấn SELECT và trả về DataTable
        public static DataTable SelectQuery(string sql)
        {
            SqlConnection conn = CreateConnection();
            if (conn == null)
            {
                // Nếu không thể kết nối, trả về DataTable rỗng
                return new DataTable();
            }

            command = CreateCommand(sql, conn);
            if (command == null)
            {
                // Nếu không thể tạo command, trả về DataTable rỗng
                return new DataTable();
            }

            SqlDataAdapter adt = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            try
            {
                adt.Fill(dt);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi thực thi truy vấn SQL
                Console.WriteLine($"Lỗi khi thực thi truy vấn: {ex.Message}");
            }
            finally
            {
                // Giải phóng tài nguyên
                command.Dispose();
                adt.Dispose();
                conn.Close();  // Đảm bảo đóng kết nối
            }

            return dt;
        }
    }
}

