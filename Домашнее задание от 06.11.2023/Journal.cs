using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Задание 2. Создайте класс «Журнал». Необходимо хранить в полях класса:
название журнала, год основания, описание журнала, контактный телефон,
контактный e-mail. Реализуйте методы класса для ввода данных, вывода
данных, реализуйте доступ к отдельным полям с помощью механизма
свойств.
 */
namespace Program
{
    public class Journal
    {
        private string _title, _description, _contactPhoneNumber, _contactEmail;
        public string Title { get { return _title; } }
        public string Description { get { return _description; } }
        public string ContactPhoneNumber { get { return _contactPhoneNumber; } }
        public string ContactEmail { get { return _contactEmail; } }

        private int _dataOfFoundation;
        public int DataOfFoundation { get { return _dataOfFoundation; } }

        public Journal(string title, string description, string contactPhoneNumber, string contactEmail, int dataFoundation)
        {
            _title = title;
            _description = description;
            _contactPhoneNumber = contactPhoneNumber;
            _contactEmail = contactEmail;
            _dataOfFoundation = dataFoundation;
        }
        public Journal() : this("Журнал", "Следим за успеваемостью школьников", "79227775544", "journal@jo-al.ru", 2023) { }

        public void ShowAllInfo()
        {
            Console.Clear();

            Console.WriteLine("НАЗВАНИЕ ЖУРНАЛА: \"" + _title + "\"");
            Console.WriteLine("ОСНОВАН В " + _dataOfFoundation);
            Console.WriteLine("ОПИСАНИЕ: " + _description);
            Console.WriteLine("КОНТАКТНЫЙ ТЕЛЕФОН: " + _contactPhoneNumber);
            Console.WriteLine("КОНТАКТНЫЙ E-Mail: " + _contactEmail);
        }

        public void SetData()
        {
            ShowAllInfo();

            int action = 0;
            Console.WriteLine("\nКакую информацию о журнале вы хотите изменить?");
            Console.WriteLine("1) Название");
            Console.WriteLine("2) Год основания");
            Console.WriteLine("3) Описание");
            Console.WriteLine("4) Контактный номер телефона");
            Console.WriteLine("5) Контактную электронную почту");
            Console.WriteLine("6) Ничего не хочу менять - я случайно сюда попал");
            Console.Write("?) И я выбираю -> ");

            action = Int32.Parse(Console.ReadLine());

            if (action == 1)
            {
                Console.Write(" Введите новое название -> ");
                _title = Console.ReadLine();
            }
            else if (action == 2)
            {
                Console.Write(" Введите новый год основания -> ");
                _dataOfFoundation = Int32.Parse(Console.ReadLine());
            }
            else if (action == 3)
            {
                Console.Write(" Введите новое описание -> ");
                _description = Console.ReadLine();
            }
            else if (action == 4)
            {
                Console.Write(" Введите новый контактный номер телефона -> ");
                _contactPhoneNumber = Console.ReadLine();
            }
            else if (action == 5)
            {
                Console.Write(" Введите новый контактный E-Mail -> ");
                _contactEmail = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Будьте внимательней, спасибо!");
                return;
            }
            ShowAllInfo();
            SetData();
        }
    }
}
