using System.Xml.Linq;

public class Kullanici
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Sehir { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var kullanicilar = new List<Kullanici>
        {
            new Kullanici { Id = 1, Ad = "Ayşe", Sehir = "Ankara" },
            new Kullanici { Id = 2, Ad = "Ali", Sehir = "İstanbul" },
            new Kullanici { Id = 3, Ad = "Zeynep", Sehir = "Ankara" },
            new Kullanici { Id = 4, Ad = "Murat", Sehir = "İzmir" },
            new Kullanici { Id = 5, Ad = "Elif", Sehir = "İstanbul" },
            new Kullanici { Id = 6, Ad = "Kemal", Sehir = "Ankara" }
        };

        var xml = new XElement("Sehirler",
            kullanicilar
                .GroupBy(k => k.Sehir)
                .Select(grup =>
                    new XElement("Sehir",
                        new XAttribute("Ad", grup.Key),
                        grup.Select(k =>
                            new XElement("Kullanici",
                                new XElement("Id", k.Id),
                                new XElement("Ad", k.Ad)
                            )
                        )
                    )
                )
        );

        Console.WriteLine(xml);
    }
}