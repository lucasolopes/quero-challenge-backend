using System;
using Responses.OffersDto;

namespace Entities.Offers
{
    public class Offers
    {
        public string CourseName { get; set; } = string.Empty;
        public float Rating { get; set; }
        public decimal FullPrice { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Kind { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string IesLogo { get; set; } = string.Empty;
        public string IesName { get; set; } = string.Empty;

        public OffersDto Converter()
        {
            return new OffersDto()
            {
                IesLogo = this.IesLogo,
                IesName = this.IesName,
                Kind = this.Kind,
                Nivel = this.Level,
                NomeCurso = this.CourseName,
                PrecoCheio = this.FullPrice,
                PrecoOferecido = this.OfferedPrice,
                Rating = this.OfferedPrice,

            };
        }
    }

    public class OffersData
    {
        public List<Offers> Offers { get; set; }
    }


}