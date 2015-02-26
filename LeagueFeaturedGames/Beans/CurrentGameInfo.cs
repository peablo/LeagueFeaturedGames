using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueFeaturedGames.Beans;

namespace LeagueFeaturedGames
{
    public class CurrentGameInfo
    {

        public long gameId { get; set; }
        public long gameLength { get; set; }

        public long gameStartTime { get; set; }

        public Observer observers { get; set; }

        public Participant[] participants { get; set; }

        public string platformId { get; set; }

    }
}
