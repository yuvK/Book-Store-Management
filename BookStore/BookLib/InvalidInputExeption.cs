using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    //exeption for user inputs validation
    [Serializable]
    public class InvalidInputExeption : Exception
    {
        public string FailedProp { get; set; }
        public InvalidInputExeption() { }
        public InvalidInputExeption(string message) : base(message) { }
        public InvalidInputExeption(string message, string FailedProp) : base(message)
        {
            this.FailedProp = FailedProp;
        }
    }
}
