using product;

namespace Vitrina;


public static class ShowcaseExtensions
{

    // Метод-расширение, вызываемый при изменении идентификатора витрины.

    public static void UpdateQrCode<T>(this T cells, Storage<T> showcase) where T : class, IProductWithQR
    {
        cells.UpdateQrCode(showcase, showcase.FindPositionById(cells.Id));
    }

    // Перегрузка метода-расширения для смены позиции.

    public static void UpdateQrCode<T>(this T component, Storage<T> showcase, int position) where T : class, IProductWithQR
    {
        if (component != null)
        {
            component.InfoQR.SourceText = $" {component.Id} {showcase.Id} {position}";
        }
    }
}

