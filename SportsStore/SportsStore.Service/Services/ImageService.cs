using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Context;
using SportsStore.Domain.Entities;
namespace SportsStore.Service.Services
{
    public class ImageService : IImageService
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Image> GetImages()
        {
            return context.Images
                .Include("Product")
                .GroupBy(x => x.Product.Id)
                .First();
        }
    }
}
