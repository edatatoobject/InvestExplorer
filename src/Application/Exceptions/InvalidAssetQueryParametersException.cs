using System;
using InvestExplorer.Domain.Exceptions;

namespace InvestExplorer.Application.Exceptions
{
    public class InvalidAssetQueryParametersException : AssetException
    {
        public InvalidAssetQueryParametersException()
        {
        }

        public InvalidAssetQueryParametersException(string message)
            : base(message)
        {
        }

        public InvalidAssetQueryParametersException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}