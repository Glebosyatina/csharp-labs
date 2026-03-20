using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qrcodes;

namespace product
{
    public class Rubanok : Product, IProductWithQR
    {
        private int energoPotreb;
        private int power;
        private int price;
        private int zatochka;

        public Rubanok(int id, string name, string info, int energo = 100, int pow = 100, int price = 1000) : base(id, name, info)
        {
            EnergoPotreb = energo;
            Power = pow;
            Price = price;
            Zatochka = 100;
            qr = new QRcode(info);
        }


        public int EnergoPotreb { get => energoPotreb; set => energoPotreb = value; }
        public int Power { get => power; set => power = value; }
        public int Price { get => price; set => price = value; }
        public int Zatochka { get => zatochka; set => zatochka = value; }
    }
}
