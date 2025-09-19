namespace qrcodes;

public class QRcode
{
    public QRcode(string? text)
    {
        this.SourceText = text;
        this.mode = EncodingMode.Numeric;
        this.mask = Mask.M101;
        this.mode = EncodingMode.Numeric;
        this.version = QR.V1;
        this.level = EccLevel.M;
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
            QrCode = QrCodeBuilder.GetQrCode(sourceText, ref version, ref mode, ref level, ref mask);
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
        return this.SourceText;
    }
}

