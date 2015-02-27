using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueFeaturedGames.Beans;


namespace LeagueFeaturedGames
{
    public partial class Form1 : Form
    {

        private string ddragonVersion;
        private Champion[] championList;
        private string clientPath;

        private static readonly int clientRefreshInterval = 300;
        private TimeSpan refreshTimeRemaining = new TimeSpan(0, 0, clientRefreshInterval);

        private string selectedRegion = Constants.euw; // Europe west by default
        private FeaturedGames selectedFeaturedGames;
        private int selectedGameIndex = 0;
        private CurrentGameInfo selectedGame;
        private TimeSpan currentGameTimeSpan;

        private Dictionary<string, FeaturedGames> featuredGamesByRegion = new Dictionary<string,FeaturedGames>();


        private Dictionary<string,Label> regionLabels = new Dictionary<string,Label>();

        public Form1()
        {
            InitializeComponent();

            

            init();

        }

        private void init()
        {


            championList = Services.getChampionList();
            ddragonVersion = Services.getDDragonVersion();
            clientPath = Util.getClientPath();

            regionLabels.Add(Constants.br, labelBr);
            regionLabels.Add(Constants.eune, labelEune);
            regionLabels.Add(Constants.euw, labelEuw);
            regionLabels.Add(Constants.kr, labelKr);
            regionLabels.Add(Constants.lan, labelLan);
            regionLabels.Add(Constants.las, labelLas);
            regionLabels.Add(Constants.na, labelNa);
            regionLabels.Add(Constants.oce, labelOce);
            regionLabels.Add(Constants.ru, labelRu);
            regionLabels.Add(Constants.tr, labelTr);

            showFeaturedGames(selectedRegion);
            
            
            
        }

        

        private void showFeaturedGames(string region)
        {
            if(!featuredGamesByRegion.ContainsKey(region))
            {
                FeaturedGames f = Services.getFeaturedGames(region);
                if (f != null)
                    featuredGamesByRegion.Add(region, Services.getFeaturedGames(region));
                
            }
            if (featuredGamesByRegion.ContainsKey(region) && featuredGamesByRegion[region].gameList.Length > 0)
            {
                selectedRegion = region;

                selectedFeaturedGames = featuredGamesByRegion[selectedRegion];

                setPage(0);

                Label[] labels = regionLabels.Values.ToArray();

                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Font = new Font(labels[i].Font, FontStyle.Regular);

                }

                regionLabels[region].Font = new Font(regionLabels[region].Font, FontStyle.Bold);

            }
            else
            {
                showError("The featured games for " + region.ToUpper() + " couldnt be loaded");
            }
        }

        private void showGame(CurrentGameInfo g)
        {

            summ1team1.Text = g.participants[0].summonerName;
            summ2team1.Text = g.participants[1].summonerName;
            summ3team1.Text = g.participants[2].summonerName;
            summ4team1.Text = g.participants[3].summonerName;
            summ5team1.Text = g.participants[4].summonerName;

            summ1team2.Text = g.participants[5].summonerName;
            summ2team2.Text = g.participants[6].summonerName;
            summ3team2.Text = g.participants[7].summonerName;
            summ4team2.Text = g.participants[8].summonerName;
            summ5team2.Text = g.participants[9].summonerName;

            champ1team1.Image = getChampionPic((int)g.participants[0].championId);
            champ2team1.Image = getChampionPic((int)g.participants[1].championId);
            champ3team1.Image = getChampionPic((int)g.participants[2].championId);
            champ4team1.Image = getChampionPic((int)g.participants[3].championId);
            champ5team1.Image = getChampionPic((int)g.participants[4].championId);

            champ1team2.Image = getChampionPic((int)g.participants[5].championId);
            champ2team2.Image = getChampionPic((int)g.participants[6].championId);
            champ3team2.Image = getChampionPic((int)g.participants[7].championId);
            champ4team2.Image = getChampionPic((int)g.participants[8].championId);
            champ5team2.Image = getChampionPic((int)g.participants[9].championId);

            long gameStartTime = g.gameStartTime;

            DateTime startTime = Util.fromUnixTime(gameStartTime);

            TimeSpan diff = DateTime.UtcNow - startTime;

            currentGameTimeSpan = diff;

            updateTimeLabel();

        }

