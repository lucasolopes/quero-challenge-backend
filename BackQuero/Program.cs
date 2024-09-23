using System;
using System.Linq;
using Entities.Offers;
using Repositories.DatabaseContext;
using Service.OffersService;


class Program
{

    static void Main(string[] args)
    {
        OffersService offersService = new OffersService();

        Console.WriteLine(offersService.GetAllOffers(1));
    }
}