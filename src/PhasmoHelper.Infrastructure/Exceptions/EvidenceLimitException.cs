using System;

namespace PhasmoHelper.Infrastructure.Exceptions
{
    public class EvidenceLimitException : Exception
    {
        public EvidenceLimitException() 
            : base("The maximum number of evidences you can select is 3") { }
    }
}
