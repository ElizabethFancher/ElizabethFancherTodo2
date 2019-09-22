using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElizabethFancherTodo.Models;

namespace ElizabethFancherTodo.Services
{
    public interface IElizabethFancherTodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
    }
}
