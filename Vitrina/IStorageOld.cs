using product;

namespace Vitrina
{
    public interface IStorageO<T> where T : class
    {
        T this[int id] { get; set; }

        int Id { get; set; }

        void Add(T product);
        void Add(T product, int index);

        string GetInfoAboutAllProducts();
        string GetInfoAboutAllProductsOnlyText();
        string ProductExists(int id);
        int ProductExists(string productName);
        void Remove(int id);
        void ReplaceProducts(int one, int two);

    }
}