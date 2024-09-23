using System;
using Entities.Offers;
using Microsoft.VisualBasic;
using Newtonsoft.Json;


namespace Repositories.DatabaseContext
{

    public class DatabaseContext
    {

        private List<Offers> produtos = JsonConvert.DeserializeObject<List<Offers>>(File.ReadAllText("data.json"));


    }
}