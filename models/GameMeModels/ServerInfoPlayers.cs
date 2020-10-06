using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace snipetrain_api.Models
{
    [XmlRoot(ElementName="gameME")]
	public class PlayerInfoGameMe {
		[XmlElement(ElementName="vendor")]
		public Vendor Vendor { get; set; }
		[XmlElement(ElementName="account")]
		public Account Account { get; set; }
		[XmlElement(ElementName="serverinfo")]
		public Serverinfo Serverinfo { get; set; }
	}
	[XmlRoot(ElementName="steam")]
	public class Steam {
		[XmlElement(ElementName="version")]
		public string Version { get; set; }
		[XmlElement(ElementName="account")]
		public string Account { get; set; }
		[XmlElement(ElementName="officialversion")]
		public string Officialversion { get; set; }
	}

	[XmlRoot(ElementName="team")]
	public class Team {
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
		[XmlElement(ElementName="count")]
		public string Count { get; set; }
	}

	[XmlRoot(ElementName="teams")]
	public class Teams {
		[XmlElement(ElementName="team")]
		public List<Team> Team { get; set; }
	}

	[XmlRoot(ElementName="player")]
	public class ServerPlayer {
		[XmlElement(ElementName="id")]
		public string Id { get; set; }
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
		[XmlElement(ElementName="uniqueid")]
		public string Uniqueid { get; set; }
		[XmlElement(ElementName="avatar")]
		public string Avatar { get; set; }
		[XmlElement(ElementName="team")]
		public string Team { get; set; }
		[XmlElement(ElementName="squad")]
		public string Squad { get; set; }
		[XmlElement(ElementName="kills")]
		public string Kills { get; set; }
		[XmlElement(ElementName="deaths")]
		public string Deaths { get; set; }
		[XmlElement(ElementName="suicides")]
		public string Suicides { get; set; }
		[XmlElement(ElementName="hs")]
		public string Hs { get; set; }
		[XmlElement(ElementName="shots")]
		public string Shots { get; set; }
		[XmlElement(ElementName="hits")]
		public string Hits { get; set; }
		[XmlElement(ElementName="isdead")]
		public string Isdead { get; set; }
		[XmlElement(ElementName="hasbomb")]
		public string Hasbomb { get; set; }
		[XmlElement(ElementName="ping")]
		public string Ping { get; set; }
		[XmlElement(ElementName="connected")]
		public string Connected { get; set; }
		[XmlElement(ElementName="skillchange")]
		public string Skillchange { get; set; }
		[XmlElement(ElementName="skill")]
		public string Skill { get; set; }
		[XmlElement(ElementName="rank")]
		public string Rank { get; set; }
		[XmlElement(ElementName="assists")]
		public string Assists { get; set; }
		[XmlElement(ElementName="assisted")]
		public string Assisted { get; set; }
		[XmlElement(ElementName="killstreak")]
		public string Killstreak { get; set; }
		[XmlElement(ElementName="deathstreak")]
		public string Deathstreak { get; set; }
		[XmlElement(ElementName="rounds")]
		public string Rounds { get; set; }
		[XmlElement(ElementName="survived")]
		public string Survived { get; set; }
		[XmlElement(ElementName="wins")]
		public string Wins { get; set; }
		[XmlElement(ElementName="losses")]
		public string Losses { get; set; }
		[XmlElement(ElementName="teamkills")]
		public string Teamkills { get; set; }
		[XmlElement(ElementName="teamkilled")]
		public string Teamkilled { get; set; }
		[XmlElement(ElementName="healedpoints")]
		public string Healedpoints { get; set; }
		[XmlElement(ElementName="flagscaptured")]
		public string Flagscaptured { get; set; }
		[XmlElement(ElementName="cc")]
		public string Cc { get; set; }
		[XmlElement(ElementName="cn")]
		public string Cn { get; set; }

		public override int GetHashCode()
		{
			return Id.GetHashCode(); // Not too sure if that's gonna break shit but it shouldn't
		}

		public override bool Equals (Object obj)
		{
			var other = obj as ServerPlayer;

			if (other == null)
				return false;
			
			if (Skill != other.Skill)
				return false;

			if (Suicides != other.Suicides)
				return false;

			if (Ping != other.Ping)
				return false;

			return true;
		}
	}

	[XmlRoot(ElementName="players")]
	public class Players {
		[XmlElement(ElementName="player")]
		public List<ServerPlayer> Player { get; set; }
	}

	[XmlRoot(ElementName="server")]
	public class Server {
		[XmlElement(ElementName="id")]
		public string Id { get; set; }
		[XmlElement(ElementName="addr")]
		public string Addr { get; set; }
		[XmlElement(ElementName="port")]
		public string Port { get; set; }
		[XmlElement(ElementName="game")]
		public string Game { get; set; }
		[XmlElement(ElementName="steam")]
		public Steam Steam { get; set; }
		[XmlElement(ElementName="uptime")]
		public string Uptime { get; set; }
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
		[XmlElement(ElementName="map")]
		public string Map { get; set; }
		[XmlElement(ElementName="time")]
		public string Time { get; set; }
		[XmlElement(ElementName="act")]
		public string Act { get; set; }
		[XmlElement(ElementName="bots")]
		public string Bots { get; set; }
		[XmlElement(ElementName="max")]
		public string Max { get; set; }
		[XmlElement(ElementName="kills")]
		public string Kills { get; set; }
		[XmlElement(ElementName="hs")]
		public string Hs { get; set; }
		[XmlElement(ElementName="suicides")]
		public string Suicides { get; set; }
		[XmlElement(ElementName="shots")]
		public string Shots { get; set; }
		[XmlElement(ElementName="hits")]
		public string Hits { get; set; }
		[XmlElement(ElementName="cc")]
		public string Cc { get; set; }
		[XmlElement(ElementName="cn")]
		public string Cn { get; set; }
		[XmlElement(ElementName="teams")]
		public Teams Teams { get; set; }
		[XmlElement(ElementName="players")]
		public Players Players { get; set; }

		public override int GetHashCode()
		{
			return Id.GetHashCode(); // Not too sure if that's gonna break shit but it shouldn't
		}

		public override bool Equals (Object obj)
		{
			var other = obj as Server;

			if (other == null)
				return false;
			
			if (Map != other.Map)
				return false;

			if (Kills != other.Kills)
				return false;

			if (Suicides != other.Suicides)
				return false;

			if (Players.Player.Count() != other.Players.Player.Count)
				return false;

			foreach (var player in Players.Player)
			{
				var otherPlayer = other.Players.Player.Find(x => x.Id == player.Id);

				if (!player.Equals(otherPlayer)) {
					return false;
				}
				
			}

			return true;
		}
	}

	[XmlRoot(ElementName="serverinfo")]
	public class Serverinfo {
		[XmlElement(ElementName="server")]
		public Server Server { get; set; }
	}

}
