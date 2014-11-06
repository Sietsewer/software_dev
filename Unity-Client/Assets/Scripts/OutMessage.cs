using UnityEngine;
using System.Collections;

public class OutMessage
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

		public string toString ()
		{
		return "" + num + ", " +  inbound.ToString () + ", " + outbound.ToString ()+ ", " +  vehicle.ToString ();
    
		}
	
		public string toMessage ()
		{
				return "" + num + inbound.ToString () [0] + outbound.ToString () [0] + vehicle.ToString () [0];
		}

		public int num;
		public Direction inbound;
		public Direction outbound;
		public Vehicle vehicle;
}
