using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Movements> Create(Movements element)
        {
            return await _movementRepository.CreateAsync(element);
        }

        public async Task<Movements> Update(int id, Movements element)
        {
            return await _movementRepository.UpdateAsync(id, element);
        }

        public async Task Delete(int id)
        {
            await _movementRepository.DeleteAsync(id);
        }

        public async Task<Movements> Get(int id)
        {
            return await _movementRepository.GetAsync(id);
        }

        public async Task<List<Movements>> GetAll()
        {
            return await _movementRepository.GetAllAsync();
        }
    }
}
