using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LeagueFeaturedGames.Beans;
using System.Drawing;


namespace LeagueFeaturedGames
{
    static class Services
    {

        public static String getSummonerId(String name, String region)
        {
            Summoner s;
            string sURL;
            sURL ="https://"
                + Util.getEndpointByRegion(region)
                + Constants.SummonerIdbasePath
                + "/"
                + region
                + Constants.summonerIdByName
                + "/"
                + name;

            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = System.Text.Encoding.UTF8;
                webClient.QueryString.Add("api_key", Constants.apikey);
                string result = webClient.DownloadString(sURL);

                Dictionary<String, Summoner> d = JsonConvert.DeserializeObject<Dictionary<String, Summoner>>(result);

                s = d[ name.ToLower().Replace(" ",string.Empty) ];
            }
            catch (System.Net.WebException)
            {
                
                return null;
            }

            return s.Id;
        }

        public static String getDDragonVersion()
        {
            string[] versions;
            string sURL;
            sURL = "https://"
                + Constants.globalEndPoint
                + Constants.versions;

            try
            {
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("api_key", Constants.apikey);
                string result = webClient.DownloadString(sURL);

                versions = JsonConvert.DeserializeObject<string[]>(result);
            }
            catch (System.Net.WebException)
            {

                return null;
            }

            return versions[0];
        }

        public static Champion[] getChampionList()
        {
            Champion[] champions;
            string sURL;
            sURL = "https://"
                + Constants.globalEndPoint
                + Constants.championList;

            try
            {
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("api_key", Constants.apikey);
                string result = webClient.DownloadString(sURL);

                ChampionListDto championlistdto = JsonConvert.DeserializeObject<ChampionListDto>(result);

                champions = championlistdto.data.Values.ToArray();
            }
            catch (System.Net.WebException)
            {
                return null;
            }
            

            return champions;
            
        }

        public static Image getChampionSquare(string ddragonversion, string key)
        {
            Image img;

            string sURL;
            sURL = Constants.ddragonCdnUrl
                + "/"
                + ddragonversion
                + Constants.ddragonRelativeUrl
                + "/"
                + key
                + ".png";

            try
            {

                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(sURL);
                HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebReponse.GetResponseStream();

                img = Image.FromStream(stream);

            }
            catch (System.Net.WebException)
            {
                return null;
            }

            return img;

        }

        public static FeaturedGames getFeaturedGames(string region)
        {
            FeaturedGames games;
            string sURL;
            sURL = "https://"
                + Util.getEndpointByRegion(region)
                + Constants.featuredGames;

            try
            {
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("api_key", Constants.apikey);
                webClient.Encoding = System.Text.Encoding.UTF8;
                string result = webClient.DownloadString(sURL);

                games = JsonConvert.DeserializeObject<FeaturedGames>(result);

                
            }
            catch (System.Net.WebException)
            {
                return null;
            }

            return games;
        }

        public static CurrentGameInfo getCurrentGame(string region, string summoner)
        {
            CurrentGameInfo game;

            string sURL;
            sURL = "https://"
                + Util.getEndpointByRegion(region)
                + Constants.currentGame
                + "/"
                + Util.getPlatformIDByRegion(region)
                + "/"
                + Services.getSummonerId(summoner, region);

            try
            {
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("api_key", Constants.apikey);
                webClient.Encoding = System.Text.Encoding.UTF8;
                string result = webClient.DownloadString(sURL);

                game = JsonConvert.DeserializeObject<CurrentGameInfo>(result);


            }
            catch (System.Net.WebException)
            {
                return null;
            }



            return game;
        }



    }
}
