using qrcodes;


while (true){
    Console.Clear();
    Console.WriteLine("Enter text: ");
    string? input;
    input = Console.ReadLine();

    QRcode qRcode = new QRcode(input);
    Console.WriteLine("QR code text:");
    Console.WriteLine(qRcode);

    #region type info
    Console.WriteLine("QR version:");
    Console.WriteLine(qRcode.Version);
    Console.WriteLine("Type of coding:");
    Console.WriteLine(qRcode.Mode);

    #endregion


    Console.ReadKey();
}