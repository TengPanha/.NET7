using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using POS_API.Authorization;
using POS_API.Entities;
using POS_API.Helpers;
using POS_API.Models.Categories;
using POS_API.Models.Users;

namespace POS_API.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category create(CategoryRequest model);
        void Update(int id, UpdateCategory model);
        void Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Category create(CategoryRequest model)
        {
            // validate
            if (model is null)
                throw new AppException("category is empty or null");

            // map model to new user object
            var category = _mapper.Map<Category>(model);

            // save user
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            var category = getCategory(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return getCategory(id);
        }

        public void Update(int id, UpdateCategory model)
        {
            var category = getCategory(id);

            // validate
            if (category is null)
                throw new AppException("category not found for id :"+id);

            // copy model to user and save
            _mapper.Map(model, category);
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        // helper methods

        private Category getCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new KeyNotFoundException("category not found");
            return category;
        }
    }
}
