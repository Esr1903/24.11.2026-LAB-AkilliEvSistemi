// 1306220178_Esra_Karadağ 24/11/2026
using System;
using System.Collections.Generic;

// Cihaz türlerini sınırlandırmak için enum yapısını kullandım.
public enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

public class Cihaz
{
    // Her cihazın sahip olması gereken ortak özellikleri tanımladım
    // Private set kullanarak dışarıdan değiştirilmesini engelledim yani encapsualtion yapmış oldum
    public string Kimlik { get; private set; }
    public string Ad { get; private set; }
    public CihazTuru Tur { get; private set; }
    public bool AcikMi { get; private set; }

    // Cihaz oluşturulurken bilgilerini alabilmek için constructor oluşturdum
    public Cihaz(string kimlik, string ad, CihazTuru cihazTuru)
    {
        // Kimliğin boş olması durumunda hata fırlattım
        if (string.IsNullOrWhiteSpace(kimlik))
        {
            throw new ArgumentException("Kimlik boş olamaz.");
        }

        // Cihaz adının boş bırakılmasını engelledim
        if (string.IsNullOrWhiteSpace(ad))
        {
            throw new ArgumentException("Cihaz adı boş olamaz.");
        }

        // Geçersiz cihaz türlerinin kullanılmasını engelledim
        if (!Enum.IsDefined(typeof(CihazTuru), cihazTuru))
        {
            throw new ArgumentException("Geçersiz cihaz türü.");
        }

        // Gelen parametreleri cihazın özelliklerine atadım
        this.Kimlik = kimlik;
        this.Ad = ad;
        this.Tur = cihazTuru;

        // Yeni oluşturulan cihazın başlangıçta kapalı olmasını sağladım
        this.AcikMi = false;
    }

    // Cihazı açmak için Ac metodunu oluşturdum
    public void Ac()
    {
        // Cihazın açık olup olmadığını kontrol ettim
        if (this.AcikMi == false)
        {
            this.AcikMi = true;
            Console.WriteLine("Cihaz açıldı.");
        }
        else
        {
            // Cihaz zaten açıksa hata fırlattım.
            throw new InvalidOperationException("Cihaz zaten açık.");
        }
    }

    // Cihazı kapatmak için Kapat metodunu oluşturdum
    public void Kapat()
    {
        // Cihaz açıksa durumunu kapalı olarak değiştirdim
        if (this.AcikMi == true)
        {
            this.AcikMi = false;
            Console.WriteLine("Cihaz kapatıldı.");
        }
        else
        {
            // Cihaz zaten kapalıysa hata fırlattım
            throw new InvalidOperationException("Cihaz zaten kapalı.");
        }
    }

    // Cihazın bilgilerini ekrana yazdırmak için BilgileriGoster metodunu oluşturdum
    public void BilgileriGoster()
    {
        Console.WriteLine($"Kimlik : {Kimlik}");
        Console.WriteLine($"Ad : {Ad}");
        Console.WriteLine($"Tür : {Tur}");

        // Cihazın durumuna göre ekrana açık veya kapalı yazdırdım
        if (this.AcikMi)
        {
            Console.WriteLine("Cihaz açık.");
        }
        else
        {
            Console.WriteLine("Cihaz kapalı.");
        }

    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Cihazları saklamak için List yapısını kullandım
        List<Cihaz> cihazlar = new List<Cihaz>();

        // Oluşabilecek hataları yakalamak için try-catch kullandım
        try
        {
            // Sistemde başlangıçta bulunacak cihazları oluşturdum
            Cihaz cihaz1 = new Cihaz("1", "Salon Lambası", CihazTuru.Lamba);
            Cihaz cihaz2 = new Cihaz("2", "Oda Kliması", CihazTuru.Klima);
            Cihaz cihaz3 = new Cihaz("3", "Ev Alarmı", CihazTuru.GuvenlikSistemi);

            // Oluşturduğum cihazları listeye ekledim
            cihazlar.Add(cihaz1);
            cihazlar.Add(cihaz2);
            cihazlar.Add(cihaz3);
            // Cihazın açma ve kapatma işlemlerini test ettim
            cihaz1.BilgileriGoster();
            cihaz1.Ac();
            cihaz1.BilgileriGoster();
            cihaz1.Kapat();
            cihaz1.BilgileriGoster();
        }
        catch (ArgumentException e)
        {
            // Geçersiz parametreden kaynaklanan hataları yakaladım
            Console.WriteLine($"Hata: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            // Geçersiz cihaz işlemlerinden kaynaklanan hataları yakaladım
            Console.WriteLine($"Hata: {e.Message}");
        }
    }
}

