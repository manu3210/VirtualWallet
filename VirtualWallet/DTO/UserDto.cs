using System;
using System.Collections.Generic;
using VirtualWallet.Models;

namespace VirtualWallet.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<AccountDto> AccountList { get; set; }

        public UserDto() { }

        public UserDto(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateOfBirth = user.DateOfBirth;
            Dni = user.Dni;
            Email = user.Email;
            UserName = user.UserName;
            Password = user.Password;

            var list = new List<AccountDto>();

            if (user.AccountList != null)
            {
                foreach (Account account in user.AccountList)
                {
                    list.Add(new AccountDto(account));
                }
            }

            AccountList = list;
        }

        public static User DtoToEntity(UserDto dto)
        {
            var user = new User();

            user.Id = dto.Id;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.DateOfBirth = dto.DateOfBirth;
            user.Dni = dto.Dni;
            user.Email = dto.Email;
            user.UserName = dto.UserName;
            user.Password = dto.Password;

            var list = new List<Account>();

            if (dto.AccountList != null)
            {
                foreach (AccountDto account in dto.AccountList)
                {
                    list.Add(AccountDto.DtoToEntity(account));
                }
            }

            user.AccountList = list;

            return user;
        }
    }
}
