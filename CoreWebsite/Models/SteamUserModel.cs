using System;
using System.Collections.Generic;

namespace CoreWebsite.Models.SteamApi
{
    public class GetOwnedGamesResponse
    {
        private OwnedGamesSummary oOwndedGames;
        public OwnedGamesSummary Response { get => oOwndedGames; set => oOwndedGames = value; }
    }

    public class OwnedGamesSummary
    {
        private int iGame_count;
        private List<OwnedGameDetail> oGames;

        public int game_count { get => iGame_count; set => iGame_count = value; }
        public List<OwnedGameDetail> games { get => oGames; set => oGames = value; }
    }

    public class OwnedGameDetail
    {
        private int iAppid;
        private string sName;
        private long lPlaytime_2weeks;
        private long lPlaytime_forever;
        private string sImg_icon_url;
        private string sImg_logo_url;
        private bool bHas_community_visible_stats;

        public int appid { get => iAppid; set => iAppid = value; }
        public string name { get => sName; set => sName = value; }
        public long playtime_2weeks { get => lPlaytime_2weeks; set => lPlaytime_2weeks = value; }
        public long playtime_forever { get => lPlaytime_forever; set => lPlaytime_forever = value; }
        public string img_icon_url { get => "http://media.steampowered.com/steamcommunity/public/images/apps/" + this.appid + "/"+ sImg_icon_url + ".jpg"; set => sImg_icon_url = value; }
        public string img_logo_url { get => "http://media.steampowered.com/steamcommunity/public/images/apps/" + this.appid + "/" + sImg_logo_url + ".jpg"; set => sImg_logo_url = value; }
        public bool has_community_visible_stats { get => bHas_community_visible_stats; set => bHas_community_visible_stats = value; }
    }

    public class GetSteamPlayerSummariesResponse
    {
        private SteamPlayerSummaries oResponse;
        public SteamPlayerSummaries Response { get => oResponse; set => oResponse = value; }
    }
    
    public class SteamPlayerSummaries
    {
        private List<SteamPlayerSummary>  oPlayers;
        public List<SteamPlayerSummary> Players { get => oPlayers; set => oPlayers = value; }
    }

    public class SteamPlayerSummary
    {
        private int steamid { get; set; }
        private int communityvisibilitystate { get; set; }
        public int profilestate { get; set; }
        public string personaname { get; set; }
        public int lastlogoff { get; set; }
        public string profileurl { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public int personastate { get; set; }
        public string realname { get; set; }
        public long primaryclanid { get; set; }
        public double timecreated { get; set; }
        public int personastateflags { get; set; }
        public string loccountrycode { get; set; }
        public string locstatecode { get; set; }
        public int loccityid { get; set; }
    }
}