        private void updateTimeLabel() 
        {
            timeLabel.Text = currentGameTimeSpan.ToString(@"mm\:ss");
        }

        
        private Image getChampionPic(int Id)
        {
            string champKey = "";

            for(int i = 0 ; i < championList.Length ; i++)
            {
                if( championList[i].Id == Id )
                {
                    if (championList[i].Square == null)
                    {
                        champKey = championList[i].Key;
                        Image img = Services.getChampionSquare(ddragonVersion, champKey);
                        championList[i].Square = img;
                    }
                    return championList[i].Square;
                }
            }



            return null;

        }

        private void prevGameButton_Click(object sender, EventArgs e)
        {
            if (selectedGameIndex > 0)
            {
                setPage(selectedGameIndex - 1);
            }
        }

        private void nextGameButton_Click(object sender, EventArgs e)
        {
            if (selectedGameIndex < 4)
            {
                setPage(selectedGameIndex + 1);
            }

        }

        private void setPage(int page)
        {

            if ( page >= 0 &&
                selectedFeaturedGames != null && 
                selectedFeaturedGames.gameList.Length > page )
            {
                selectedGameIndex = page;

                selectedGame = selectedFeaturedGames.gameList[selectedGameIndex];

                showGame(selectedGame);

                gameNumber.Text = (page + 1) + " / " + selectedFeaturedGames.gameList.Length;

                

                if (page == 0)
                {
                    prevGameButton.Enabled = false;
                }
                else
                {
                    prevGameButton.Enabled = true;
                }

                if (page == selectedFeaturedGames.gameList.Length-1)
                {
                    nextGameButton.Enabled = false;
                }
                else
                {
                    nextGameButton.Enabled = true;
                }

                
            }

        }

        private void singlePage()
        {
            selectedGameIndex = 0;
            showGame(selectedGame);

            gameNumber.Text = "1 / 1";
            prevGameButton.Enabled = false;
            nextGameButton.Enabled = false;
        }

        private void showError(string error)
        {
            MessageBox.Show(error);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            if (regionComboBox.SelectedItem == null)
            {
                showError("Pick a region");
                return;
            }

            string region = regionComboBox.SelectedItem.ToString().ToLower();
            string summ = summName.Text;

            CurrentGameInfo game = Services.getCurrentGame( region , summ );

            if(game != null)
            {
                selectedGame = game;
                selectedRegion = region;
                selectedFeaturedGames = null;

                singlePage();

                Label[] labels = regionLabels.Values.ToArray();

                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Font = new Font(labels[i].Font, FontStyle.Regular);

                }

            }
            else
            {
                showError("The player "+ summ +" is not currently in a game.");
            }

            
        }

        private void watchButton_Click(object sender, EventArgs e)
        {
            if(commandLine.Checked)
            {
                Clipboard.SetText( Util.getSpectatorString(selectedGame, selectedRegion) );
                MessageBox.Show("The command line string has been copied to the clipboard.");

                return;
            }

            
            if (Util.runSpectate(selectedGame,selectedRegion))
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                showError("League of Legends installation not found");
            }
        }

        private void updateRefreshLock()
        {

            if( refreshTimeRemaining.TotalSeconds <= 0 )
            {
                refreshGamesButton.Enabled = true;
                refreshGamesButton.Text = "Refresh featured games";
            }
            else
            {
                refreshGamesButton.Enabled = false;
                refreshGamesButton.Text = "Refresh featured games (" + refreshTimeRemaining.TotalSeconds+" s)";
            }

        }

        private void renewRefreshTime ()
        {
            refreshTimeRemaining = new TimeSpan(0, 0, clientRefreshInterval);
            updateRefreshLock();
        }


        private void refreshGamesButton_Click(object sender, EventArgs e)
        {
            renewRefreshTime();

            featuredGamesByRegion = new Dictionary<string, FeaturedGames>();

            selectedGame = null;
            selectedFeaturedGames = null;

            showFeaturedGames(selectedRegion);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            currentGameTimeSpan = currentGameTimeSpan.Add(new TimeSpan(0, 0, 1));
            updateTimeLabel();

            refreshTimeRemaining = refreshTimeRemaining.Subtract(new TimeSpan(0, 0, 1));
            updateRefreshLock();

        }


        private void labelBr_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.br);
        }

        private void labelEune_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.eune);
        }

        private void labelEuw_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.euw);
        }

        private void labelKr_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.kr);
        }

        private void labelLan_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.lan);
        }

        private void labelLas_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.las);
        }

        private void labelNa_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.na);
        }

        private void labelOce_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.oce);
        }

        private void labelRu_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.ru);
        }

        private void labelTr_Click(object sender, EventArgs e)
        {
            showFeaturedGames(Constants.tr);
        }

        

        

        

       

        

    }
}
