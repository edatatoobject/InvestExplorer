using InvestExplorer.Domain.Enums;

namespace InvestExplorer.Domain.Entities
{
    public class Stock : BaseAsset
    {
        public StockType StockType { get; set; }
    }
}