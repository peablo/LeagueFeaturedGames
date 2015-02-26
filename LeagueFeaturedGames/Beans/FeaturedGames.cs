using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueFeaturedGames.Beans
{
    public class FeaturedGames
    {

        public long clientRefreshInterval { get; set; }

        public CurrentGameInfo[] gameList { get; set; }

    }
}
