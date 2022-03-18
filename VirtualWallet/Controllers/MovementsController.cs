using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VirtualWallet.DTO;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Controllers
{
    public class MovementsController : Controller
    {
        private readonly IMovementService _movementService;

        public MovementsController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        public IActionResult Index()
        {
            var list = new List<MovementDto>();

            foreach (Movements movement in _movementService.GetAll())
            {
                list.Add(new MovementDto(movement));
            }

            return View(list);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,Detail,amount,remarks,AccountId")] MovementDto movements)
        {
            if (ModelState.IsValid)
            {
                _movementService.Create(MovementDto.DtoToEntity(movements));
                return RedirectToAction(nameof(Index));
            }
            return View(movements);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string remarks)
        {
            var movement = _movementService.Get(id);
            movement.remarks = remarks;

            _movementService.Update(id, movement);

            return RedirectToAction("Details", "Accounts", new { id = movement.AccountId });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movementService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
