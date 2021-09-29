using InvestExplorer.Application.Exceptions;

namespace InvestExplorer.Application.QueryParameters
{
    public class IssuerAssetQueryParameters : BaseQueryParameter
    {
        public int IssuerId { get; set; }
        public bool Available { get; set; }
        public bool Sort { get; set; }
        

        public void CheckParameters()
        {
            if (IssuerId == default)
            {
                throw new InvalidIssuerAssetQueryParametersException("IssuerId must be set");
            }
        }
    }
}