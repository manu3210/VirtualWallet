using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.IntegrationTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(WalletContext db)
        {
            if (db.Users.Any())
                db.RemoveRange(GenerateDataList());

            db.Users.AddRange(GenerateDataList());
        }

        private static List<User> GenerateDataList()
        {
            return new List<User>()
            {
                new User() 
                { 
                    Id = 1,
                    DateOfBirth = DateTime.Now,
                    Dni = "123456",
                    Email = "mail@mail.com",
                    FirstName = "inte",
                    LastName = "test",
                    UserName = "test",
                    Password = "test",
                    AccountList = new List<Account>()
                    { 
                        new Account() 
                        { 
                            Id = 1, 
                            Balance = 1000, 
                            Name = "test", 
                            Type = 1, 
                            UserId = 1,
                            MovementsList = new List<Movements>()
                            {
                                new Movements()
                                {
                                    AccountId = 1, 
                                    Amount = 100, 
                                    Date = DateTime.Now, 
                                    Detail = "test", 
                                    Id = 1, 
                                    remarks = "test"
                                }
                            }
                        }, 
                    }
                },

                new User()
                {
                    Id = 2,
                    DateOfBirth = DateTime.Now,
                    Dni = "12345678",
                    Email = "mail@mal.com",
                    FirstName = "inte2",
                    LastName = "test2",
                    UserName = "test2",
                    Password = "test2",
                    AccountList = new List<Account>()
                    {
                        new Account()
                        {
                            Id = 2,
                            Balance = 2000,
                            Name = "test2",
                            Type = 1,
                            UserId = 2,
                            MovementsList = new List<Movements>()
                            {
                                new Movements()
                                {
                                    AccountId = 2,
                                    Amount = 200,
                                    Date = DateTime.Now,
                                    Detail = "test2",
                                    Id = 2,
                                    remarks = "test2"
                                }
                            }
                        },
                    }
                },

                new User()
                {
                    Id = 3,
                    DateOfBirth = DateTime.Now,
                    Dni = "1238",
                    Email = "mal@mal.com",
                    FirstName = "inte3",
                    LastName = "test3",
                    UserName = "test3",
                    Password = "test3",
                    AccountList = new List<Account>()
                    {
                        new Account()
                        {
                            Id = 3,
                            Balance = 3000,
                            Name = "test3",
                            Type = 2,
                            UserId = 3,
                            MovementsList = new List<Movements>()
                            {
                                new Movements()
                                {
                                    AccountId = 3,
                                    Amount = 300,
                                    Date = DateTime.Now,
                                    Detail = "test3",
                                    Id = 3,
                                    remarks = "test3"
                                }
                            }
                        },
                    }
                }
            };
        }
    }
}
