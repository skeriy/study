using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Store
    {
        private readonly Shop _shop;

        public Store()
        {
            _shop = new Shop();
        }

        public Shop GetShop()
        {
            return _shop;
        }
    }

    public class Good
    {
        public string Name { get; }

        public Good(string name)
        {
            Name = name;
        }
    }

    public class Warehouse
    {
        private readonly Dictionary<Good, int> _existsGoods = new ();

        public Warehouse()
        {
        }

        public void Delive(Good good, int numberOfGoods)
        {
            if (good != null && numberOfGoods > 0)
            {
                int numberOfExistGoods = _existsGoods.GetValueOrDefault(good, 0);
                _existsGoods.Add(good, numberOfGoods + numberOfExistGoods);
            }
        }
        
        public Dictionary<Good, int> GetDictionaryOfGoods()
        {
            return _existsGoods;
        }
        
        public bool IsHaveGoods(Good good, int number)
        {
            var numberOfExistGoods = _existsGoods.GetValueOrDefault(good, 0);
            return numberOfExistGoods != 0 && numberOfExistGoods >= number;
        }
    }

    public class Shop
    {
        private readonly Warehouse _warehouse;
        private readonly Cart _cart;

        public Shop()
        {
            _warehouse = new Warehouse();
            _cart = new Cart(_warehouse);
        }

        public void DeliveGood(Good good, int numberOfGoods)
        {
            _warehouse.Delive(good, numberOfGoods);
        }

        public void ShowGoodsInWarehouse()
        {
            Console.WriteLine("In warehouse:");
            foreach (var entry in _warehouse.GetDictionaryOfGoods())
            {
                Console.WriteLine($"{entry.Key.Name} - {entry.Value}");    
            }
        }

        public Cart GetCart()
        {
            return _cart;
        }

        public void ShowGoodsInCart()
        {
            Console.WriteLine("In cart:");
            foreach (var entry in _cart.GetDictionaryOfGoods())
            {
                Console.WriteLine($"{entry.Key.Name} - {entry.Value}"); 
            }
        }
    }

    public class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly Dictionary<Good, int> _dictionaryOfGoods = new();

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }
        
        public void Add(Good good, int numberOfGoods)
        {
            if (good != null && numberOfGoods > 0 && _warehouse.IsHaveGoods(good, numberOfGoods))
            {
                int numberOfExistGoods = _dictionaryOfGoods.GetValueOrDefault(good, 0);
                _dictionaryOfGoods.Add(good, numberOfGoods + numberOfExistGoods);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
        public Dictionary<Good, int> GetDictionaryOfGoods()
        {
            return _dictionaryOfGoods;
        }

        public string GetPaylinkForOrder()
        {
            Console.WriteLine("Creating paylink:");
            if (_dictionaryOfGoods.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var paylink = new string("https:\\\\paylink\\\\");
            var random = new Random();
            for (var i = 0; i < 16; i++)
            {
                var c = (char) random.Next(0x0410, 0x44F);
                paylink += c;
            }
            Console.WriteLine("Paylink created!");

            return paylink;
        }
    }
}