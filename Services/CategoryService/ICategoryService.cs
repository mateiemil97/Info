using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
