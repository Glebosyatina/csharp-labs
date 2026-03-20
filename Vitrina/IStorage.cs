using product;

namespace Vitrina
{
    public interface IStorage<T> where T : class, IProductWithQR
    {
        T this[int id] { get; set; }
        int Id { get; set; }
        int ProductCount { get; }
        int Size { get; init; }

        void Add(T product);
        void Add(T product, int index);
        int FindPositionById(int id);
        int FindPositionByName(string name);
        string GetInfoAboutAllProducts();
        string GetInfoAboutAllProductsOnlyText();
        string ProductExists(int id);
        int ProductExists(string productName);
        T? Remove();
        T? Remove(int index);
        T? Replace(T newProduct, int index);
        void ReplaceProducts(int one, int two);
        void SortById();
        void SortByName();
        string ToString();
        void Transposition(int oldPosition, int newPosition);
    }
}