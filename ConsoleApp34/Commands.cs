using product;
using qrcodes;
using System.Text;


internal static class Commands
{
    public static int ReadNumber(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
        {
            Console.WriteLine($"Ошибка! Введите корректное число");
            Console.Write(prompt);
        }
        return value;
    }
    public static string Capacity()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        if (Show.Vitrine.Count == 0) return sb.Append("]").ToString();
        sb.Append($"{Show.Vitrine[0].Size}");
        if (Show.Vitrine.Count == 1) return sb.Append("]").ToString();
        for (int i = 1; i < Show.Vitrine.Count; i++)
        {
            sb.Append(" | ");
            sb.Append(Show.Vitrine[i].Size);
        }
        sb.Append("]");
        return sb.ToString();
    }
    public static void Add()
    {
        int numProduct = ReadNumber($"Введите номер товара со склада (от {Warehouse.Product.Count - Warehouse.Product.Count} до {Warehouse.Product.Count - 1}): ", Warehouse.Product.Count - Warehouse.Product.Count, Warehouse.Product.Count - 1);
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int index = ReadNumber($"Введите номер ячейки (-1 - вставка в первую свободную ячейку)(от {Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size} до {Show.Vitrine[numVitrine].Size - 1}): ", Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size, Show.Vitrine[numVitrine].Size - 1);

        if (index == -1) Show.Vitrine[numVitrine].Add(Warehouse.Product[numProduct]);
        else Show.Vitrine[numVitrine].Add(Warehouse.Product[numProduct], index);

        Warehouse.Product.RemoveAt(numProduct);
        Console.WriteLine("Товар успешно добавлен!");
        Console.ReadLine();
    }

    public static void Remove()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int index = ReadNumber($"Введите номер ячейки (-1 - снятие товара с первой занятой ячейки)(от {Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size} до {Show.Vitrine[numVitrine].Size - 1}): ", Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size, Show.Vitrine[numVitrine].Size - 1);
        if (index == -1)
        {
            var a = Show.Vitrine[numVitrine].Remove();
            if (a != null)
            {
                Warehouse.Product.Add(a);
            }
        }
        else
        {
            var a = Show.Vitrine[numVitrine].Remove(index);
            if (a != null)
            {
                Warehouse.Product.Add(a);
            }
        }
        Console.WriteLine($"Товар успешно удален!");
        Console.ReadLine();
    }

    public static void Print()
    {
        int numVitrine = ReadNumber($"Введите номер витрины: (-1 - вывод всех витрин)(от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count - 1, Show.Vitrine.Count - 1);

        if (numVitrine == -1)
            for (int i = 0; i < Show.Vitrine.Count; i++)
                Console.WriteLine(Show.Vitrine[i]);
        else Console.WriteLine(Show.Vitrine[numVitrine]);

        Console.WriteLine("\n\n\n\n\n");
        Console.ReadLine();

    }

    public static void Swap()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int index1 = ReadNumber($"Введите номер первой ячейки (от {Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size} до {Show.Vitrine[numVitrine].Size - 1}): ", Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size, Show.Vitrine[numVitrine].Size - 1);
        int index2 = ReadNumber($"Введите номер второй ячейки (от {Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size} до {Show.Vitrine[numVitrine].Size - 1}): ", Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size, Show.Vitrine[numVitrine].Size - 1);

        Show.Vitrine[numVitrine].Transposition(index1, index2);
        Console.WriteLine($"Товар успешно переставлен!");
        Console.ReadLine();
    }

    public static void Replace()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int index1 = ReadNumber($"Введите номер ячейки c товаром, который необходимо заменить (от {Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size} до {Show.Vitrine[numVitrine].Size - 1}): ");
        int index2 = ReadNumber($"Введите номер товара со склада, который необходимо выставить (от {Warehouse.Product.Count - Warehouse.Product.Count} до {Warehouse.Product.Count - 1}): ", Warehouse.Product.Count - Warehouse.Product.Count, Warehouse.Product.Count - 1);

        var a = Show.Vitrine[numVitrine].Replace(Warehouse.Product[index2], index1);
        if (a != null) Warehouse.Product.Add(a);
        Warehouse.Product.RemoveAt(index2);
        Console.WriteLine($"Товар успешно заменен!");
        Console.ReadLine();
    }

    public static void Move()
    {
        int numVitrine1 = ReadNumber($"Введите номер витрины, с которой надо переставить (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int index1 = ReadNumber($"Введите номер ячейки c товаром, с которой необходимо переставить (от {Show.Vitrine[numVitrine1].Size - Show.Vitrine[numVitrine1].Size} до {Show.Vitrine[numVitrine1].Size - 1}): ", Show.Vitrine[numVitrine1].Size - Show.Vitrine[numVitrine1].Size, Show.Vitrine[numVitrine1].Size - 1);
        int numVitrine2 = ReadNumber($"Введите номер витрины, на которую надо переставить (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int index2 = ReadNumber($"Введите номер ячейки c товаром, на которую необходимо переставить (от {Show.Vitrine[numVitrine2].Size - Show.Vitrine[numVitrine2].Size} до {Show.Vitrine[numVitrine2].Size - 1}): ", Show.Vitrine[numVitrine2].Size - Show.Vitrine[numVitrine2].Size, Show.Vitrine[numVitrine2].Size - 1);

        Show.Vitrine[numVitrine2][index2] = Show.Vitrine[numVitrine1][index1];
        Console.WriteLine($"Товар успешно переставлен с витрины {numVitrine1}[{index1}] на витрину {numVitrine2}[{index2}]!");
        Console.ReadLine();
    }

    public static void FindId()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int id = ReadNumber($"Введите Id искомого товара: ");
        int index = Show.Vitrine[numVitrine].FindPositionById(id);
        if (index != -1)
        {
            Console.WriteLine($"Товар успешно найден в ячейке {index}");
        }
        else
        {
            Console.WriteLine("Товар не найден!");
        }
        Console.ReadLine();
    }

    public static void FindName()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        Console.Write($"Введите имя искомого товара: ");
        string name = Console.ReadLine();
        int index = Show.Vitrine[numVitrine].FindPositionByName(name);
        if (index != -1)
        {
            Console.WriteLine($"Товар успешно найден в ячейке {index}");
        }
        else
        {
            Console.WriteLine("Товар не найден!");
        }
        Console.ReadLine();
    }
    public static void SortId()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);

        Show.Vitrine[numVitrine].SortById();

        Console.WriteLine($"Товары на витрине успешно отсортированы!");

        Console.ReadLine();
    }

    public static void SortName()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);

        Show.Vitrine[numVitrine].SortByName();

        Console.WriteLine($"Товары на витрине успешно отсортированы!");
        Console.ReadLine();
    }

    public static void CreateProduct()
    {
        int product = ReadNumber($"Введите тип товара (0 - Board | 1 - Furniture Board): ", 0, 1);

        int id = ReadNumber($"Введите Id товара: ");

        Console.Write($"Введите имя товара: ");
        string name = Console.ReadLine();

        Console.Write($"Введите тип дерева: ");
        string info = Console.ReadLine();



        if (product == 0)
        {
            Warehouse.Product.Add(new ElectroDrill(id, name, info));
        }
        else
        {
            Warehouse.Product.Add(new ElectroDrill(id, name, info));
        }
        Console.WriteLine($"Товар успешно добавлен на склад!");

        Console.ReadLine();
    }

    public static void CreateVitrine()
    {
        int size = ReadNumber($"Введите размер витрины: ");
        int id = ReadNumber($"Введите Id витрины: ");
        Show.Vitrine.Add((size, id));
        Console.WriteLine("Витрина успешно создана!");
        Console.ReadLine();
    }
    public static void DeleteVitrine()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);

        Show.Vitrine.RemoveAt(numVitrine);
        Console.WriteLine("Витрина успешно удалена! Номера всех витрин, идущие за удаленной смещены");
        Console.ReadLine();

    }
    public static void ChangeIdVitrine()
    {
        int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
        int id = ReadNumber($"Введите новый Id: ");

        Show.Vitrine[numVitrine].Id = id;
        Console.WriteLine("Id витрины успешно изменен!");
        Console.ReadLine();
    }

    public static void ChangeIdProduct()
    {
        int choice = ReadNumber("Изменить Id товара на (0 - складе | 1 - витрине)", 0, 1);
        if (choice == 0)
        {
            int numProduct = ReadNumber($"Введите номер товара со склада (от {Warehouse.Product.Count - Warehouse.Product.Count} до {Warehouse.Product.Count - 1}): ", Warehouse.Product.Count - Warehouse.Product.Count, Warehouse.Product.Count - 1);
            int id = ReadNumber($"Введите новый Id: ");
            Warehouse.Product[numProduct].Id = id;
        }
        else
        {
            int numVitrine = ReadNumber($"Введите номер витрины (от {Show.Vitrine.Count - Show.Vitrine.Count} до {Show.Vitrine.Count - 1}): ", Show.Vitrine.Count - Show.Vitrine.Count, Show.Vitrine.Count - 1);
            int index = ReadNumber($"Введите номер ячейки c товаром (от {Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size} до {Show.Vitrine[numVitrine].Size - 1}): ", Show.Vitrine[numVitrine].Size - Show.Vitrine[numVitrine].Size, Show.Vitrine[numVitrine].Size - 1);
            int id = ReadNumber($"Введите новый Id: ");

            if (Show.Vitrine[numVitrine][index] != null)
                Show.Vitrine[numVitrine][index].Id = id;
        }
        Console.WriteLine("Id витрины успешно изменен!");
        Console.ReadLine();
    }
    public static void ChangeDisplay()
    {
        int choice = ReadNumber("Выберете тип вывода QR (1 - Text | 2 - QR | 3 - Full): ", 1, 3);
        var a = choice switch
        {
            1 => IQRcode.OutputMethod = 0,
            2 => IQRcode.OutputMethod = 1,
            3 => IQRcode.OutputMethod = 2,
            _ => IQRcode.OutputMethod = 2
        };
        Console.WriteLine("Тип вывода изменен!");
        Console.ReadLine();
    }
}



