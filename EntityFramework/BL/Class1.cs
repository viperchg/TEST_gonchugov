using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Context;
using ToDoItemEntities;
namespace BL
{
    public class BusinessLogic
    {
        public MyDbContext eachContext = new MyDbContext();
        public void LoadItems()
        {
            eachContext.ToDoItems.Load();
        }

        public void AddNewItem(string msg)
        {
            ToDoItem itm = new ToDoItem()
            {
                Name = msg,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                IsComplited = false
            };
            eachContext.ToDoItems.Add(itm);
            eachContext.SaveChanges();
            LoadItems();
        }

        public void DeleteItem(int id)
        {
            ToDoItem itm = eachContext.ToDoItems.Find(id);
            eachContext.ToDoItems.Remove(itm);
            eachContext.SaveChanges();
            LoadItems();
        }

        public void EditItem(int id, string name)
        {
            ToDoItem itm = eachContext.ToDoItems.Find(id);
            itm.Name = name;
            itm.Modified = DateTime.Now;
            eachContext.SaveChanges();
        }

        public void CheckItem(int id)
        {

            ToDoItem itm = eachContext.ToDoItems.Find(id);

            if (itm.IsComplited == true)
            {
                itm.IsComplited = false;
            }
            else
                itm.IsComplited = true;

            eachContext.SaveChanges();

        }

      
        public DbSet<ToDoItem> ActiveItems()
        {
            var cntx = new MyDbContext();
            var filteredData = cntx.ToDoItems;
            foreach (var itm in filteredData)
            {
                if (itm.IsComplited == true)
                {
                    filteredData.Remove(itm);
                }
            }
            return filteredData;
        }

        public DbSet<ToDoItem> EndedItems()
        {
            var cntx = new MyDbContext();
            var filteredData = cntx.ToDoItems;
            foreach (var itm in filteredData)
            {
                if (itm.IsComplited == false)
                {
                    filteredData.Remove(itm);
                }
            }
            return filteredData;

        }

        public DbSet<ToDoItem> AllItems()
        {
            var cntx = new MyDbContext();
            var alldata = cntx.ToDoItems;
            foreach (var itm in alldata)
            {

            }
            return alldata;
        }
    }
}
