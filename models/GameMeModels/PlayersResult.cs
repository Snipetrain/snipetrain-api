using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace snipetrain_api.Models
{
	[XmlRoot(ElementName = "gameME")]
	public class PlayerGameME
	{
		[XmlElement(ElementName = "vendor")]
		public Vendor Vendor { get; set; }
		[XmlElement(ElementName = "account")]
		public Account Account { get; set; }
		[XmlElement(ElementName = "rankinginfo")]
		public Rankinginfo Rankinginfo { get; set; }
		[XmlElement(ElementName = "playerlist")]
		public Playerlist Playerlist { get; set; }
		[XmlElement(ElementName = "playerinfo")]
		public Playerlist PlayerInfo { get; set; }
	}
	[XmlRoot(ElementName = "rankinginfo")]
	public class Rankinginfo
	{
		[XmlElement(ElementName = "game")]
		public string Game { get; set; }
		[XmlElement(ElementName = "totalplayers")]
		public string Totalplayers { get; set; }
		[XmlElement(ElementName = "activeplayers")]
		public string Activeplayers { get; set; }
		[XmlElement(ElementName = "activeclans")]
		public string Activeclans { get; set; }
		[XmlElement(ElementName = "totalservers")]
		public string Totalservers { get; set; }
	}

	[XmlRoot(ElementName = "pagination")]
	public class GameMePagination
	{
		[XmlElement(ElementName = "totalcount")]
		public string Totalcount { get; set; }
		[XmlElement(ElementName = "totalpages")]
		public string Totalpages { get; set; }
		[XmlElement(ElementName = "currentpage")]
		public string Currentpage { get; set; }
		[XmlElement(ElementName = "pageentries")]
		public string Pageentries { get; set; }
		[XmlElement(ElementName = "nextpagelink")]
		public string Nextpagelink { get; set; }
	}

	public class Player
	{
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "uniqueid")]
		public string Uniqueid { get; set; }
		[XmlElement(ElementName = "avatar")]
		public string Avatar { get; set; }
		[XmlElement(ElementName = "activity")]
		public string Activity { get; set; }
		[XmlElement(ElementName = "clanname")]
		public string Clanname { get; set; }
		[XmlElement(ElementName = "clanhp")]
		public string Clanhp { get; set; }
		[XmlElement(ElementName = "online")]
		public string Online { get; set; }
		[XmlElement(ElementName = "rank")]
		public string Rank { get; set; }
		[XmlElement(ElementName = "skill")]
		public string Skill { get; set; }
		[XmlElement(ElementName = "kills")]
		public string Kills { get; set; }
		[XmlElement(ElementName = "deaths")]
		public string Deaths { get; set; }
		[XmlElement(ElementName = "hs")]
		public string Hs { get; set; }
		[XmlElement(ElementName = "time")]
		public string Time { get; set; }
		[XmlElement(ElementName = "firstconnect")]
		public string Firstconnect { get; set; }
		[XmlElement(ElementName = "lastconnect")]
		public string Lastconnect { get; set; }
		[XmlElement(ElementName = "totalconnects")]
		public string Totalconnects { get; set; }
		[XmlElement(ElementName = "assists")]
		public string Assists { get; set; }
		[XmlElement(ElementName = "healedpoints")]
		public string Healedpoints { get; set; }
		[XmlElement(ElementName = "flagscaptured")]
		public string Flagscaptured { get; set; }
		[XmlElement(ElementName = "customwins")]
		public string Customwins { get; set; }
		[XmlElement(ElementName = "cc")]
		public string Cc { get; set; }
		[XmlElement(ElementName = "cn")]
		public string Cn { get; set; }
	}

	[XmlRoot(ElementName = "playerlist")]
	public class Playerlist
	{
		[XmlElement(ElementName = "pagination")]
		public GameMePagination Pagination { get; set; }
		[XmlElement("player", typeof(Player))]
		public List<Player> Player { get; set; }
	}
}