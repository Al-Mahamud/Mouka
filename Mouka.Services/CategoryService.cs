using Mauka.Entities;
using Mouka.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouka.Services
{
    public class CategoryService
    {
        public Category Getcategory(int ID)
        {
            using (var context = new MoukaContext())
            {
                return context.Categories.Find(ID);
            }
        }
        public List<Category> Getcategories()
        {
            using (var context = new MoukaContext())
            {
                return context.Categories.ToList();
            }
        }
        public void SaveCategory(Category category)
        {
            using (var context = new MoukaContext())
            {
                context.Categories.Add(category);

                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new MoukaContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new MoukaContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

                var category = context.Categories.Find(ID);
                context.Categories.Remove(category);

                context.SaveChanges();
            }
        }
    }
}
