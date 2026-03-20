using static System.Net.Mime.MediaTypeNames;

namespace qrcodes;

public class QRcode : IQRcode
{
    public QRcode()
    {
        this.mask = Mask.M101;
        this.version = QR.V2;
        this.level = EccLevel.M;
        this.SourceText = "";
    }
    public QRcode(string text)
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
            QrCode = QrCodeBuilder.GetQrCode(sourceText, ref this.version, ref this.mode, ref this.level, ref this.mask);
        }
    }
    public int OutputMethod { get => IQRcode.outputMethod; set { IQRcode.outputMethod = value; } }

    private Mask? mask;
    /// <summary>
    ///    маска
    /// </summary>
    public Mask? Maska => mask;

    private EncodingMode? mode;
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
                return this.SourceText;
            case 1:
                return this.QrCode;
            case 2:
                return this.SourceText + this.QrCode;
        }
        return this.QrCode;
    }
}

