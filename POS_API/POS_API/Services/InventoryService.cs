using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS_API.Entities;
using POS_API.Helpers;
using POS_API.Models.Customers;
using POS_API.Models.Inventories;

namespace POS_API.Services
{
    public interface IInventoryService
    {
        IEnumerable<Inventory> GetAll();
        Inventory GetById(int id);
        Inventory create(InventoryRequest model);
        void Update(int id, UpdateInventory model);
        void Delete(int id);
    }
    public class InventoryService : IInventoryService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public InventoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Inventory create(InventoryRequest model)
        {
            if(model is null) 
                throw new AppException("Inventory is empty");
            var inventory = _mapper.Map<Inventory>(model);
            _context.Inventories.Add(inventory);
            _context.SaveChangesAsync();
            return inventory;
        }

        public void Delete(int id)
        {
            Inventory inventory=getInventory(id);
            inventory.IsActive = false;
            _context.SaveChangesAsync();
        }

        public IEnumerable<Inventory> GetAll()
        {
            var inventories=_context.Inventories.Where(x=>x.IsActive.Equals(true)).ToList();
            return inventories;
        }

        public Inventory GetById(int id)
        {
            return getInventory(id);
        }

        public void Update(int id, UpdateInventory model)
        {
            var inventory = getInventory(id);
            if (inventory is null)
                throw new AppException("Inventory is not found for id"+id);
            _mapper.Map(model, inventory);
            _context.Inventories.Update(inventory);
            _context.SaveChangesAsync();

        }
        private Inventory getInventory(int id)
        {
            var inventory = _context.Inventories.FirstOrDefault(s => s.IsActive.Equals(true));
            if (inventory == null) throw new KeyNotFoundException("Inventory not found for id :" + id);
            return inventory;
        }
    }
}
