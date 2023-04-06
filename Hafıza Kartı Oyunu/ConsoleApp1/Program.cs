using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Kartlar tahtası oluşturma
        string[,] board = new string[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                board[i, j] = "X"; // tüm kartlar kapalı olarak başlar
            }
        }

        // Kartların içine harfleri random ve çift olarak dağıtma
        Random random = new Random();
        DateTime startTime = DateTime.Now;
        List<string> cards = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H" };
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }

        // Oyun döngüsü
        int numGuesses = 0; // toplam tahmin sayısı
        while (true)
        {
            // Kartları tahtayı ekrana yazdırma
            Console.WriteLine("Kartlar:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Kullanıcıdan bir kart seçmesini isteme ve seçilen kartı açma
            Console.WriteLine("Lütfen bir kart seçin (1-16 arasında bir sayı girin): ");
            int choice1 = Convert.ToInt32(Console.ReadLine()) - 1; // kullanıcının seçtiği kartın indeksi
            Console.WriteLine("Seçtiğiniz kart: " + cards[choice1]);
            board[choice1 / 4, choice1 % 4] = cards[choice1]; // seçilen kartı açık olarak işaretle

            // Kullanıcıdan ikinci kart seçmesini isteme ve seçilen kartı açma
            Console.WriteLine("Lütfen başka bir kart seçin (1-16 arasında bir sayı girin): ");
            int choice2 = Convert.ToInt32(Console.ReadLine()) - 1; // kullanıcının seçtiği kartın indeksi
            Console.WriteLine("Seçtiğiniz kart: " + cards[choice2]);

            // Kartları kontrol etme
            if (cards[choice1] == cards[choice2])
            {
                Console.WriteLine("Tebrikler! Bir çift buldunuz.");
                board[choice1 / 4, choice1 % 4] = cards[choice1]; // ilk kartı açık olarak işaretle
                board[choice2 / 4, choice2 % 4] = cards[choice2]; // ikinci kartı açık olarak işaretle
            }
            else
            {
                Console.WriteLine("Maalesef, seçtiğiniz kartlar eşleşmiyor.");
                board[choice1 / 4, choice1 % 4] = "X"; // ilk kartı kapalı olarak işaretle
                board[choice2 / 4, choice2 % 4] = "X"; // ikinci kartı kapalı olarak işaretle
            }

            // Tahmin sayısını güncelleme
            numGuesses++;

            // Tüm kartlar açıldıysa oyunu bitirme
            bool allCardsOpen = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == "X")
                    {
                        allCardsOpen = false;
                    }
                }
            }
            if (allCardsOpen)
            {
                Console.WriteLine("Tebrikler, tüm kartları açtınız!");
                DateTime endTime = DateTime.Now;
                TimeSpan elapsedTime = endTime - startTime;
                Console.WriteLine("Süre Geçti: {0:mm\\:ss\\:fff}", elapsedTime);
                Console.WriteLine("Toplam tahmin sayısı: " + numGuesses);
                break;
            }
        }
    }
}
