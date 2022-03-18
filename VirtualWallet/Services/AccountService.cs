using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Account> Create(Account element)
        {
            return await _accountRepository.CreateAsync(element);
        }

        public async Task<Account> Update(int id, Account element)
        {
            return await _accountRepository.UpdateAsync(id, element);
        }

        public async Task Delete(int id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        public async Task<Account> Get(int id)
        {
            return await _accountRepository.GetAsync(id);
        }

        public async Task<List<Account>> GetAll()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<string> Transfer(int fromId, int toId, double amount)
        {
            string msj;

            var from = await Get(fromId);
            var to = await Get(toId);

            if (to == null || from == null)
            {
                msj = "the specified account does not exist";
            }
            else
            {
                if (amount <= from.Balance)
                {
                    msj = await _accountRepository.TransferAsync(from, to, amount);
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

                    await _movementRepository.CreateAsync(movementFrom);
                    await _movementRepository.CreateAsync(movementTo);
                }
                else
                {
                    msj = "Not enough money";
                }
            }

            return msj;
        }

        public async Task<string> AddMoney(int idAcount, double amount, string cardNumber, int monthExp, int yearExp)
        {
            string msj;

            var _account = await _accountRepository.GetAsync(idAcount);

            DateTime expiration = new DateTime(yearExp + 2000, monthExp, 1);

            if (DateTime.Now < expiration)
            {
                if (_account != null && amount > 0)
                {
                    msj = await _accountRepository.AddMoneyAsync(_account, amount);
                    string card = cardNumber.Substring(12, 4);

                    Movements movement = new Movements();
                    movement.AccountId = idAcount;
                    movement.Date = DateTime.Now;
                    movement.Detail = "You put $" + amount + " into account number " + idAcount + " from card finished in " + card;
                    movement.Amount = amount;

                    await _movementRepository.CreateAsync(movement);
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
