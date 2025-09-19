namespace qrcodes;

internal static class QrCodeBuilder
{
    #region TODO GET with Magic
    /// <summary>
    /// ToDo Необходимо восстановить функцию, она почему то сейчас возвращает не QR-код, а исходный текст
    /// </summary>
    public static string GetQrCode(string
   text, ref QR qrCodeVersion, ref EncodingMode?
   codeType, ref EccLevel? needCorrectionLevel,
   ref Mask? maskNum)
    {
        // Этап 1. Полный блок с данными +  подходящий уровень коррекции ошибок +нужная версия QR-кода
        // Тут нужно вызвать 2 функции Magic
        // Этап 2. Блоки с данными + байты 
        //коррекции
        // А тут целых 4 разных функций Magic
        // Этап 3. Создание матрицы QR кода c 
        //лучшей маской
        //// В зависимости от ситуации тут 
        //нужно вызвать одну из двух функций Magic
        // Этап 4. Получение строки QR кода
        //  Есть функция Magic которая 
        //возвращает QR-код в виде строки
        return text;
    }
    #endregion
}

