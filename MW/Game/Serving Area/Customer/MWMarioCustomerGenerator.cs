using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public static class MWMarioCustomerGenerator
    {
        private static List<string> _randomcharacter = new List<string>() { "daisy.png", "luigi.png", "mario.png", "mushroom.png", "pinkmushroom.png", "yoshi.png" };
        private static Random _randomMarioNumber = new Random(100);

        public static MWMarioCustomer NewMarioCustomer()
        {
            //create new customer randomly and return it 
            return new MWMarioCustomer(_randomcharacter[_randomMarioNumber.Next(0, 6)]);
            //
        }
    }
}
