using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corpus
{
    /// <summary>
    /// link bank transaction to accounting transaction
    /// </summary>
    public class ReconciliationLink
    {
        private int _transIdBank;
        private int _transIdAccounting;

        public int TransIdBank { get => _transIdBank; set => _transIdBank = value; }
        public int TransIdAccounting { get => _transIdAccounting; set => _transIdAccounting = value; }
    }
}
