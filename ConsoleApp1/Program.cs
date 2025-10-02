using qrcodes;


while (true){
    Console.Clear();
    Console.WriteLine("Enter text: ");
    string? input;
    input = Console.ReadLine();

    QRcode qRcode = new QRcode(input);

    Console.WriteLine("Method of output(0 - only text, 1 - only qr code, 2 - text and qr code");
    var t = Convert.ToInt32(Console.ReadLine());
    switch (t)
    {
        case 0:
            Console.WriteLine("Text:");
            Console.WriteLine(qRcode.SourceText);
            break;
        case 1:
            Console.WriteLine("QR code:");
            Console.WriteLine(qRcode);
            break;
        case 2:
            Console.WriteLine("Text:");
            Console.WriteLine(qRcode.SourceText);
            Console.WriteLine("QR code:");
            Console.WriteLine(qRcode);
            break;
    }


    #region type info
    Console.WriteLine("QR version:");
    Console.WriteLine(qRcode.Version);
    Console.WriteLine("Type of coding:");
    Console.WriteLine(qRcode.Mode);

    #endregion


    Console.ReadKey();
}