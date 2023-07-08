using AutoMapper;
using POS_API.Entities;
using POS_API.Helpers;
using POS_API.Models.Categories;
using POS_API.Models.Suppliers;

namespace POS_API.Services
{
    public interface ISuppliersService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier create(SupplierRequest model);
        void Update(int id, UpdateSupplier model);
        void Delete(int id);
    }
    public class SupplierService : ISuppliersService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public SupplierService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Supplier create(SupplierRequest model)
        {
            // validate
            if (model is null)
                throw new AppException("Supplier is empty or null");

            // map model to new user object
            var supplier = _mapper.Map<Supplier>(model);

            // save user
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        public void Delete(int id)
        {
            var supplier = getsupplier(id);
            supplier.IsActive = false;
            /*_context.Suppliers.Remove(supplier);*/
            _context.SaveChanges();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.Where(s=>s.IsActive.Equals(true));
        }

        public Supplier GetById(int id)
        {
            return getsupplier(id);
        }

        public void Update(int id, UpdateSupplier model)
        {
            var supplier = getsupplier(id);

            // validate
            if (supplier is null)
                throw new AppException("supplier not found for id :" + id);

            // copy model to supplier and save
            _mapper.Map(model, supplier);
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }
        // helper methods

        private Supplier getsupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s=>s.IsActive.Equals(true));
            if (supplier == null) throw new KeyNotFoundException("supplier not found");
            return supplier;
        }
    }
}
