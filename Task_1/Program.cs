using Laba_3;

class Program
{
    static void Main(string[] args)
    {

        Ecosystem ecosystem = new Ecosystem();
        Animal lion = new Animal(100, 5, 15, "Lion");
        Animal gazelle = new Animal(50, 3, 10, "Газель");
        Plant tree = new Plant(30, 10, 50, "Дерево");
        Microorganism bacteria = new Microorganism(10, 1, 1, "Бактерія");
        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(gazelle);
        ecosystem.AddOrganism(tree);
        ecosystem.AddOrganism(bacteria);
        ecosystem.SimulateInteraction();
    }
}
