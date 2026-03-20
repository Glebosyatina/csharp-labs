using product;
internal static class Warehouse
{
    public static List<IProductWithQR> Product { get; set; } = new List<IProductWithQR>
    {
        new ElectroDrill(1, "Супер дрель", "Купи меня"),
        new SuperDrill(2, "Супер дрель", "Купи крутую дрель"),
        new Rubanok(3, "Супер рубанок", "Купи крутой рубанок")
    };
}
