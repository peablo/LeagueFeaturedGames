using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueFeaturedGames
{
    static class Util
    {

        public static String getEndpointByRegion (String region)
        {

            if (region.Equals(Constants.br))
                return Constants.brEndPoint;
            if (region.Equals(Constants.eune))
                return Constants.euneEndPoint;
            if (region.Equals(Constants.euw))
                return Constants.euwEndPoint;
            if (region.Equals(Constants.kr))
                return Constants.krEndPoint;
            if (region.Equals(Constants.lan))
                return Constants.lanEndPoint;
            if (region.Equals(Constants.las))
                return Constants.lasEndPoint;
            if (region.Equals(Constants.na))
                return Constants.naEndPoint;
            if (region.Equals(Constants.oce))
                return Constants.oceEndPoint;
            if (region.Equals(Constants.tr))
                return Constants.trEndPoint;
            if (region.Equals(Constants.ru))
                return Constants.ruEndPoint;

            return "";
        }

        public static String getPlatformIDByRegion(String region)
        {
            if (region.Equals(Constants.br))
                return Constants.brPlatformID;
            if (region.Equals(Constants.eune))
                return Constants.eunePlatformID;
            if (region.Equals(Constants.euw))
                return Constants.euwPlatformID;
            if (region.Equals(Constants.kr))
                return Constants.krPlatformID;
            if (region.Equals(Constants.lan))
                return Constants.lanPlatformID;
            if (region.Equals(Constants.las))
                return Constants.lasPlatformID;
            if (region.Equals(Constants.na))
                return Constants.naPlatformID;
            if (region.Equals(Constants.oce))
                return Constants.ocePlatformID;
            if (region.Equals(Constants.tr))
                return Constants.trPlatformID;
            if (region.Equals(Constants.ru))
                return Constants.ruPlatformID;

            return "";
        }

        public static String getSpectatorUrlByRegion(String region)
        {
            if (region.Equals(Constants.br))
                return Constants.brSpectatorUrl;
            if (region.Equals(Constants.eune))
                return Constants.euneSpectatorUrl;
            if (region.Equals(Constants.euw))
                return Constants.euwSpectatorUrl;
            if (region.Equals(Constants.kr))
                return Constants.krSpectatorUrl;
            if (region.Equals(Constants.lan))
                return Constants.lanSpectatorUrl;
            if (region.Equals(Constants.las))
                return Constants.lasSpectatorUrl;
            if (region.Equals(Constants.na))
                return Constants.naSpectatorUrl;
            if (region.Equals(Constants.oce))
                return Constants.oceSpectatorUrl;
            if (region.Equals(Constants.tr))
                return Constants.trSpectatorUrl;
            if (region.Equals(Constants.ru))
                return Constants.ruSpectatorUrl;

            return "";
        }

        public static String getClientPath()
        {
            string folder;

            string dir = Constants.leagueBasePath;

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(dir));

            for (int i = 0; i < dirs.Count; i++ )
            {
                dirs[i] = dirs[i].Substring(dir.Length+1);
            }
            
            folder = dirs[0];

            foreach (var d in dirs)
            {
                if (folder.CompareTo(d) == -1)
                    folder = d;
            }

            string result = dir + "\\" + folder + Constants.leagueClientPath;

            return result;
        }

        public static Boolean runSpectate(CurrentGameInfo game, string region)
        {

            string clientPath = getClientPath();

            string parameters = Constants.spectatorConstantParameters
                + " "
                + "\"spectator "
                + getSpectatorUrlByRegion(region)
                + " "
                + game.observers.encryptionKey
                + " "
                + game.gameId
                + " "
                + getPlatformIDByRegion(region)
                + "\"";

            

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = clientPath + "\\" + Constants.leagueClientFile;

            startInfo.WorkingDirectory = clientPath;

            startInfo.Arguments = parameters;

            try 
            {
                Process proc = Process.Start(startInfo);

                return true;
            }
            catch ( System.IO.FileNotFoundException )
            {
                return false;
            }
            

        }

        public static DateTime fromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTime);
        }

    }
}
