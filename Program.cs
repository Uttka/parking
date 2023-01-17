int menupunkt = 0;
string vID;
int bal;
string vtype;
List<Viechle> viechles = new List<Viechle>();
Console.WriteLine("");
do
{
    Menu();
} while (menupunkt != 5);





void Menu()
{
    Console.WriteLine("Введіть елемент меню:\n"+"1)Поставити ТЗ на паркінг\n"+"Поповнити баланс ТЗ\n"+"Достунпі місця\n");
    int menupunkt = Convert.ToInt32(Console.ReadLine());
    switch (menupunkt)
    {
        case 1:
            //Console.WriteLine("Поставити транспорт чи забрати?");
            addviecle();
           
            break;
        case 2:
            Console.WriteLine("2");
            Console.WriteLine("на першому місці стоїть авто з айді:" + Convert.ToString(viechles[0]));
            
            break;
        case 3:
            Console.WriteLine("3");
            break;
        default:
            Console.WriteLine("Ви ввели неправильний пункт меню");
            break;
    }

}
void addviecle()
{
    Console.WriteLine("Введіть айді транспорту:");
    vID = Console.ReadLine();
    Console.WriteLine("Введіть баланс транспорту:");
    bal = Convert.ToInt32(Console.ReadLine());
    vtype = Console.ReadLine();
    viechles.Add(new Viechle() { ViechleId = vID, Viechletype = vtype, Viechlbalance = bal });
    Console.WriteLine("Транспорт додано");
}

//object Viechle(string ID,double balance)
//{

//    transport newviechle = new()
//    {
//        vehicleID = ID,

//        vehicleBalance = Convert.ToInt32(balance)
//    };
//    return newviechle;
//}
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
    // Should also override == and != operators.
}
