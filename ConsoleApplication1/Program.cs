using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new bool[50];
            var locks = result.Select(x => { return Guid.NewGuid().ToString(); }).ToArray();



            //var host = Dns.GetHostAddresses("awzeus.vw.local");
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();
            sqlParameterList.Add(new SqlParameter("@statement", "select 2"));
            using (SqlConnection conn = new SqlConnection("Data Source=13192F30058\\SQLEXPRESS;Initial Catalog=VW; Persist Security Info = True; User ID = sa; Password = Abc12341234"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DECLARE @i int WHILE EXISTS (SELECT 1 from sysobjects) BEGIN SELECT @i = 1 END";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddRange(sqlParameterList.ToArray());
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                   
                        string count = cmd.ExecuteScalar().ToString();
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw ex;
                    }
                    catch (SqlException ex)
                    {
                        var errorMessages = new StringBuilder();
                        for (int i = 0; i < ex.Errors.Count; i++)
                        {
                            errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + ex.Errors[i].Message + "\n" +
                                "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                "Source: " + ex.Errors[i].Source + "\n" +
                                "Procedure: " + ex.Errors[i].Procedure + "\n");
                        }
                        Console.WriteLine(errorMessages.ToString());
                        Console.ReadLine();
                        var num = ex.Number;
                        throw ex;
                    }     
                }
            }

            //var result = new List<string>();

            //long concurrent_threads = 100;
            //long repeat_count = 100;
            //List<Thread> threads = new List<Thread>();

            //for (int i = 0; i < concurrent_threads; i++)
            //{
            //    Thread t = new Thread(
            //        () =>
            //        {
            //            for (int j = 0; j < repeat_count; j++)
            //            {
            //                var brand = new Random().Next(10);
            //                result.Add(a.Get(brand));
            //            }
            //        });
            //    threads.Add(t);
            //    t.Start();
            //}

            //foreach (Thread t in threads) t.Join();

            //for (int i = 0; i < result.Count; i++)
            //{
            //    if (result[i] != "ok")
            //    {

            //            Console.WriteLine("error");
            //            //throw new Exception("error");


            //    }
            //    else
            //    {
            //        Console.WriteLine("ok");
            //    }
            //}

            Console.ReadLine();
        }
    }

    public class a
    {
        private static int brand;
        private static object obj = new object();
        private static string t(int b)
        {
            if (b != brand)
            {
                return "error";
            }
            else
            {
                return $"b={b} , brand={brand}";
            }
        }

        public static string Get(int b)
        {
            string c;
            lock (obj)
            {
                brand = b;
                c = t(b);
            }

            return c;
        }
    }

}
