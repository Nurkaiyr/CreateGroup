using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groups
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = @"Data Source=A-305-04;
                            Initial Catalog=Quix;
                            Integrated Security=True";

            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Ошибка подключения:{0}", se.Message);
                return;
            }

            Console.WriteLine("Соедение успешно произведено");

            SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
        "Groups (ID int not null" + ", name char(60) not null," + ")", conn);
            //посылаем запрос
            try
            {
                cmdCreateTable.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка при создании таблицы");
                return;
            }

            Console.WriteLine("Таблица создана успешно");
            //закрвываем соединение
            conn.Close();
            conn.Dispose();
        }
    }
}
