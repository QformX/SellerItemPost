using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            var posts = new List<Post>();
            CreatePosts(posts);
            Responce2(posts, "Макароны");
            Responce3(posts, "Птицефабрика");
            Console.ReadKey();
        }

        static void CreatePosts(List<Post> posts)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите id поставки");
                int idP = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите кол-во товаров");
                int countP = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите дату поставки");
                string dateP = Console.ReadLine();
                posts.Add(new Post(idP, countP, dateP, Item.CreateItem(), Seller.CreateItem()));
            }
        }

        //доработать 1 запрос связанный с датой поставки

        static void Responce2(List<Post> posts, string f_name)
        {
            var filter = from post in posts
                                where post.GetItemName() == f_name
                                select post;
            foreach (var item in filter)
            {
                Console.WriteLine(item.GetSellerName());
            }
        }

        static void Responce3(List<Post> posts, string f_name)
        {
            var filter = from post in posts
                         where post.GetSellerName() == f_name
                         select post;
            foreach (var item in filter)
            {
                Console.WriteLine(item.GetItemName());
            }
        }
    }

    class Item
    {
        public int Id;
        public string Name;

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Item CreateItem()
        {
            Console.WriteLine("Введите id товара");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите название");
            string name = Console.ReadLine();

            return new Item(id, name);
        }
    }

    class Seller
    {
        public int Id;
        public string CompName;

        public Seller(int id, string compName)
        {
            Id = id;
            CompName = compName;
        }

        public static Seller CreateItem()
        {
            Console.WriteLine("Введите id поставщика");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите название");
            string name = Console.ReadLine();

            return new Seller(id, name);
        }
    }

    class Post
    {
        int Id;
        int Count;
        string Date;
        Item Item;
        Seller Seller;

        public Post(int id, int count, string date, Item item, Seller seller)
        {
            Id = id;
            Count = count;
            Date = date;
            Item = item;
            Seller = seller;
        }

        public string GetItemName()
        {
            return Item.Name;
        }

        public string GetSellerName()
        {
            return Seller.CompName;
        }
    }

}
