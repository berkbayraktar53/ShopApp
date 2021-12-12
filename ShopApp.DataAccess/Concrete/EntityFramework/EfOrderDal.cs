using ShopApp.DataAccess.Abstract;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfGenericRepository<Order, ShopContext>, IOrderDal
    {

    }
}