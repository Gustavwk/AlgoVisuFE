using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisuFSLogic.Model.Generics
{
    public class OperationChrono<T>
    {
        public int SequenceNumber { get; set; }
        public T From { get; set; }
        public T To { get; set; }

        public OperationChrono(T from, T to, int sequenceNumber)
        {
            From = from;
            To = to;
            SequenceNumber = sequenceNumber;
        }
    }
}
