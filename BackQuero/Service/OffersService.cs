using System;
using System.Dynamic;
using System.Globalization;
using Entities.Offers;
using Repositories.DatabaseContext;
using Responses.OffersDto;

namespace Service.OffersService
{
    public class OffersService
    {
        private DatabaseContext databaseContext;

        public OffersService()
        {
            databaseContext = new DatabaseContext();
        }

        public List<OffersDto> GetAllOffers(int pageNumber)
        {
            int pageSize = 10;
            // Get all offers from the database
            List<Offers> offers = databaseContext.GetAll();

            // Implement pagination
            var paginatedOffers = offers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            List<OffersDto> offersDtos = new List<OffersDto>();

            foreach (var offer in paginatedOffers)
            {
                offersDtos.Add(offer.Converter());
            }

            foreach (var oferta in offersDtos)
            {
                string tipo = oferta.Kind == "presencial" ? "Presencial" : "EaD";
                string nivel = oferta.Nivel switch
                {
                    "bacharelado" => "Graduação (bacharelado)",
                    "tecnologo" => "Graduação (tecnólogo)",
                    "licenciatura" => "Graduação (licenciatura)",
                    _ => "Nível desconhecido"
                };

                string precoCheioFormatado = oferta.PrecoCheio.ToString("C", new CultureInfo("pt-BR"));
                string precoOferecidoFormatado = oferta.PrecoOferecido.ToString("C", new CultureInfo("pt-BR"));
                decimal desconto = ((oferta.PrecoCheio - oferta.PrecoOferecido) / oferta.PrecoCheio) * 100;

                Console.WriteLine($"Instituição: {oferta.IesName} {oferta.IesLogo}");
                Console.WriteLine($"Tipo: {tipo}");
                Console.WriteLine($"Nível: {nivel}");
                Console.WriteLine($"Avaliação: {oferta.Rating}");
                Console.WriteLine($"Preço Cheio: {precoCheioFormatado}");
                Console.WriteLine($"Preço Oferecido: {precoOferecidoFormatado}");
                Console.WriteLine($"Desconto: {Math.Round(desconto)}%");
                Console.WriteLine(new string('-', 30));
            }

            return offersDtos;
        }

    }
}