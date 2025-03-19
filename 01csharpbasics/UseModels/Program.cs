using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using UseModels.Models;
using UseModels.Data;

namespace UseModels
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var myComputer = new Computer()
            {
                MotherBoard = "SDE-TUNO ARD",
                CPUCores = 2,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 599.99m,
                VideoCard = "GTX 1660",
            };

            // instantiate our DatabaseHelper class
            var dbHelper = new DatabaseHelper();

            // check if the database is connected
            string sqlCmd1 = "SELECT GETDATE()";
            var returnCurrentDate = dbHelper.QuerySingleData<DateTime>(sqlCmd1, null);
            Console.WriteLine("" + returnCurrentDate.ToString());

            // INSERT into the database
            // Use parameterized query to prevent SQL injection
            // string sqlCmd2 = @"INSERT INTO TutorialAppSchema.Computer
            //     (MotherBoard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
            //     VALUES(@MotherBoard, @CPUCores, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

            // dbHelper.ExecuteQuery(sqlCmd2, myComputer);
            // Console.WriteLine("Data inserted successfully!");

            // UPDATE the database
            // string sqlCmd = @"UPDATE TutorialAppSchema.Computer SET Motherboard = @MotherBoard WHERE ComputerId = @ComputerId;";
            // dbHelper.ExecuteQuery(sqlCmd, new { MotherBoard = "XYZ-TUNO BARD", ComputerId = 6 });
            // Console.WriteLine("data updated successfully!");

            // SELECT * FROM the database
            string sqlCmd3 = @"SELECT * FROM TutorialAppSchema.Computer;";
            var computers = dbHelper.QueryData<Computer>(sqlCmd3, null); //IEnumerable

            foreach (var computer in computers)
            {
                Console.WriteLine($"{computer.MotherBoard}, {computer.CPUCores}, {computer.HasWifi}, {computer.HasLTE}, {computer.ReleaseDate}, {computer.Price}, {computer.VideoCard} ");
            }

        }

        // Console.WriteLine(myComputer.Motherboard);
        // Console.WriteLine(myComputer.VideoCard);
        // Console.WriteLine(myComputer.HasLTE);
        // Console.WriteLine($"Before Price: ${myComputer.Price}");
        // myComputer.Price = 1099.99m;
        // Console.WriteLine($"After Price: ${myComputer.Price}");
    }

}


