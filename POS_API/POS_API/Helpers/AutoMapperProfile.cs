namespace POS_API.Helpers;

using AutoMapper;
using POS_API.Entities;
using POS_API.Models.Categories;
using POS_API.Models.Customers;
using POS_API.Models.Inventories;
using POS_API.Models.Products;
using POS_API.Models.Suppliers;
using POS_API.Models.Users;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> AuthenticateResponse
        CreateMap<User, AuthenticateResponse>();

        // RegisterRequest -> User
        CreateMap<RegisterRequest, User>();
       
        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            )
        );
        /*category*/
        CreateMap<Category, CategoryRequest>().ReverseMap();
        CreateMap<Category, UpdateCategory>().ReverseMap();
        /*Customer*/
        CreateMap<Customer,CustomerRequest>().ReverseMap();
        CreateMap<Customer,UpdateCustomer>().ReverseMap();
        /*Product*/
        CreateMap<Product, ProductRequest>().ReverseMap();
        CreateMap<Product,UpdateProduct>().ReverseMap();
        /*Supplier*/
        CreateMap<Supplier, SupplierRequest>().ReverseMap();
        CreateMap<Supplier, UpdateSupplier>().ReverseMap();
        /*Inventory*/
        CreateMap<Inventory,InventoryRequest>().ReverseMap();
        CreateMap<Inventory,UpdateInventory>().ReverseMap();
    }
}