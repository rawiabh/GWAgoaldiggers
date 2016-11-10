using GWA.Data.Infrastructure;
using GWA.Domaine.Entities;
using GWA.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Service.Auctions
{
  public class AuctionService : Service<Auction>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public AuctionService()
           : base(ut)
        {
        }
        public IEnumerable<Auction> getdemandtoaddauction()
        {
            return ut.getRepository<Auction>().GetMany(x => x.validator == 0);
        }
        public IEnumerable<Auction> getauctions()
        {
            return ut.getRepository<Auction>().GetMany(x => x.validator == 1);
        }

    }
}
