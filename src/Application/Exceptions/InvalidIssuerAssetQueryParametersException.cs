using System;
using InvestExplorer.Domain.Exceptions;

namespace InvestExplorer.Application.Exceptions
{
    public class InvalidIssuerAssetQueryParametersException : AssetException
    {
        public InvalidIssuerAssetQueryParametersException()
        {
        }

        public InvalidIssuerAssetQueryParametersException(string message)
            : base(message)
        {
        }

        public InvalidIssuerAssetQueryParametersException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}