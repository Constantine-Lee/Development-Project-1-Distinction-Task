using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class UnitTest
	{
		DiningTable _diningTable = new DiningTable ();
		WoodenTable _woodenTable = new WoodenTable ();

		Customer _customer = new Customer ("pikachu.png");
		PokemonCustomer _pokemonCustomer = new PokemonCustomer ("pikachu.png");

		[Test ()]
		public void TestDiningTableSetX ()
		{
			_diningTable.SetX (0);
			Assert.AreEqual (_diningTable.DiningTableSprite.X, 0);
		}

		[Test ()]
		public void TestWoodenTableSetX ()
		{
			_woodenTable.SetX (0);
			Assert.AreEqual (_woodenTable.DiningTableSprite.X, 0);
		}

		[Test ()]
		public void TestDiningTableSetY ()
		{
			_diningTable.SetY (0);
			Assert.AreEqual (_diningTable.DiningTableSprite.Y, 0);
		}

		[Test ()]
		public void TestWoodenTableSetY ()
		{
			_woodenTable.SetY (0);
			Assert.AreEqual (_woodenTable.DiningTableSprite.Y, 0);
		}

		[Test ()]
		public void TestDiningTableWaitingField ()
		{
			Assert.IsTrue (_diningTable.Waiting);
			_diningTable.Waiting = false;
			Assert.IsFalse (_diningTable.Waiting);
		}

		[Test ()]
		public void TestWoodenTableWaitingField ()
		{
			Assert.IsTrue (_woodenTable.Waiting);
			_woodenTable.Waiting = false;
			Assert.IsFalse (_woodenTable.Waiting);
		}

		[Test ()]
		public void TestCustomerSetX ()
		{
			_customer.SetX (0);
			Assert.AreEqual (_customer.CustomerSprite.X, 0);
		}

		[Test ()]
		public void TestPokemonCustomerSetX ()
		{
			_pokemonCustomer.SetX (0);
			Assert.AreEqual (_pokemonCustomer.CustomerSprite.X, 0);
		}

		[Test ()]
		public void TestCustomerSetY ()
		{
			_customer.SetY (0);
			Assert.AreEqual (_customer.CustomerSprite.Y, 0);
		}

		[Test ()]
		public void TestPokemonCustomerSetY ()
		{
			_pokemonCustomer.SetY (0);
			Assert.AreEqual (_pokemonCustomer.CustomerSprite.Y, 0);
		}
	}
}
