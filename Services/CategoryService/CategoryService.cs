using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository;

namespace Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Category.GetAll();
        }
    }
}
