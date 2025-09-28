using qrcodes;


while (true){
    Console.Clear();
    Console.WriteLine("Enter text: ");
    string? input;
    input = Console.ReadLine();

    QRcode qRcode = new QRcode(input);
    Console.WriteLine("QR code text:");
    Console.WriteLine(qRcode);

    Console.ReadKey();
}