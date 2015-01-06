using UnityEngine;
using System.Collections;

public static class MessageHandler
{

		public static InMessage stringToInMessage (string message)
		{
		InMessage im = new InMessage();

				bool incorrectMessage = false;
				if (message.Length == 4) {
						switch (message [0]) {
						case 'N':
								
								im.inbound = InMessage.Direction.Noord;
								break;
								
						case 'O':
								
								im.inbound = InMessage.Direction.Oost;
								break;
								
						case 'Z':
								
								im.inbound = InMessage.Direction.Zuid;
								break;
								
						case 'W':
								
								im.inbound = InMessage.Direction.West;
								break;
								
						default:
								
								incorrectMessage = true;
								break;
								
						}
						switch (message.ToCharArray () [1]) {
						case 'N':
								
								im.outbound = InMessage.Direction.Noord;
								break;
								
						case 'O':
								
								im.outbound = InMessage.Direction.Oost;
								break;
								
						case 'Z':
								
								im.outbound = InMessage.Direction.Zuid;
								break;
								
						case 'W':
								
								im.outbound = InMessage.Direction.West;
								break;
								
						default:
								
								incorrectMessage = true;
								break;
								

						}
						switch (message.ToCharArray () [2]) {
						case 'A':
								
								im.vehicle = InMessage.Vehicle.Auto;
								break;
								
						case 'B':
								
								im.vehicle = InMessage.Vehicle.Bus;
								break;
								
						case 'F':
								
								im.vehicle = InMessage.Vehicle.Fiets;
								break;
								
						case 'V':
								
								im.vehicle = InMessage.Vehicle.Voetganger;
								break;
								
						case 'T':
								
								im.vehicle = InMessage.Vehicle.Trein;
								break;
								
						default:
								
								incorrectMessage = true;
								break;
								
						}
						switch (message.ToCharArray () [3]) {
						case 'R':
								
								im.setting = InMessage.Settings.Rood;
								break;
								
						case 'O':
								
								im.setting = InMessage.Settings.Oranje;
								break;
								
						case 'G':
								
								im.setting = InMessage.Settings.Groen;
								break;
								
						default:
								
								incorrectMessage = true;
								break;
								
						}
				}
				return im;
		}
}
