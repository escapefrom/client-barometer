using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClientBarometer.Contracts.Responses
{
    public class Chat
    {
        private static string[] _labels = new string[]
        {
            "Rick Owens DRKSHDW высокие кеды на шнуровке",
            "sacai двухцветное худи",
            "TOM FORD костюм с атласной отделкой",
            "Junya Watanabe брюки WIP Comme des Garçons x Carhartt",
            "Fendi кроссовки Fendi Flow",
            "Y-3 кроссовки Hicho",
            "TUDOR наручные часы Black Bay Bronze pre-owned 43 мм 2021-го года",
            "Versace жаккардовые трусы-брифы с логотипом Medusa",
            "Rolex наручные часы GMT-Master II pre-owned 40 мм 2021-го года",
            "Эксклюзив Off-White чехол для AirPods со шнурком на шею",
            "AMBUSH колье с подвеской"
        };
        public Guid Id { get; set; }
        public string SourceId { get; set; }
        public string Source { get; set; }
        public string Username { get; set; }
        public string Label { get => _labels[Id.ToByteArray().Aggregate(1, (acc, b) => acc += b) % _labels.Length]; }
    }
}