using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPhone
{
    class Program
    {
        internal static List<Phone> Phones { get; set; }
        internal static int Command { get; set; }
        static void Main(string[] args)
        {
            Phones = new List<Phone>();
            while (Command != 6)
            {
                CommandsList();

                try
                {
                    Console.WriteLine("Введите команду: ");
                    Command = int.Parse(Console.ReadLine());
                    switch (Command)
                    {
                        case 1:
                            Phones.Add(CommandPhones(new Phone()));
                            Console.WriteLine("Успешно");
                            break;

                        case 2:
                            Console.Write("Введите ID: ");
                            int idEdit = int.Parse(Console.ReadLine());
                            var editPhone = Phones.FirstOrDefault(item => item.ID == idEdit);
                            if (editPhone != null)
                            {
                                CommandPhones(editPhone);

                                Console.WriteLine("Успешно");
                            }
                            else
                            {
                                Console.WriteLine("Неудача");

                            }
                            break;
                        case 3:
                            Console.Write("Введите ID: ");
                            int idRemove = int.Parse(Console.ReadLine());
                            var removePhone = Phones.FirstOrDefault(item => item.ID == idRemove);
                            if (removePhone != null)
                            {
                                Phones.Remove(removePhone);
                                Console.WriteLine("Успешно");
                            }
                            else
                            {
                                Console.WriteLine("Неудача");
                            }
                            break;
                        case 4:
                            foreach (var phone in Phones)
                            {
                                Console.WriteLine(phone.ID);
                                Console.WriteLine(phone.Model);
                                Console.WriteLine(phone.Battery);
                                Console.WriteLine(phone.Camera);
                                Console.WriteLine(phone.Screen);
                                Console.WriteLine(phone.Memory);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Введите ключевое слово:");
                            string key = Console.ReadLine();
                            var searchPhone = Phones.Where(item => item.Model.Contains(key) || item.Battery.Contains(key) || item.Camera.Contains(key) 
                            || item.Screen.Contains(key) || item.Memory.Contains(key)).ToList();
                            foreach (var phone in searchPhone)
                            {
                                Console.WriteLine(phone.ID);
                                Console.WriteLine(phone.Model);
                                Console.WriteLine(phone.Battery);
                                Console.WriteLine(phone.Camera);
                                Console.WriteLine(phone.Screen);
                                Console.WriteLine(phone.Memory);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
                internal static Phone CommandPhones(Phone phone)
                {
                    if (phone.ID == 0)
                    {
                        phone = new Phone();
                        Console.Write("Введите ваше ID: ");
                        phone.ID = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Модель: ");
                    phone.Model = Console.ReadLine();
                    Console.Write("Батарея: ");
                    phone.Battery = Console.ReadLine();
                    Console.Write("Камера: ");
                    phone.Camera = Console.ReadLine();
                    Console.Write("Экран: ");
                    phone.Model = Console.ReadLine();
                    Console.Write("Память: ");
                    phone.Battery = Console.ReadLine();               
                    return phone;
                }
                static void CommandsList()
                {
                    Console.WriteLine("1. Добавление");
                    Console.WriteLine("2. Редактирование");
                    Console.WriteLine("3. Удаление");
                    Console.WriteLine("4. Просмотр");
                    Console.WriteLine("5. Поиск");
                    Console.WriteLine("5. Закрытие проги");
                }
    }
}

