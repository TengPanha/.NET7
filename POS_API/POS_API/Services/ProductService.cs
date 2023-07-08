using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS_API.Entities;
using POS_API.Helpers;
using POS_API.Models.Categories;
using POS_API.Models.Customers;
using POS_API.Models.Products;
using POS_API.Models.Suppliers;
using System.Collections;

namespace POS_API.Services
{
    public interface IProductService
    {
        IEnumerable<ProductReponse> GetAll();
        ProductReponse GetById(int id);
        ProductReponse create(ProductRequest model);
        void Update(int id, UpdateProduct model);
        void Delete(int id);
    }
    public class ProductService : IProductService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ProductReponse create(ProductRequest model)
        {
            // validate
            if (model is null)
                throw new AppException("category is empty or null");

            // map model to new product object
            var product = _mapper.Map<Product>(model);
            var response = new ProductReponse
            {
                Id=product.Id,
                Name=product.Name,
                Price=product.Price,
                Quantity=product.Quantity,
                TotalAmount = product.TotalAmount,
                Note = product.Note,
                IsActive = product.IsActive,
                Category = _mapper.Map<CategoryRequest>(_context.Categories.FirstOrDefault(c=>c.IsActive.Equals(true) && c.Id.Equals(product.CategoryId))),
                Supplier=_mapper.Map<SupplierRequest>(_context.Suppliers.FirstOrDefault(s => s.IsActive.Equals(true) && s.Id.Equals(product.SupplierId)))
            };
            // save product
            _context.Products.Add(product);
            _context.SaveChanges();
            return response;
        }

        public void Delete(int id)
        {
            var product = getProduct(id);
            product.IsActive = false;
            _context.SaveChanges();
        }

        public IEnumerable<ProductReponse> GetAll()
        {
            List<ProductReponse> productReponses=new List<ProductReponse>();
            List<Product> products = _context.Products.Where(p => p.IsActive == true).ToList();
            foreach (var pro in products)
            {
                var res = new ProductReponse
                {
                   Id= pro.Id,
                   Name= pro.Name,
                   Price= pro.Price,
                   Quantity = pro.Quantity,
                   TotalAmount = pro.TotalAmount,
                   IsActive= pro.IsActive,
                   Note = pro.Note,
                   Category = _mapper.Map<CategoryRequest>(_context.Categories.FirstOrDefault(x => x.IsActive.Equals(true) && x.Id.Equals(pro.Id))),
                   Supplier = _mapper.Map<SupplierRequest>(_context.Suppliers.FirstOrDefault(x => x.IsActive.Equals(true) && x.Id.Equals(pro.Id)))
                };
                productReponses.Add(res);
            }
            
           return   productReponses;
        }

        public ProductReponse GetById(int id)
        {
            return getProduct(id);
        }

        public void Update(int id, UpdateProduct model)
        {
            var product = _context.Products.Find(id);

            // validate
            if (product is null)
                throw new AppException("product not found for id :" + id);

            // copy model to product and save
            _mapper.Map(model, product);
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        // helper methods

        private ProductReponse getProduct(int id)
        {
            
            var product = _context.Products.FirstOrDefault(p=>p.IsActive==true&& p.Id==id);
            var response = new ProductReponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                TotalAmount = product.TotalAmount,
                Note = product.Note,
                IsActive = product.IsActive,
                Category = _mapper.Map<CategoryRequest>(_context.Categories.FirstOrDefault(c => c.IsActive.Equals(true) && c.Id.Equals(product.CategoryId))),
                Supplier = _mapper.Map<SupplierRequest>(_context.Suppliers.FirstOrDefault(s => s.IsActive.Equals(true) && s.Id.Equals(product.SupplierId)))
            };
            if (product == null) throw new KeyNotFoundException("Product not found");
            return response;
        }
    }
}
