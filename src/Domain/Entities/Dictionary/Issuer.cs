using InvestExplorer.Domain.Common;

namespace InvestExplorer.Domain.Entities.Dictionary
{
    public class Issuer : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
    }
}