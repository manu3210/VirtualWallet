using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirtualWallet.DTO;
using VirtualWallet.Interfaces;

namespace VirtualWallet.Controllers
{
    public class MovementsController : Controller
    {
        private readonly IMovementService _movementService;

        public MovementsController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = await _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = await _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string remarks)
        {
            var movement = await _movementService.Get(id);

            if(movement == null)
                return NotFound();

            movement.remarks = remarks;

            await _movementService.Update(id, movement);

            return RedirectToAction("Details", "Accounts", new { id = movement.AccountId });
        }
    }
}
