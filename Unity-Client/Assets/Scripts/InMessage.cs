using UnityEngine;
using System.Collections;

public class InMessage
{

		public enum Direction
		{
				Noord,
				Oost,
				Zuid,
				West
		}

		public enum Vehicle
		{
				Auto,
				Bus,
				Fiets,
				Voetganger,
				Trein
		}

		public enum Settings
		{
				Rood,
				Oranje,
				Groen
		}

		public string toString ()
		{
				return inbound.ToString () + ", " + outbound.ToString () + ", " + vehicle.ToString () + ", " + setting.ToString ();
				
		}

		public string toMessage ()
		{
				return "" + inbound.ToString()[0] + outbound.ToString()[0] + vehicle.ToString()[0] + setting.ToString()[0];
		}

		public Direction inbound;
		public Direction outbound;
		public Vehicle vehicle;
		public Settings setting;
}
