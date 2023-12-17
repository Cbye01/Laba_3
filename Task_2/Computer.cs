namespace Task_2;

public class Computer
{
     public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }

    public Computer(string ipAddress, int power, string operatingSystem)
    {
        IPAddress = ipAddress;
        Power = power;
        OperatingSystem = operatingSystem;
    }

    public virtual void Connect(Computer target)
    {
        Console.WriteLine($"[{IPAddress}] Connected to [{target.IPAddress}]");
    }

    public virtual void Disconnect(Computer target)
    {
        Console.WriteLine($"[{IPAddress}] Disconnected from [{target.IPAddress}]");
    }

    public virtual void SendData(Computer target, string data)
    {
        Console.WriteLine($"[{IPAddress}] Sent data to [{target.IPAddress}]: {data}");
    }

    public virtual void ReceiveData(Computer source, string data)
    {
        Console.WriteLine($"[{IPAddress}] Received data from [{source.IPAddress}]: {data}");
    }
}

public class Server : Computer
{
    public int StorageCapacity { get; set; }

    public Server(string ipAddress, int power, string operatingSystem, int storageCapacity)
        : base(ipAddress, power, operatingSystem)
    {
        StorageCapacity = storageCapacity;
    }
}

public class Workstation : Computer
{
    public string Department { get; set; }

    public Workstation(string ipAddress, int power, string operatingSystem, string department)
        : base(ipAddress, power, operatingSystem)
    {
        Department = department;
    }
}

public class Router : Computer
{
    private List<Computer> connectedComputers = new List<Computer>();

    public Router(string ipAddress, int power, string operatingSystem)
        : base(ipAddress, power, operatingSystem)
    {
    }

    public override void Connect(Computer target)
    {
        base.Connect(target);
        connectedComputers.Add(target);
    }

    public override void Disconnect(Computer target)
    {
        base.Disconnect(target);
        connectedComputers.Remove(target);
    }
}

public class Network
{
    private List<Computer> computers = new List<Computer>();

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void EstablishConnection(Computer device1, Computer device2)
    {
        device1.Connect(device2);
        device2.Connect(device1);
    }
}
