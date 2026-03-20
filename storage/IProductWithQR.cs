using qrcodes;

namespace product
{
    public interface IProductWithQR
    {

        int Id { get; set; }
        string? Info { get; set; }
        IQRcode InfoQR { get;  }
        string? Name { get; set; }
        int EnergoPotreb { get; set; }
        int Power { get; set; }
        int Price { get; set; }



        event EventHandler<IdChangedEventArgs> IdChanged;

    }
}