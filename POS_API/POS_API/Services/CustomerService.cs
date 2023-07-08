using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS_API.Entities;
using POS_API.Helpers;
using POS_API.Models.Categories;
using POS_API.Models.Customers;

namespace POS_API.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer create(CustomerRequest model);
        void Update(int id, UpdateCustomer model);
        void Delete(int id);
    }
    public class CustomerService : ICustomerService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CustomerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Customer create(CustomerRequest model)
        {
            // validate
            if (model is null)
                throw new AppException("category is empty or null");

            // map model to new customer object
            var customer = _mapper.Map<Customer>(model);

            // save customer
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            var customer = getCustomer(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public Customer GetById(int id)
        {
            return getCustomer(id);
        }

        public void Update(int id, UpdateCustomer model)
        {
            var customer = getCustomer(id);

            // validate
            if (customer is null)
                throw new AppException("category not found for id :" + id);

            // copy model to user and save
            _mapper.Map(model, customer);
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        private Customer getCustomer(int id)
        {
            var category = _context.Customers.Find(id);
            if (category == null) throw new KeyNotFoundException("category not found");
            return category;
        }
    }
}
