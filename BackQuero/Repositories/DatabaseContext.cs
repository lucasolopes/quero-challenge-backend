using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entities.Offers;
using Newtonsoft.Json;

namespace Repositories.DatabaseContext
{
    public class DatabaseContext
    {
        private List<Offers> produtos;

        public DatabaseContext()
        {
            var offersData = JsonConvert.DeserializeObject<OffersData>(File.ReadAllText("data.json"));
            produtos = offersData?.Offers ?? new List<Offers>();
        }

        public List<Offers> GetAll()
        {
            return produtos;
        }
    }
}