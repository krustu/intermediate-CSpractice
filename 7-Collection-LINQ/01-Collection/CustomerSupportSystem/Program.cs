using System;
class Program
{
    static void Main(string[] args)
    {
        //Collcetion Queue - FIFO (First In First Out)
        var Tickets = new Queue<string>();
        Tickets.Enqueue("Ticket 1");
        Tickets.Enqueue("Ticket 2");
        Tickets.Enqueue("Ticket 3");
        Tickets.Enqueue("Ticket 4");
        //Peek() - allows you yo look at first elemen without removing it from the queue
        //Enqueue() - adds an item to the end of the queue
        //Dequeue() - chooses the first item in the queue and removes it from the queue

        while (Tickets.Count > 0)
        {
            string tick = Tickets.Dequeue();
            Console.WriteLine(tick);
        }

        Console.ReadKey();
        //Dictionary - Key Value Pair Collection

        Dictionary<string, string> TicketStatus = new Dictionary<string, string>();
        TicketStatus.Add("Ticket 1#", "Resolved");
        TicketStatus.Add("Ticket 2#", "In Progress");
        TicketStatus.Add("Ticket 3#", "Closed");
        TicketStatus.Add("Ticket 4#", "Open");

        TicketStatus["Ticket 2#"] = "Closed";
        Console.WriteLine(TicketStatus["Ticket 2#"]);

        foreach (var ticket in TicketStatus)
        {
            Console.WriteLine($"Ticket: {ticket.Key}, Status: {ticket.Value}");
        }

        //HashSet - Unordered Collection of Unique Elements

        Console.ReadKey();
        HashSet<string> vipCustomers = new HashSet<string>();
        vipCustomers.Add("Krustu");
        vipCustomers.Add("Alice");
        vipCustomers.Add("KRustu");
        vipCustomers.Add("KRustu");
        Console.WriteLine(vipCustomers.Count);
        foreach (var vip in vipCustomers)
        {
            Console.WriteLine(vip);
        }

        //Stack - LIFO (Last In First Out) Collection

        Console.ReadKey();
        var ticketStack = new Stack<string>();
        ticketStack.Push("open ticket");
        ticketStack.Push("responded to the client");
        ticketStack.Push("close ticket");

        ticketStack.Pop();
        foreach (var ticket in ticketStack)
        {
            Console.WriteLine(ticket);
        }

    }
}
