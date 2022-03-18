using System;
using System.Collections.Generic;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMovementRepository _movementRepository;

        public AccountService(IAccountRepository accountRepository, IMovementRepository movementRepository)
        {
            _accountRepository = accountRepository;
            _movementRepository = movementRepository;
        }

        public Account Create(Account element)
        {
            return _accountRepository.Create(element);
        }

        public Account Update(int id, Account element)
        {
            return _accountRepository.Update(id, element);
        }

        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }

        public Account Get(int id)
        {
            return _accountRepository.Get(id);
        }

        public List<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public string Transfer(int fromId, int toId, double amount)
        {
            string msj;

            var from = Get(fromId);
            var to = Get(toId);

            if (to == null || from == null)
            {
                msj = "the specified account does not exist";
            }
            else
            {
                if (amount <= from.Balance)
                {
                    msj = _accountRepository.Transfer(from, to, amount);
                    Movements movementFrom = new Movements();
                    movementFrom.AccountId = from.Id;
                    movementFrom.Date = System.DateTime.Now;
                    movementFrom.Detail = "Sent $" + amount + " to account number: " + to.Id;
                    movementFrom.Amount = amount;

                    Movements movementTo = new Movements();
                    movementTo.AccountId = to.Id;
                    movementTo.Date = System.DateTime.Now;
                    movementTo.Detail = "Received $" + amount + " from account number: " + from.Id;
                    movementTo.Amount = amount;

                    _movementRepository.Create(movementFrom);
                    _movementRepository.Create(movementTo);
                }
                else
                {
                    msj = "Not enough money";
                }
            }

            return msj;
        }

        public string AddMoney(int idAcount, double amount, string cardNumber, int monthExp, int yearExp)
        {
            string msj;

            var _account = _accountRepository.Get(idAcount);

            DateTime expiration = new DateTime(yearExp + 2000, monthExp, 1);

            if (DateTime.Now < expiration)
            {
                if (_account != null && amount > 0)
                {
                    msj = _accountRepository.AddMoney(_account, amount);
                    string card = cardNumber.Substring(12, 4);

                    Movements movement = new Movements();
                    movement.AccountId = idAcount;
                    movement.Date = DateTime.Now;
                    movement.Detail = "You put $" + amount + " into account number " + idAcount + " from card finished in " + card;
                    movement.Amount = amount;

                    _movementRepository.Create(movement);
                }
                else
                {
                    msj = "Something went wrong";
                }
            }
            else
            {
                msj = "Your card is not available";
            }

            return msj;
        }
    }
}
