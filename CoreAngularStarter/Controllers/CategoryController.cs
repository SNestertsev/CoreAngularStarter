using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAngularStarter.Data;
using CoreAngularStarter.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAngularStarter.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly GalleryContext _context;

        public CategoryController(GalleryContext context)
        {
            _context = context;
        }

        // GET: api/category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(cat => cat.ID == id);
        }

        // GET api/category/items/5
        [HttpGet("items/{id}")]
        public async Task<IEnumerable<CraftItem>> GetItems(int id)
        {
            return await _context.CategoryItems
                .Where(ci => ci.CategoryID == id)
                .Select(ci => ci.CraftItem)
                .ToListAsync();
        }

        // POST api/category
        [HttpPost]
        public async Task<Category> Post([FromBody]Category value)
        {
            var newEntity = _context.Categories.Add(value);
            await _context.SaveChangesAsync(true);
            return newEntity.Entity;
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<Category> Put(int id, [FromBody]Category value)
        {
            var updatedEntity = _context.Categories.Update(value);
            await _context.SaveChangesAsync(true);
            return updatedEntity.Entity;
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Category category = _context.Categories.SingleOrDefault(cat => cat.ID == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChangesAsync(true);
            }
        }
    }
}
