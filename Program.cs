/*Задание 2: 
   1.Создайте класс «Магазин», который должен хранить следующую информацию: 
 * название магазина; 
 * адрес магазина; 
 * тип магазина:  продовольственный,  хозяйственный,  одежда,  обувь. 
 * 2. Реализуйте в классе методы и свойства, необходимые для работы класса. 
 * Класс должен реализовывать интерфейс IDisposable. 
 * Напишите код тестирования функциональности класса.
 * Напишите код для вызова метода Dispose.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class My_Store2 : IDisposable
{

    public string Name { get; set; }
    public string Address { get; set; }
    public StoreType Type { get; set; }

    public My_Store2(string name, string address, StoreType type)
    {
        Name = name;
        Address = address;
        Type = type;
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Название магазина: {Name}");
        Console.WriteLine($"Адрес магазина: {Address}");
        Console.WriteLine($"Тип магазина: {Type}");
    }

    public void Dispose()
    {
        Console.WriteLine($"Магазин '{Name}' закрыт и освобождает ресурсы.");
    }
}

enum StoreType
{
    Food,
    Household,
    Clothing,
    Footwear
}

class Program
{
    static List<My_Store2> stores = new List<My_Store2>();

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить магазин");
            Console.WriteLine("2. Удалить магазин");
            Console.WriteLine("3. Вывести все магазины на экран");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStore();
                    break;
                case "2":
                    RemoveStore();
                    break;
                case "3":
                    DisplayStores();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddStore()
    {
        Console.Write("Введите название магазина: ");
        string name = Console.ReadLine();
        Console.Write("Введите адрес магазина: ");
        string address = Console.ReadLine();
        Console.WriteLine("Выберите тип магазина:");
        Console.WriteLine("1. Food");
        Console.WriteLine("2. Household");
        Console.WriteLine("3. Clothing");
        Console.WriteLine("4. Footwear");
        Console.Write("Введите номер типа: ");
        if (Enum.TryParse(Console.ReadLine(), out StoreType type))
        {
            My_Store2 store = new My_Store2(name, address, type);
            stores.Add(store);
            Console.WriteLine("Магазин добавлен.");
        }
        else
        {
            Console.WriteLine("Неправильный выбор типа магазина.");
        }
    }

    static void RemoveStore()
    {
        Console.Write("Введите название магазина для удаления: ");
        string name = Console.ReadLine();
        My_Store2 storeToRemove = stores.Find(s => s.Name == name);
        if (storeToRemove != null)
        {
            storeToRemove.Dispose();
            stores.Remove(storeToRemove);
            Console.WriteLine("Магазин удален.");
        }
        else
        {
            Console.WriteLine("Магазин не найден.");
        }
    }

    static void DisplayStores()
    {
        if (stores.Count > 0)
        {
            Console.WriteLine("Список всех магазинов:");
            foreach (var store in stores)
            {
                store.DisplayInformation();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Нет сохраненных магазинов.");
        }
    }
}




