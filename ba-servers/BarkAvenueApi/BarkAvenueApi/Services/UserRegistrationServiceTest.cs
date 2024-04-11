//using System;
//using BarkAvenueApi.Models;
//using BarkAvenueApi.Services;

//namespace BarkAvenueApi.Tests
//{
//    class Program
//    {
//        static async System.Threading.Tasks.Task Main(string[] args)
//        {
//            using (var dbContext = new ApplicationDbContext())
//            {
//                var registrationDTO = new RegistrationDTO
//                {
//                    Username = "example_4_user",
//                    Email = "user@example4.com",
//                    Phone_number = "0988754321",
//                    Password_user = "password121",
//                    Confirm_password = "password121"
//                };

//                var userRegistrationService = new UserRegistrationServiceMarta(dbContext);

//                var result = await userRegistrationService.RegisterUser(registrationDTO);

//                if (result)
//                {
//                    Console.WriteLine("User added successfully!");
//                }
//                else
//                {
//                    Console.WriteLine("User with this email already exists!");
//                }
//            }
//        }
//    }
//}
