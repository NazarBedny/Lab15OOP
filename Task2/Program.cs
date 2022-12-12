using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=DESKTOP-RMR3B82\\SQLEXPRESS;Database=StationeryCompany;Trusted_Connection=True;MultipleActiveResultSets=true";
            var choise = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * FROM Goods";

                    SqlDataReader dr = cmd.ExecuteReader();
                    var stationery = new List<Stationery>();
                    while (choise != "END")
                    {
                        while (dr.Read())
                        {
                            stationery.Add(new Stationery
                            {
                                StationeryName = dr["StationeryName"].ToString(),
                                TypeStationery = dr["TypeStationery"].ToString(),
                                CountStationeryEveryType = int.Parse(dr["CountStationeryEveryType"].ToString()),
                                Menegers = dr["Menegers"].ToString(),
                                Cost = int.Parse(dr["Cost"].ToString()),
                                NameCompanyBuyer = dr["NameCompanyBuyer"].ToString(),
                                ManagerWhoSell = dr["ManagerWhoSell"].ToString(),
                                CountOfSellsStationery = int.Parse(dr["CountOfSellsStationery"].ToString()),
                                CostOfOneStationery = int.Parse(dr["CostOfOneStationery"].ToString()),
                                Date = DateTime.Parse(dr["Date"].ToString())

                            });

                        }

                        Console.Write("Enter what you want to see from the listed options: ");
                        Console.WriteLine("All info |All Types | All magers | Max count stationery | Min count stationery | Max cost stationery|Min cost stationery");
                        choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "All info":
                                for (int i = 0; i < stationery.Count; i++)
                                {
                                    Console.WriteLine("Stationery Name: " + stationery[i].StationeryName);
                                    Console.WriteLine("TypeStationery: " + stationery[i].TypeStationery);
                                    Console.WriteLine("CountStationeryEveryType: " + stationery[i].CountStationeryEveryType);
                                    Console.WriteLine("Menegers: " + stationery[i].Menegers);
                                    Console.WriteLine("Cost: " + stationery[i].Cost);
                                    Console.WriteLine("NameCompanyBuyer: " + stationery[i].NameCompanyBuyer);
                                    Console.WriteLine("ManagerWhoSell: " + stationery[i].ManagerWhoSell);
                                    Console.WriteLine("CountOfSellsStationery: " + stationery[i].CountOfSellsStationery);
                                    Console.WriteLine("CostOfOneStationery: " + stationery[i].CostOfOneStationery);
                                    Console.WriteLine("Date: " + stationery[i].Date);
                                    Console.WriteLine(new string('-', 50));
                                }
                                break;
                            case "All Types":
                                for (int i = 0; i < stationery.Count; i++)
                                {
                                    Console.WriteLine("TypeStationery: " + stationery[i].TypeStationery);
                                    Console.WriteLine(new string('-', 50));
                                }
                                break;
                            case "All magers":
                                for (int i = 0; i < stationery.Count; i++)
                                {
                                    Console.WriteLine("Menegers: " + stationery[i].Menegers);
                                    Console.WriteLine(new string('-', 50));
                                }
                                break;
                            case "Max count stationery":
                                Console.WriteLine("Max count stationery is: " + stationery.Max(x => x.CountStationeryEveryType));
                                break;
                            case "Min count stationery":
                                Console.WriteLine("Min count stationery is: " + stationery.Min(x => x.CountStationeryEveryType));
                                break;
                            case "Max cost stationery":
                                Console.WriteLine("Max cost stationery is: " + stationery.Max(x => x.Cost));
                                break;
                            case "Min cost stationery":
                                Console.WriteLine("Min cost stationery is: " + stationery.Max(x => x.Cost));
                                break;
                            default:
                                break;

                        }
                    }
                }
            }
        }
    }
}