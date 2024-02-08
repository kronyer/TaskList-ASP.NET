using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class ToDoService
    {
        private readonly ToDoContext _context;

        public ToDoService(ToDoContext _context)
        {
            this._context = _context;
        }
        public async Task<List<ToDo>> GetActiveToDosAsync()
        {
            var list = await _context.ToDos
                .Where(x => !x.Done)
                .OrderByDescending(x => x.Priority > 0)
                .ThenBy(x => x.Priority)
                .ToListAsync();
            return list;
        }

        public async Task NewToDoAsync()
        {
           
            _context.ToDos.Add(new ToDo
            {
                Title = $"Tarefa {DateTime.Now}",
                Description = $"Tarefa {DateTime.Now}",
                CategoryId = 1,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<ToDo> UpdateAsync(ToDo toDo)
        {
            _context.Update(toDo);
            await _context.SaveChangesAsync();
            return toDo;

        }

        public async Task RemoveAsync(ToDo toDo)
        {
            _context.Remove(toDo);
            await _context.SaveChangesAsync();

        }
    }
}
