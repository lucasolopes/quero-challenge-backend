using System;
using System.Globalization;
using System.Collections.Generic;
using Responses.OffersDto;
using Entities.Offers;
using Service.OffersService;

class Program
{
    static void Main(string[] args)
    {
        var offersService = new OffersService();
        int pageNumber = 1;
        bool hasMorePages = true;

        string? level = null;
        string? kind = null;
        decimal? minPrice = null;
        decimal? maxPrice = null;
        string? searchTerm = null;
        string? orderBy = null;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(" Bem vindo");
            Console.WriteLine($"Página Atual: {pageNumber}");
            Console.WriteLine("Por favor selecione:");
            Console.WriteLine("1. Nivel (graduação, tecnólogo, licenciatura)");
            Console.WriteLine("2. Kind (presencial, EaD)");
            Console.WriteLine("3. preco minimo");
            Console.WriteLine("4. preco maximo");
            Console.WriteLine("5. busca por nome");
            Console.WriteLine("6. ordernar por (nome, preco oferecido, rating)");
            Console.WriteLine("7. Buscar sem filtro");
            if (hasMorePages)
            {
                Console.WriteLine("8. Next Page");
            }
            Console.WriteLine("9. Voltar Página");
            Console.WriteLine("10. Mostrar Novamente");
            Console.WriteLine("11. Zerar Filtros");
            Console.WriteLine("0. Exit");
            Console.Write("escolha a opcao: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("escolha o Nivel: ");
                    level = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("escolha Tipo: ");
                    kind = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Preço minimo: ");
                    minPrice = decimal.Parse(Console.ReadLine() ?? "0");
                    break;
                case "4":
                    Console.Write("Preço maximo: ");
                    maxPrice = decimal.Parse(Console.ReadLine() ?? "0");
                    break;
                case "5":
                    Console.Write("Nome do Curso: ");
                    searchTerm = Console.ReadLine();
                    break;
                case "6":
                    Console.Write("Escolha a Ordem (courseName, offeredPrice, rating): ");
                    orderBy = Console.ReadLine();
                    break;
                case "7":
                    // Buscar sem filtro
                    break;
                case "8":
                    if (hasMorePages)
                    {
                        pageNumber++;
                    }
                    break;
                case "9":
                    if (pageNumber > 1)
                    {
                        pageNumber--;
                    }
                    break;
                case "10":
                    // Mostrar novamente a página atual
                    break;
                case "11":
                    ClearFilters(ref level, ref kind, ref minPrice, ref maxPrice, ref searchTerm, ref orderBy, ref pageNumber);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opçao invalida. tente novamente");
                    break;
            }

            var (offers, morePages) = offersService.GetAllOffers(pageNumber, level, kind, minPrice, maxPrice, searchTerm, orderBy);
            hasMorePages = morePages;
            DisplayOffers(offers);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void DisplayOffers(List<OffersDto> offers)
    {
        Console.WriteLine("\n Offers:");
        foreach (var offer in offers)
        {
            Console.WriteLine($"- {offer.NomeCurso} | Preço: {offer.PrecoOferecido:C} | Avaliação: {offer.Rating}");
        }
        if (offers.Count == 0)
        {
            Console.WriteLine("Nenhuma oferta encontrada.");
        }
    }

    private static void ClearFilters(ref string? level, ref string? kind, ref decimal? minPrice, ref decimal? maxPrice, ref string? searchTerm, ref string? orderBy, ref int pageNumber)
    {
        level = null;
        kind = null;
        minPrice = null;
        maxPrice = null;
        searchTerm = null;
        orderBy = null;
        pageNumber = 1;
    }
}
