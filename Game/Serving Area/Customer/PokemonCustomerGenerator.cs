using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public static class PokemonCustomerGenerator
	{
		private static List<string> _random = new List<string> () {"Tweety.png" , "pikachu.png", "charizard.png", "eve.png", "mew.png", "meowth.png"};
		private static Random _randomNumber = new Random (100);

		public static PokemonCustomer NewCustomer ()
		{
			//create new customer randomly and return it 
			return new PokemonCustomer (_random [_randomNumber.Next (0, 6)]);
			//
		}
	}
}
