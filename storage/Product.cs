using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography;
using qrcodes;

namespace product
{
    public abstract class Product
    {

        protected int id;
        protected string? name; //имя товара
        protected string? info; //информация о товаре

        protected IQRcode qr; //информация в виде qr кода

        protected Product(int id, string name, string info)
        {
            Id = id;
            Name = name;
            Info = info;
            qr = new QRcode(info);
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                if (this.qr != null)
                {
                    var oldId = id;
                    var _id = value;
                    qr.SourceText = this.Id.ToString();
                    OnIdChanged(new IdChangedEventArgs(oldId, _id));

                }
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder s = new();

            s.Append("Номер товара: ");
            s.Append(this.Id);
            s.Append("\n");
            s.Append("Название товара: ");
            s.Append(this.Name);
            s.Append("\n");
            s.Append("Информация о товаре: ");
            s.Append(this.Info);
            s.Append("\n");
            s.Append("Текст qr: ");
            s.Append(this.InfoQR);
            s.Append("\n");
            s.Append("QR код товара:");
            s.Append("\n");
            s.Append(this.InfoQR.QrCode);
            s.Append("\n");

            return s.ToString();
        }
        public string? Name { get => name; set => name = value; }
        public string? Info
        {
            get => info;
            set
            {
                info = value;
                if (this.qr != null)
                {
                    InfoQR.SourceText = this.info.ToString();
                }
            }
        }

        public IQRcode InfoQR => qr;

        public event EventHandler<IdChangedEventArgs> IdChanged;

        protected virtual void OnIdChanged(IdChangedEventArgs e)
        {
            IdChanged?.Invoke(this, e);
        }

    }
}

public sealed class IdChangedEventArgs(int oldId, int newId) : EventArgs
{
    public int OldId { get; } = oldId;
    public int NewId { get; } = newId;
}





