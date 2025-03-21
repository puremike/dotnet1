﻿using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using UseModels.Models;
using UseModels.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using UseModels.ReadWrite;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace UseModels
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var myComputer = new Computer()
            {
                MotherBoard = "TYZ-TANGO ARM",
                CPUCores = 4,
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = DateTime.Now,
                Price = 1599.99m,
                VideoCard = "NVIDIA RTX 4060 Ti",
            };

            // instantiate our DBHelperDapper class
            var dbHelper = new DBHelperDapper(config);

            // instantiate DBHelperEF class -entity framework
            var dbHelperEF = new DBHelperEF(config);

            // dbHelperEF.Add(myComputer); // insert a row to the database
            // dbHelperEF.SaveChanges();

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
            // string sqlCmd3 = @"SELECT * FROM TutorialAppSchema.Computer;";
            // var computers = dbHelper.QueryData<Computer>(sqlCmd3, null); //IEnumerable

            // foreach (var computer in computers)
            // {
            //     Console.WriteLine($"{computer.MotherBoard}, {computer.CPUCores}, {computer.HasWifi}, {computer.HasLTE}, {computer.ReleaseDate}, {computer.Price}, {computer.VideoCard} ");
            // }


            // null-coalescing (??), because it guarantees computersEF is never null, making the code safer
            var computersEF = dbHelperEF.Computer?.ToList() ?? new List<Computer>();//IEnumerable converted to a List

            // foreach (var computer in computersEF)
            // {
            //     Console.WriteLine($"{computer.MotherBoard}, {computer.CPUCores}, {computer.HasWifi}, {computer.HasLTE}, {computer.ReleaseDate}, {computer.Price}, {computer.VideoCard} ");
            // }


            // string content = "I'm a DevOps and Backend Engineer. How can I help you today?\n";
            // var readWrite = new FileRW();
            // readWrite.ReadAndWriteFile(content);

            // Console.WriteLine(myComputer.MotherBoard);
            // Console.WriteLine(myComputer.VideoCard);
            // Console.WriteLine(myComputer.HasLTE);
            // Console.WriteLine($"Before Price: ${myComputer.Price}");
            // myComputer.Price = 1099.99m;
            // Console.WriteLine($"After Price: ${myComputer.Price}");

            string readCJson = File.ReadAllText("Computers.json");
            // Console.WriteLine(readCJson);

            var computerDes = JsonConvert.DeserializeObject<IEnumerable<Computer>>(readCJson);

            if (computerDes != null)
            {
                foreach (var computer in computerDes)
                {
                    // Use parameterized query to prevent SQL injection
                    // string sqlCmd2 = @"INSERT INTO TutorialAppSchema.Computer
                    //     (MotherBoard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
                    //     VALUES(@MotherBoard, @CPUCores, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

                    // dbHelper.ExecuteQuery(sqlCmd2, computer);
                }
                // Console.WriteLine("Data inserted successfully!");
            }

            var options = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string ComputerJSONCopy = JsonConvert.SerializeObject(computerDes, options);
            // File.WriteAllText("ComputerJSONCopy.txt", ComputerJSONCopy);

            // using Automapper package to map destination to source
            var mapper = new Mapper(new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<ComputerSnake, Computer>()
                .ForMember(destination => destination.MotherBoard, options => options.MapFrom(source => source.motherboard))
                .ForMember(destination => destination.CPUCores, options => options.MapFrom(source => source.cpu_cores))
                .ForMember(destination => destination.VideoCard, options => options.MapFrom(source => source.video_card))
                .ForMember(destination => destination.HasLTE, options => options.MapFrom(source => source.has_lte))
                .ForMember(destination => destination.HasWifi, options => options.MapFrom(source => source.has_wifi))
                .ForMember(destination => destination.Price, options => options.MapFrom(source => source.price))
                .ForMember(destination => destination.ReleaseDate, options => options.MapFrom(source => source.release_date));
            }));

            string computerSnakeJSON = File.ReadAllText("ComputersSnake.json");
            var deserializedComputerSnakeJSON = JsonConvert.DeserializeObject<IEnumerable<ComputerSnake>>(computerSnakeJSON);

            if (deserializedComputerSnakeJSON != null)
            {
                var mappedJSON = mapper.Map<IEnumerable<Computer>>(deserializedComputerSnakeJSON);

                foreach (var computer in mappedJSON)
                {
                    // Console.WriteLine(computer.MotherBoard);
                }
            }

            // using System.Text.Json.Serialization for mapping
            var deserializedComputerSnakeJSONSystem = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computerSnakeJSON);

            if (deserializedComputerSnakeJSONSystem != null)
            {
                foreach (var computer in deserializedComputerSnakeJSONSystem)
                {
                    // Console.WriteLine(computer.MotherBoard);
                }
            }

        }



    }

}


