using System;
using System.Linq;
using Entities.Offers;
using Repositories.DatabaseContext;


class Program
{

    static void Main(string[] args)
    {
        DatabaseContext db = new DatabaseContext();
        Console.WriteLine(db.getoneOffer());
    }
}