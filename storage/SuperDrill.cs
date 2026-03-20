using System.Runtime.CompilerServices;
using qrcodes;

namespace product
{

    /// <summary>
    /// класс от которого нельзя наследоваться и хранит qr код в виде record
    /// </summary>
    public sealed class SuperDrill : ElectroDrill, IProductWithQR
    {
        public SuperDrill(int id, string name, string info, int energo = 100, int pow = 100, int price = 1000)
            : base(id, name, info)
        {
            EnergoPotreb = energo;
            Power = pow;
            Price = price;
            qr = new QRClassRecord(id.ToString());
            _qr = new QRClassRecord(id.ToString());
        }

        IQRcode IProductWithQR.InfoQR => _qr;

        private QRClassRecord _qr;

    }

}
