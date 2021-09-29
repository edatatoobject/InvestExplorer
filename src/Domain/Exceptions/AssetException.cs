using System;

namespace InvestExplorer.Domain.Exceptions
{
    public class AssetException : Exception
    {
        public AssetException()
        {
        }

        public AssetException(string message)
            : base(message)
        {
        }

        public AssetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}