using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            
            var iPhone12 = new Good("IPhone 12");
            var iPhone11 = new Good("IPhone 11");
            
            store.GetShop().DeliveGood(iPhone11, 1);
            store.GetShop().DeliveGood(iPhone12, 5);

            //Вывод всех товаров на складе с их остатком
            store.GetShop().ShowGoodsInWarehouse();

            var cart = store.GetShop().GetCart();
            
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 1); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            store.GetShop().ShowGoodsInCart();

            Console.WriteLine(cart.GetPaylinkForOrder());
        }
    }
}