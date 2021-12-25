namespace FII.eCommerce.API.Products.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<DB.Product, Model.ProductModel>().ReverseMap();
        }
    }
}
