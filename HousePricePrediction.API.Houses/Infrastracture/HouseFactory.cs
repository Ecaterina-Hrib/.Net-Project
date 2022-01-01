using HousePricePrediction.API.Houses.DB;

namespace HousePricePrediction.API.Houses.Infrastracture
{
    public static class HouseFactory
    {
        public static HousesDbContext SeedHouses(this HousesDbContext context)
        {
            if (!context.Houses.Any())
            {
                context.Houses.Add(new House
                {
                    Id = new Guid("3f283fa8-2a75-4352-a73a-6df53c863986")
                });
                context.Houses.Add(new House
                {
                    Id = new Guid("b101c022-2a80-49fa-bd46-cbaa3b7a25b3")
                });
                context.Houses.Add(new House
                {
                    Id = new Guid("65732eb3-71f2-46e5-8b45-9330b4d56bab")
                });
                context.Houses.Add(new House
                {
                    Id = new Guid("3349ad78-426b-4c0e-9e8f-e447af3d1984")
                });
                context.SaveChanges();
            }
            return context;
        }
    }
}
