using System;
using System.Runtime.Serialization;

namespace CodeTest
{
    [Serializable]
    public class SubtextLongerThanTextException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public SubtextLongerThanTextException()
        {
        }

        public SubtextLongerThanTextException(string message) : base(message)
        {
        }

        public SubtextLongerThanTextException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SubtextLongerThanTextException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}