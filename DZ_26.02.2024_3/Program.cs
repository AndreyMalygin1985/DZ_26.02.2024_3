// Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную строку используя шифр Цезаря.
// Из Википедии: Шифр Цезаря — это вид шифра подстановки, в котором каждый символ в открытом тексте заменяется символом,
// находящимся на некотором постоянном числе позиций левее или правее него в алфавите.
// Например, в шифре со сдвигом вправо на 3, A была бы заменена на D, B станет E, и так далее.
// Подробнее тут: https://en.wikipedia.org/wiki/Caesar_ cipher.
// Кроме механизма шифровки, реализуйте механизм расшифрования.

class CaesarCipher
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введите строку для шифрования, на Русской раскладке:");
        string plainText = Console.ReadLine();

        Console.WriteLine("Введите сдвиг для шифра Цезаря (целое число):");
        int shift = int.Parse(Console.ReadLine());

        string encryptedText = Encrypt(plainText, shift);
        Console.WriteLine($"Зашифрованная строка: {encryptedText}");

        string decryptedText = Decrypt(encryptedText, shift);
        Console.WriteLine($"Расшифрованная строка: {decryptedText}");
    }

    static string Encrypt(string input, int shift)
    {
        string result = "";
        foreach (char c in input)
        {
            if (char.IsLetter(c)) {
                char baseChar = (char)(char.IsLower(c) ? 'а' : 'А');
                char shiftedChar = (char)(baseChar + (c - baseChar + shift) % 32);
                result += shiftedChar;
            }
            else {
                result += c;
            }
        }
        return result;
    }

    static string Decrypt(string input, int shift)
    {
        return Encrypt(input, -shift);
    }
}