using DataAccessLayer.Concrete.Repositories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repo.GetAll();
        }

        public void CategoryAddBL(Category category)
        {
            if (category.CategoryName == "" ||
                category.CategoryName.Length <= 3 ||
                category.CategortyDescription == "" ||
                category.CategoryName.Length >= 51)
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(category);
            }
        }
    }
}
