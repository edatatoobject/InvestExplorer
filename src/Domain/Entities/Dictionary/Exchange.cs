using InvestExplorer.Domain.Common;

namespace InvestExplorer.Domain.Entities.Dictionary
{
    public class Exchange : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}