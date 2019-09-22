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



    }
}
