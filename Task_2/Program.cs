class Program
{
    static void Main(string[] args)
    {
        Server server = new Server("192.168.1.1", 1000, "Windows Server", 2000);
        Workstation workstation = new Workstation("192.168.1.2", 500, "Windows 10", "HR");
        Router router = new Router("192.168.1.254", 200, "Embedded OS");

        Network network = new Network();
        network.AddComputer(server);
        network.AddComputer(workstation);
        network.AddComputer(router);

        network.EstablishConnection(server, router);
        network.EstablishConnection(workstation, router);

        server.SendData(workstation, "Data from server to workstation");
        workstation.SendData(server, "Data from workstation to server");
    }
}
