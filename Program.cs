using System.IO;
using System.Text.RegularExpressions;
Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

string vID;
int bal;
string vtype;
string menupunkt;
List<Viechle> viechles = new List<Viechle>();

do
{
    Menu();
} while (menupunkt != "6");





void Menu()
{
    Console.WriteLine("Введіть елемент меню:\n"+"1)Поставити ТЗ на паркінг\n"+ "2)Забрати\n" + "3)Доступні місця\n" + "4)Переглянути баланс\n" + "5)Додати баланс\n"+"6)Вийти в меню");
     menupunkt =Console.ReadLine();
    switch (menupunkt)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Поставити транспорт");
            addviecle();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Забрати транспорт");
            deleteviecle();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Доступні місця");
            vieclesinpark();
            break;
        case "4":
            vieclebalance();
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("Додати баланс");
            addbalance();
            break;
        case "6":
            Console.Clear();
            Console.WriteLine("Ви вийшли з програми");
            break;
        default:
            Console.Clear();
            Console.WriteLine("Ви ввели неправильний пункт меню\n");
            break;
    }

}
void addviecle()
{
    if (viechles.Count<11)
    {
        enterelement("айді транспорту");
        vID = Console.ReadLine();
        
        if (idformat(vID))
        {
            if (!(viechles.Contains(new Viechle { ViechleId = vID })))
            {

                enterelement("баланс транспорту");

                bal = Convert.ToInt32(Console.ReadLine());
              
                enterelement("тип");

                vtype = Console.ReadLine();

                if (typeformat(vtype))
                {
                    viechles.Add(new Viechle() { ViechleId = vID, Viechletype = vtype, Viechlbalance = bal });
                    Console.Clear();
                    Console.WriteLine("Транспорт додано\n");
                }
            
                
                else
                {
                    Console.WriteLine($"Ваш тип {vtype}, але вірний формат:Легкова, Вантажна, Автобус, Мотоцикл\n") ;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Транспорт Вже на паркінгу\n");
            }

        }
        else
        {
            Console.WriteLine($"Ваш айді '{vID}' не підходить під формат: ХХ-YYYY-XX");
        }

    }
    else
    {
        Console.WriteLine("Парк заповнено\n");
    }
 
}
void enterelement(string word) 
{
    Console.WriteLine($"Введіть {word}:");
}
bool idformat(string word)
{
    if (word == null)
    {
        return false;
    }
    var regex = new Regex("^\\b[A-Z]{2}-\\d{4}-\\b[A-Z]{2}$");
    return regex.IsMatch(word);
}
bool typeformat(string type) 
{
    if (type == null) 
    {
        return false;
    }
    else if(type== "Легкова" || type == "Вантажна" || type == "Автобус" || type == "Мотоцикл")
    {
        return true;
    }
    else
    {
        return false;
    }
}
void deleteviecle() 
{
    Console.WriteLine("Введіть айді транспорту:");

    vID = Console.ReadLine();
    if (idformat(vID))
    {

        viechles.Remove(new Viechle() { ViechleId = vID });
        Console.WriteLine("Видалено\n");
    }
    else
    {
        Console.WriteLine($"Ваш айді '{vID}' не підходить під формат: ХХ-YYYY-XX");
    }
}
 void vieclesinpark() 
{
    if (viechles.Count==10)
    {
        Console.Clear();
        Console.WriteLine("Парк зайнято\n");
    }
    else if (viechles.Count==0)
    {
        Console.Clear();
        Console.WriteLine("Парк не зайнято\n");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Парк доступен з "+Convert.ToString(viechles.Count+1)+" по 10 місце\n");
    }
}
void addbalance()
{
    enterelement("айді ТЗ");
    vID = Console.ReadLine();
    enterelement("Суму щоб додати:");
    bal =Convert.ToInt32( Console.ReadLine());
    var vic = viechles.First(v => v.ViechleId == vID);

    vic.Viechlbalance += bal;
    Console.WriteLine($"Додано {bal}, поточний баланс {vic.Viechlbalance}");

}
void vieclebalance()
{
    enterelement("айді транспорту");
    vID = Console.ReadLine();
    if (idformat(vID))
    {
        if ((viechles.Contains(new Viechle { ViechleId = vID })))
        {
          int id = viechles.IndexOf(new Viechle { ViechleId = vID });
            Console.WriteLine(viechles[id]);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Транспорт не знайдено\n");
        }

    }
    else
    {
        Console.WriteLine($"Ваш айді '{vID}' не підходить під формат: ХХ-YYYY-XX");
    }


}
public class Viechle : IEquatable<Viechle>
{
    public string ViechleId { get; set; }
    public string Viechletype { get; set; }
    public int Viechlbalance { get; set; }


    public override string ToString()
    {
        return "ID: " + ViechleId + "   Type: " + Viechletype+"   Balance: " + Viechlbalance;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Viechle objAsPart = obj as Viechle;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public override int GetHashCode()
    {
        return Viechlbalance;
    }
    public bool Equals(Viechle other)
    {
        if (other == null) return false;
        return (this.ViechleId.Equals(other.ViechleId));
    }
   
}

