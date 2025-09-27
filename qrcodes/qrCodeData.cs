public record QrCodeData
{
    public QR Version { get; init; } = QR.V1;
    public EccLevel CorrectionLevel { get; init; } = EccLevel.Q;
    public string Data { get; init; } = "";
}