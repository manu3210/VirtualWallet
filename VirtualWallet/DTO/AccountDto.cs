using System.Collections.Generic;
using VirtualWallet.Models;

namespace VirtualWallet.DTO
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public List<MovementDto> MovementsList { get; set; }

        public AccountDto() { }

        public AccountDto(Account account)
        {
            Id = account.Id;
            Name = account.Name;
            Type = account.Type;
            Balance = account.Balance;
            UserId = account.UserId;
            MovementsList = null;

            if(account.MovementsList != null)
            {
                var list = new List<MovementDto>();
                foreach (Movements movements in account.MovementsList)
                {
                    list.Add(new MovementDto(movements));
                }

                MovementsList = list;
            }
            
        }

        public static Account DtoToEntity(AccountDto dto)
        {
            var account = new Account();

            account.Id = dto.Id;
            account.Name = dto.Name;
            account.Type = dto.Type;
            account.Balance = dto.Balance;
            account.UserId = dto.UserId;
            account.MovementsList = null;

            if(dto.MovementsList != null)
            {
                var list = new List<Movements>();
                foreach (MovementDto movement in dto.MovementsList)
                {
                    list.Add(MovementDto.DtoToEntity(movement));
                }

                account.MovementsList = list;
            }
            

            return account;
        }
    }
}
