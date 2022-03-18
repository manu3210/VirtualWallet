using System;
using VirtualWallet.Models;

namespace VirtualWallet.DTO
{
    public class MovementDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public double amount { get; set; }
        public string remarks { get; set; }
        public int AccountId { get; set; }

        public MovementDto() { }

        public MovementDto(Movements movement)
        {
            Id = movement.Id;
            Date = movement.Date;
            Detail = movement.Detail;
            amount = movement.Amount;
            remarks = movement.remarks;
            AccountId = movement.AccountId;
        }

        public static Movements DtoToEntity(MovementDto dto)
        {
            Movements movement = new Movements();

            movement.Id = dto.Id;
            movement.Date = dto.Date;
            movement.Detail = dto.Detail;
            movement.Amount = dto.amount;
            movement.remarks = dto.remarks;
            movement.AccountId = dto.AccountId;

            return movement;
        }
    }
}
