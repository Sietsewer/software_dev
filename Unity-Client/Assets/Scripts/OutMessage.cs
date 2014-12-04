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
		return "" + num + ", " +  inbound.ToString () + ", " + outbound.ToString ()+ ", " +  vehicle.ToString () + ", " + count;
	}

	public string toMessage ()
	{
		count = count >= 9 ? 9 : count;
		count = count <= 0 ? 0 : count;
		return "" + num + inbound.ToString () [0] + outbound.ToString () [0] + vehicle.ToString () [0] + count + "";
	}

	public int num;
	public Direction inbound;
	public Direction outbound;
	public Vehicle vehicle;
	public int count;
}
