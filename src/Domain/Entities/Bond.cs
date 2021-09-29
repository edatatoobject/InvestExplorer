using InvestExplorer.Domain.Enums;

namespace InvestExplorer.Domain.Entities
{
    public class Bond : BaseAsset
    {
        public BondType BondType { get; set; }
    }
}