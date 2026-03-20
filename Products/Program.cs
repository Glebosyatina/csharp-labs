using product;
using qrcodes;
using Vitrina;

Storage<IProductWithQR> storage = 10;
storage.Id = 1;

//Storage<ProductWithQrChild> storage2 = 10;
//storage2.Id = 2;

ElectroDrill p = new ElectroDrill(0, "Дрель", "INDEZIT");
storage.AddProduct(p);

//storage2.AddProduct("Стиральная машинка", "INDEZIT");

ElectroDrill p2 = new ElectroDrill(1, "Супер дрель", "DYSON");
storage.AddProduct(p2);

Rubanok r1 = new Rubanok(2, "Рубанок", "Хороший");
storage.AddProduct(r1);

//storage[0] = storage2[1];

storage.Id = 10;

Storage<ElectroDrill> electrodrills = 10;
var el1 = new ElectroDrill(1, "Електродрель", "Электродрель в отдельном контейнере");
electrodrills.AddProduct(el1);


Storage<Rubanok> rubanki = 10;

var rub1 = new Rubanok(0, "Новый рубанок", "Самый острый рубанок");
rubanki.AddProduct(rub1);

var ch = new SuperDrill(1, "Электропила", "Не наследуемая электропила");
Storage<SuperDrill> storageChild = 10;
storageChild.AddProduct(ch);

ch.Info = "Супер дрель экстра класса";


Console.WriteLine(storage);

Console.WriteLine(electrodrills);

Console.WriteLine(rubanki);

Console.WriteLine(storageChild);

Console.ReadKey();

while (true)
{
    Console.Clear();

    Console.WriteLine("Что вы хотите сделать?");
    Console.WriteLine("a - добавить товар");
    Console.WriteLine("d - удалить товар");
    Console.WriteLine("r - поменять товары местами");
    Console.WriteLine("f - найти товар по id");
    Console.WriteLine("n - найти товар по названию");
    Console.WriteLine("v - просмотреть информацию о товарах");
    Console.WriteLine("t - просмотреть информацию о товарах, только в текстовом виде");

    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "a":
            Console.WriteLine("Введите название товара: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Введите информацию о товаре: ");
            string? info = Console.ReadLine();
            storage.AddProduct(name, info);
            break;
        case "d":
            Console.WriteLine("Введите номер товара для удаления: ");
            var id = Convert.ToInt32(Console.ReadLine());
            storage.RemoveProduct(id);
            break;

        case "r":
            Console.WriteLine("Введите номер первого товара");
            int one = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер второго товара");
            int two = Convert.ToInt32(Console.ReadLine());
            storage.ReplaceProducts(one, two);
            Console.WriteLine("Товары поменяны местами");
            break;
        case "f":
            Console.WriteLine("Введите id товара для поиска");
            int d = Convert.ToInt32(Console.ReadLine());
            var s = storage.ProductExists(d);
            Console.WriteLine(s);
            break;
        case "n":
            Console.WriteLine("Введите название товара для поиска");
            var nFind = Console.ReadLine();
            var sFound = storage.ProductExists(nFind);
            Console.WriteLine(sFound);
            break;
        case "v":
            info = storage.GetInfoAboutAllProducts();
            Console.WriteLine(info);
            break;
        case "t":
            info = storage.GetInfoAboutAllProductsOnlyText();
            Console.WriteLine(info);
            break;
        default:
            Console.WriteLine("Неизвестная команда");
            break;
    }


    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey();


}