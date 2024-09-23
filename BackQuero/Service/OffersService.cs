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

        public (List<OffersDto> offers, bool hasMorePages) GetAllOffers(int pageNumber, string? level = null, string? kind = null, decimal? minPrice = null, decimal? maxPrice = null, string? searchTerm = null, string? orderBy = null)
        {
            int pageSize = 10;
            List<Offers> offers = databaseContext.GetAll();

            // Apply filters
            if (!string.IsNullOrEmpty(level))
            {
                offers = offers.Where(o => o.Level.Equals(level, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(kind))
            {
                offers = offers.Where(o => o.Kind.Equals(kind, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (minPrice.HasValue)
            {
                offers = offers.Where(o => o.OfferedPrice >= minPrice.Value).ToList();
            }

            if (maxPrice.HasValue)
            {
                offers = offers.Where(o => o.OfferedPrice <= maxPrice.Value).ToList();
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                offers = offers.Where(o => o.CourseName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Apply sorting
            offers = orderBy switch
            {
                "courseName" => offers.OrderBy(o => o.CourseName).ToList(),
                "offeredPrice" => offers.OrderBy(o => o.OfferedPrice).ToList(),
                "rating" => offers.OrderByDescending(o => o.Rating).ToList(),
                _ => offers
            };

            // Implement pagination
            var paginatedOffers = offers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            bool hasMorePages = offers.Count > pageNumber * pageSize;

            return (paginatedOffers.Select(offer => offer.Converter()).ToList(), hasMorePages);
        }


    }
}