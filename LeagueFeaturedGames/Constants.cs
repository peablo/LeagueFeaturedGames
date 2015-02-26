using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueFeaturedGames
{
    static class Constants
    {
        //regions
        public readonly static String br = "br";
        public readonly static String eune = "eune";
        public readonly static String euw = "euw";
        public readonly static String kr = "kr";
        public readonly static String lan = "lan";
        public readonly static String las = "las";
        public readonly static String na = "na";
        public readonly static String oce = "oce";
        public readonly static String tr = "tr";
        public readonly static String ru = "ru";

        public readonly static String brEndPoint = "br.api.pvp.net";
        public readonly static String euneEndPoint = "eune.api.pvp.net";
        public readonly static String euwEndPoint = "euw.api.pvp.net";
        public readonly static String krEndPoint = "kr.api.pvp.net";
        public readonly static String lanEndPoint = "lan.api.pvp.net";
        public readonly static String lasEndPoint = "las.api.pvp.net";
        public readonly static String naEndPoint = "na.api.pvp.net";
        public readonly static String oceEndPoint = "oce.api.pvp.net";
        public readonly static String trEndPoint = "tr.api.pvp.net";
        public readonly static String ruEndPoint = "ru.api.pvp.net";
        public readonly static String globalEndPoint = "global.api.pvp.net";

        public readonly static String brPlatformID = "BR1";
        public readonly static String eunePlatformID = "EUN1";
        public readonly static String euwPlatformID = "EUW1";
        public readonly static String krPlatformID = "KR";
        public readonly static String lanPlatformID = "LA1";
        public readonly static String lasPlatformID = "LA2";
        public readonly static String naPlatformID = "NA1";
        public readonly static String ocePlatformID = "OC1";
        public readonly static String trPlatformID = "TR1";
        public readonly static String ruPlatformID = "RU";

        public readonly static String naSpectatorUrl = "spectator.na.lol.riotgames.com:80";
        public readonly static String euwSpectatorUrl = "spectator.euw1.lol.riotgames.com:80";
        public readonly static String euneSpectatorUrl = "spectator.eu.lol.riotgames.com:8080";
        public readonly static String krSpectatorUrl = "spectator.kr.lol.riotgames.com:80";
        public readonly static String oceSpectatorUrl = "spectator.oc1.lol.riotgames.com:80";
        public readonly static String brSpectatorUrl = "spectator.br.lol.riotgames.com:80";
        public readonly static String lanSpectatorUrl = "spectator.la1.lol.riotgames.com:80";
        public readonly static String lasSpectatorUrl = "spectator.la2.lol.riotgames.com:80";
        public readonly static String ruSpectatorUrl = "spectator.ru.lol.riotgames.com:80";
        public readonly static String trSpectatorUrl = "spectator.tr.lol.riotgames.com:80";

        public readonly static String leagueBasePath = "C:\\Riot Games\\League of Legends\\RADS\\solutions\\lol_game_client_sln\\releases";
        public readonly static String leagueClientPath = "\\deploy";
        public readonly static String leagueClientFile = "League of Legends.exe";

        public readonly static String spectatorConstantParameters = "\"8394\" \"LoLLauncher.exe\" \"\"";



        public readonly static String ddragonCdnUrl = "http://ddragon.leagueoflegends.com/cdn";

        public readonly static String ddragonRelativeUrl = "/img/champion";


        //API
        

        public readonly static String versions = "/api/lol/static-data/euw/v1.2/versions"; // /api/lol/static-data/{region}/v1.2/versions

        public readonly static String featuredGames = "/observer-mode/rest/featured"; // /observer-mode/rest/featured

        public readonly static String championList = "/api/lol/static-data/euw/v1.2/champion"; // /api/lol/static-data/{region}/v1.2/champion

        public readonly static String currentGame = "/observer-mode/rest/consumer/getSpectatorGameInfo"; // /{platformId}/{summonerId}

        public readonly static String SummonerIdbasePath = "/api/lol"; 
        public readonly static String summonerIdByName = "/v1.4/summoner/by-name"; // /api/lol/{region}/v1.4/summoner/by-name/{summonerNames}

        public readonly static String apikey = "9849a147-5a59-401f-80bb-c23b2906da9f";

    }
}
