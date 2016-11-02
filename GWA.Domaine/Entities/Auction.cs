using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWA.Domaine.Entities
{
    public enum Style
    {
        English,
        Yankee,
        AggregateDemand,
        NegociatedPrice,
        Dutch,

    }
    public class Auction
    {
        public int Id { get; set; }
        public int AuctionValue { get; set; }
        public DateTime AuctionTimer { get; set; }
        public DateTime TimeLeft { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public String  Title { get; set; }
        public String Description { get; set; }
        public User Currentwinner { get; set; }
        public int FinalPrice { get; set; }
        public Style Style  { get; set; }

    }


}
