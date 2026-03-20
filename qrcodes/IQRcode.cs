
namespace qrcodes
{
    public interface IQRcode
    {
        EccLevel? Level { get; }
        Mask? Maska { get; }
        EncodingMode? Mode { get; }
        static int OutputMethod { get; set; }
        string QrCode { get;  }
        string SourceText { get; set; }
        QR Version { get; }

        public static int outputMethod = 0;

    }

    //создаем record реализующий интерфейс
    public record QRClassRecord : IQRcode
    {
        public QRClassRecord()
        {
            this.mask = Mask.M101;
            this.version = QR.V2;
            this.level = EccLevel.M;
            this.SourceText = "";
        }
        public QRClassRecord(string text)
        {
            this.mask = Mask.M101;
            this.version = QR.V2;
            this.level = EccLevel.M;
            this.SourceText = text;
        }
        private string? sourceText;
        /// <summary>
        /// исходный текст
        /// </summary>
        public string SourceText
        {
            get => sourceText;
            set
            {
                sourceText = value;
                QrCode = QrCodeBuilder.GetQrCode(value, ref this.version, ref this.mode, ref this.level, ref this.mask);
            }
        }
        private int outputMethod = 0;
        public int OutputMethod { get => outputMethod; set { outputMethod = value; } }

        private Mask? mask;
        /// <summary>
        ///    маска
        /// </summary>
        public Mask? Maska => mask;

        private EncodingMode? mode = EncodingMode.Binary;
        /// <summary>
        ///  способ вывода
        /// </summary>
        public EncodingMode? Mode => mode;

        private QR version;
        /// <summary>
        /// версия кода
        /// </summary>
        public QR Version => version;

        private EccLevel? level;
        /// <summary>
        /// степень коррекции
        /// </summary>
        public EccLevel? Level => level;

        private string qrCode;

        public string QrCode { get { return qrCode; } set { qrCode = value; } }     // qr код

        public override string ToString()
        {
            switch (OutputMethod)
            {
                case 0:
                    return "*" + this.SourceText  + "*\n";
                case 1:
                    return this.QrCode;
                case 2:
                    return "*" + this.SourceText + "*\n" + this.QrCode;
            }
            return this.QrCode;


        }

    }
}