namespace qrcodes;

public class QRcode
{
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
    }//текст для кодирования

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

    public string QrCode { get; private set; }     // qr код

    public override string ToString()
    {
        return this.QrCode;
    }
}

