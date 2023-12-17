namespace Laba_3;

 public class ORGANISM
    {
        public int Energy { get; set; }
        public int Age { get; set; }
        public int Size { get; set; }

        public ORGANISM(int energy, int age, int size)
        {
            Energy = energy;
            Age = age;
            Size = size;
        }
    }


    public class Animal : ORGANISM, IReproducible, IPredator
    {
        public string Species { get; set; }

        public Animal(int energy, int age, int size, string species)
            : base(energy, age, size)
        {
            Species = species;
        }

        public void Reproduce()
        {
            Console.WriteLine($"{Species} Reproduce.");
        }

        public void Hunt(ORGANISM prey)
        {
            Console.WriteLine($"{Species} hunting on organism {prey.Energy} unit energy.");
        }
    }

    public class Predator : ORGANISM, IPredator
    {
        public Predator(int energy, int age, int size)
            : base(energy, age, size)
        {
        }

        public int Energy { get; set; } 

        public void Hunt(ORGANISM prey)
        {
            Console.WriteLine("Хижак полює на жертву.");
        }
    }

    public class Plant : ORGANISM, IReproducible
    {
        public string Type { get; set; }

        public Plant(int energy, int age, int size, string type)
            : base(energy, age, size)
        {
            Type = type;
        }

        public void Reproduce()
        {
            Console.WriteLine($"{Type} Reproduce.");
        }
    }


    public class Microorganism : ORGANISM, IReproducible
    {
        public string Name { get; set; }

        public Microorganism(int energy, int age, int size, string name)
            : base(energy, age, size)
        {
            Name = name;
        }

        public void Reproduce()
        {
            Console.WriteLine($"{Name} Reproduce.");
        }
    }


    public interface IReproducible
    {
        void Reproduce();
    }


    public interface IPredator
    {
        int Energy { get; set; } 
        void Hunt(ORGANISM prey);
    }
 


    public class Ecosystem
    {
        private List<ORGANISM> organisms;

        public Ecosystem()
        {
            organisms = new List<ORGANISM>();
        }

        public void AddOrganism(ORGANISM organism)
        {
            organisms.Add(organism);
        }

        public void SimulateInteraction()
        {
            foreach (var organism in organisms)
            {
                if (organism is IPredator predator)
                {
                    foreach (var prey in organisms)
                    {
                        if (predator != prey && organism.Energy > prey.Energy)
                        {
                            predator.Hunt(prey);
                            predator.Energy += prey.Energy;
                            organisms.Remove(prey);
                            break;
                        }
                    }
                }

                if (organism is IReproducible reproducer)
                {
                    if (organism.Age < 10)
                    {
                        reproducer.Reproduce();
                        var newOrganism = new ORGANISM(50, 0, 5);
                        organisms.Add(newOrganism);
                    }
                }
            }
        }
    }
