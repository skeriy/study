using ConsoleApp;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateBrokenWeaponTest()
        {
            Weapon w = new Weapon(0,0);
        }
    }
}