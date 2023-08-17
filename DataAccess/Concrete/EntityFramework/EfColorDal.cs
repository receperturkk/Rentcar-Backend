using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RentCarContext>, IColorDal
    {
        public List<Color> GetColorsByBrandId(int brandId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from co in context.Colors
                             join c in context.Cars on co.Id equals c.ColorId
                             join b in context.Brands on c.BrandId equals b.Id
                             where c.BrandId == brandId
                             select new Color
                             {
                                 Id = co.Id,
                                 Name = co.Name
                             };
                return result.Distinct().ToList();
            }
        }
    }
}
