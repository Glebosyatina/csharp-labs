using product;
using qrcodes;
using Vitrina;

Storage<IProductWithQR> storage = 10;
//storage.Id = 1;

ElectroDrill p = new ElectroDrill(0, "Дрель", "INDEZIT");
ElectroDrill p1 = new ElectroDrill(1, "Дрель1", "MAK");
var ch = new SuperDrill(200, "Электропила", "Не наследуемая электропила");

storage.Add(p);
storage.Add(p1);
storage.Add(ch);


//Console.WriteLine(p);
//Console.WriteLine(ch);
Console.WriteLine(storage);
Console.ReadKey();
////storage2.AddProduct("Стиральная машинка", "INDEZIT");

//ElectroDrill p2 = new ElectroDrill(1, "Супер дрель", "DYSON");
//storage.Add(p2);

//Rubanok r1 = new Rubanok(2, "Рубанок", "Хороший");
//storage.Add(r1);

////storage[0] = storage2[1];

//storage.Id = 10;

//Storage<ElectroDrill> electrodrills = 10;
//var el1 = new ElectroDrill(1, "Електродрель", "Электродрель в отдельном контейнере");
//electrodrills.Add(el1);


Storage<Rubanok> rubanki = 10;
var rub1 = new Rubanok(0, "Новый рубанок", "Самый острый рубанок");
rubanki.Add(rub1);


//присвоение с одной витрины другой
//storageChild[0] = (SuperDrill)storage[1];

//Console.WriteLine("-----------Витрина 1-----------");
//Console.WriteLine(storage);

//Console.WriteLine("-----------Витрина 2-----------");
//Console.WriteLine(electrodrills);

//Console.WriteLine("-----------Витрина 3-----------");
//Console.WriteLine(rubanki);

//Console.WriteLine(storageChild);

//Console.WriteLine("-----------Перемещение элементов с разных витрин-----------");
//storage.Id = 5;
storage[0] = rubanki[0];

Console.WriteLine(storage);
Console.ReadKey();



//ненаследуемый класс
SuperDrill s1 = new SuperDrill(1, "Супер дрель", "Самая лучшая дрель");
storage.Add(s1);
//s1.Id = 55;
Console.WriteLine(storage);

Console.ReadKey();


while (true)
{
    Console.Clear();
    Console.WriteLine($"Доступно товаров на складе: {Warehouse.Product.Count}");
    Console.WriteLine($"Доступно витрин: {Show.Vitrine.Count} {Commands.Capacity()}");
    Console.WriteLine($"Тип вывода QR: {IQRcode.OutputMethod}\n\n");

    Console.WriteLine("1. Выставить товар на витрину");
    Console.WriteLine("2. Снять товар с витрины");
    Console.WriteLine("3. Вывести витрину");
    Console.WriteLine("4. Переставить товары местами");
    Console.WriteLine("5. Заменить товар");
    Console.WriteLine("6. Переместить товар между витринами");
    Console.WriteLine("7. Найти товар по ID");
    Console.WriteLine("8. Найти товар по имени");
    Console.WriteLine("9. Отсортировать товары по ID");
    Console.WriteLine("10. Отсортировать товары по имени");
    Console.WriteLine("11. Добавить новый товар на склад");
    Console.WriteLine("12. Создать новую витрину");
    Console.WriteLine("13. Удалить витрину");
    Console.WriteLine("14. Изменить Id витрины");
    Console.WriteLine("15. Изменить Id товара");
    Console.WriteLine("16. Изменить метод вывода QR");
    Console.WriteLine("0. Выход");

    int command = Commands.ReadNumber("\nВведите номер команды: ");

    Console.Clear();


    switch (command)
    {
        case 1:
            Commands.Add();
            break;
        case 2:
            Commands.Remove();
            break;
        case 3:
            Commands.Print();
            break;
        case 4:
            Commands.Swap();
            break;
        case 5:
            Commands.Replace();
            break;
        case 6:
            Commands.Move();
            break;
        case 7:
            Commands.FindId();
            break;
        case 8:
            Commands.FindName();
            break;
        case 9:
            Commands.SortId();
            break;
        case 10:
            Commands.SortName();
            break;
        case 11:
            Commands.CreateProduct();
            break;
        case 12:
            Commands.CreateVitrine();
            break;
        case 13:
            Commands.DeleteVitrine();
            break;
        case 14:
            Commands.ChangeIdVitrine();
            break;
        case 15:
            Commands.ChangeIdProduct();
            break;
        case 16:
            Commands.ChangeDisplay();
            break;
        case 0:
            Console.WriteLine("Завершение программы...");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Неверная команда. Попробуйте снова");
            Console.ReadKey();
            break;
    }

}