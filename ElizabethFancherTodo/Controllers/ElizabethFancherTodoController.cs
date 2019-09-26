using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElizabethFancherTodo.Models;
using ElizabethFancherTodo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElizabethFancherTodo.Controllers
{
    public class ElizabethFancherTodoController : Controller
    {
        private readonly IElizabethFancherTodoItemService _todoItemService;
        public ElizabethFancherTodoController(IElizabethFancherTodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();

            // Put items into a model
            var model = new ElizabethFancherTodoViewModel()
            {
                Items = items
            };

            // Render view using the model
            return View(model);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            return RedirectToAction("Index");
        }



    }
}
