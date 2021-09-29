using InvestExplorer.Application.Enum;
using InvestExplorer.Application.Exceptions;

namespace InvestExplorer.Application.QueryParameters
{
    public class AssetQueryParameter : BaseQueryParameter
    {
        private const int IdentifierLenght = 3;
        
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public AssetTypeEnum AssetType { get; set; }
        

        public void CheckParameters()
        {
            if (!IsAnyFilled())
            {
                throw new InvalidAssetQueryParametersException("One parameter Name/Ticker/Isin must be filled");
            }
            
            if (!IsOneIndexFiled())
            {
                throw new InvalidAssetQueryParametersException("Only one Name/Ticker/Isin can be filled");
            }

            if (!IsLenghtCorrect())
            {
                throw new InvalidAssetQueryParametersException("Name/Ticker/Isin must be at least 3 symbols");
            }
        }
        
        private bool IsAnyFilled()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Ticker) && !string.IsNullOrEmpty(Isin))
            {
                return false;
            }

            return true;
        }

        private bool IsOneIndexFiled()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Ticker))
                return false;
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Isin))
                return false;
            if (!string.IsNullOrEmpty(Ticker) && !string.IsNullOrEmpty(Name))
                return false;
            
            return true;
        }

        private bool IsLenghtCorrect()
        {
            if (!string.IsNullOrEmpty(Name) && Name.Length < IdentifierLenght)
                return false;
            if (!string.IsNullOrEmpty(Ticker) && Ticker.Length < IdentifierLenght)
                return false;
            if (!string.IsNullOrEmpty(Isin) && Isin.Length < IdentifierLenght)
                return false;

            return true;
        }
    }
}