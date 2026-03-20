using System.Text;
using product;


namespace Vitrina
{
    public class Storage<T> : IStorage<T> where T : class, IProductWithQR
    {

        //храним продукты ввиде списка
        private readonly T[] products;

        public int Size { get; init; }

        //количество продуктов
        private readonly int readonlyproductCount;
        public int ProductCount { get { return products.Length; } }


        private Storage(int n)
        {
            //инициализация 
            products = new T[n];
            var i = new Random().Next(10);
            id = i;
        }

        private Storage((int a, int b) info)
        {
            if (info.a <= 0) info.a = 0;
            products = new T[info.a];
            Size = info.a;
            id = info.b;
        }


        // Добавление товара в первую пустую ячейку (позицию)
        public void Add(T product)
        {
            if (product == null) return;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    this[i] = product;
                    return;
                }
            }
        }

        // Добавление товара в конкретную позицию (если позиция занята — заменяем).

        public void Add(T product, int index)
        {
            this[index] = product;
        }


        /// <summary>
        /// удаление первого товара и удаление по id
        /// </summary>
        public T? Remove()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null)
                {
                    return this[i];
                }
            }
            return null;
        }
        // Удаление товара из конкретной позиции
        public T? Remove(int index)
        {
            if (!Border(index)) return null;
            return this[index];
        }

        // Замена товара в конкретной позиции на новый (возвращает товар, стоящий до замены, или null, если ячейка пуста)
        public T? Replace(T newProduct, int index)
        {
            if (!Border(index)) return null;
            var tmp = products[index];
            this[index] = newProduct;
            return tmp;
        }

        //Проверка на выход за пределы массива
        private bool Border(int index) => index >= 0 && index < products.Length;

        // Перестановка товара на витрине
        public void Transposition(int oldPosition, int newPosition)
        {
            if (!Border(oldPosition)
                || !Border(newPosition)
                || oldPosition == newPosition
                || (products[oldPosition] == null && products[newPosition] == null)) return;

            (this[oldPosition], this[newPosition]) = (this[newPosition], this[oldPosition]);
        }

        //выводить информацию о товаре, в отсортированном виде
        public string GetInfoAboutAllProducts()
        {
            StringBuilder s = new();
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null)
                {
                    s.Append(products[i]);
                }
            }

            return s.ToString();
        }
        public string GetInfoAboutAllProductsOnlyText()
        {
            StringBuilder s = new();
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null)
                {
                    s.Append("Id: " + products[i].Id + " Name: " + products[i].Name + " Info: " + products[i].Info + '\n');
                }
            }
            return s.ToString();
        }
        public override string ToString()
        {
            return GetInfoAboutAllProducts();
        }


        /// <summary>
        ///    менять товары местами, заменять на новый
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        public void ReplaceProducts(int one, int two)
        {
            if (one >= products.Length || one < 0 ||
                two >= products.Length || two < 0 ||
                (products[one] == null && products[two] == null))
            {
                return;
            }
            (this[one], this[two]) = (this[two], this[one]);
        }

        /// <summary>
        /// определять наличие товара, по кода или названию
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public int ProductExists(string productName)
        {
            StringBuilder s = new();
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null && products[i].Name == productName)
                {
                    s.Append(products[i]);
                    return i;
                }
            }
            return -1;
        }
        public string ProductExists(int id)
        {
            StringBuilder s = new();
            if (products[id] != null)
            {
                s.Append(products[id]);
                return s.ToString();
            }
            return "Товар не найден";
        }


        //id витрины
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value == id) return;
                id = value;

                vitrineIdChanged?.Invoke(this);
            }
        }

        // Делегат, информирующий о смене идентификатора витрины
        private Action<Storage<T>> vitrineIdChanged;

        // Оператор явного приведения int -> Vitrine: Vitrine v = (Vitrine)10;
        // Также поддерживает неявное присвоение: Vitrine v = 10;
        public static implicit operator Storage<T>(int size) => new Storage<T>(size);

        public static implicit operator Storage<T>((int, int) info) => new Storage<T>(info);

        public T this[int idx]
        {
            get
            {
                if (idx >= products.Length) return null;
                if (products[idx] == null)
                {
                    return null;
                }

                vitrineIdChanged -= products[idx].UpdateQrCode;  // Отписка от делегата смены идентификатора витрины (при изменении id витрины, QR не изменится)
                products[idx].IdChanged -= OnComponentIdChanged;     // Отписка от делегата смены идентификатора товара (при изменении id товара, QR изменится лишь на id товара)

                var tmp = products[idx];
                products[idx] = null;
                return tmp;
            }
            set
            {
                if (idx >= products.Length) return;

                if (products[idx] != null) _ = this[idx];// Отписка от делегата смены идентификатора товара (при изменении id товара, QR изменится лишь на id товара)

                products[idx] = value;
                if (value != null)
                {
                    //вызов метода расширения
                    products[idx].UpdateQrCode(this, idx);

                    vitrineIdChanged += value.UpdateQrCode;    // Подписка на делегат смены идентификатора витрины (при изменении id витрины, QR изменится с учетом нового id и позиции товара)
                    value.IdChanged += OnComponentIdChanged;    // Подписка на делегат смены идентификатора товара (при изменении id товара, QR изменится на [id товара | id витрины | позиция])
                }

            }
        }


        // Сортировка товаров на витрине по идентификатору
        public void SortById() => SortBy((a, b) => a.Id.CompareTo(b.Id));


        // Сортировка товаров по наименованию.
        public void SortByName() => SortBy((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));

        private void SortBy(Comparison<T> comparison)
        {
            Array.Sort(products, (a, b) =>
            {
                if (a == null && b == null) return 0;
                if (a == null) return 1;
                if (b == null) return -1;
                return comparison(a, b);
            });
            vitrineIdChanged?.Invoke(this);

        }

        // Поиск позиции по идентификатору
        public int FindPositionById(int id) => Find(c => c.Id == id);

        // Поиск позиции по имени
        public int FindPositionByName(string name) => Find(c => c.Name == name);

        // Универсальный поиск
        private int Find(Predicate<T> predicate)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null && predicate(products[i]))
                    return i;
            }
            return -1;
        }


        private void OnComponentIdChanged(object sender, IdChangedEventArgs e)
        {
            if (sender is T component)
            {
                component.UpdateQrCode(this);
            }
        }

        // Изменяет QR товара с указанием витрины и позиции
        private void UpdateQrCode(T component, int position)
        {
            component.InfoQR.SourceText = $"{component.InfoQR.SourceText} {component.Id} {Id} {position}";
        }


    }
}
