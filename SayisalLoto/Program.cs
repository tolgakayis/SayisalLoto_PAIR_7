//Sayisal loto - PAIR - 7
//columnCount = ex: 8 -->up to 8. More than 8 is not allowed //1-49-->2,6,15,19,45,48 -->column -->all numbers are different
//get column count from the user. ex : 3 //play the game randomly-->use random class in c# //output ex: //2,6,15,18,45,48 //4,6,18,19,43,49 //1,6,15,25,45,48
//all columns must be the type of integer array

Console.WriteLine("Kolon sayısını giriniz");

int columnCount = int.Parse(Console.ReadLine());

while (columnCount < 1 || columnCount > 8)
{
    Console.WriteLine("En fazla 8, en az 1 kolon girebilirsiniz.");
    columnCount = int.Parse(Console.ReadLine());
}

int[,] sayilar = new int[columnCount,6];

for (int i = 0; i < columnCount; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.WriteLine($"{i+1}. kolondaki {j+1}. sayıyı giriniz: ");
        sayilar[i, j] = int.Parse(Console.ReadLine());
        for (int k = 0; k < j; k++)
        {
            while (sayilar[i, k] == sayilar[i, j] || sayilar[i, j] < 1 || sayilar[i, j] > 49)
            {
                Console.WriteLine("Farklı bir sayı giriniz: ");
                sayilar[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    Console.Clear();
}

SayiSirala(columnCount, sayilar);

for (int i = 0;i < columnCount;i++)
{
    for(int j = 0;j < 6; j++)
    {
        Console.Write(sayilar[i,j] + " ");
    }
    Console.WriteLine();
}

int[] RandomNumbers = new int[6];
Random rastgele = new Random();

for (int i = 0; i < 6; i++)
{
    RandomNumbers[i] = rastgele.Next(1, 50);
    for (int j = 0; j < i; j++)
    {
        while (RandomNumbers[i] == RandomNumbers[j])
        {
            RandomNumbers[i] = rastgele.Next(1, 50);
            j = 0;
        }
    }
}

Console.WriteLine();
Array.Sort(RandomNumbers);

for (int i = 0; i < 6 ;i++)
{
    Console.Write(RandomNumbers[i] + " ");
}
static void SayiSirala(int kolonSayisi, int[,] sayilar)
{
    int[] tek_boyutlu_dizi = new int[6];
    for (int i = 0; i < kolonSayisi; i++)
    {
        for (int j = 0; j < 6; j++)
        {
            tek_boyutlu_dizi[j] = sayilar[i, j];
        }


        Array.Sort(tek_boyutlu_dizi);

        for (int j = 0; j < 6; j++)
        {
            sayilar[i, j] = tek_boyutlu_dizi[j];
        }
    }
}