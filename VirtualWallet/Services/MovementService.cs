using System.Collections.Generic;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public Movements Create(Movements element)
        {
            return _movementRepository.Create(element);
        }

        public Movements Update(int id, Movements element)
        {
            return _movementRepository.Update(id, element);
        }

        public void Delete(int id)
        {
            _movementRepository.Delete(id);
        }

        public Movements Get(int id)
        {
            return _movementRepository.Get(id);
        }

        public List<Movements> GetAll()
        {
            return _movementRepository.GetAll();
        }
    }
}
