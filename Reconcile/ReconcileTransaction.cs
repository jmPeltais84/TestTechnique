using Corpus;
using System.Collections.Generic;

namespace Reconcile
{
    public class ReconcileTransaction
    {
        /// <summary>
        /// Try to reconcile bank transaction and Accounting transaction where Amount are close enough according to iPercentage
        /// </summary>
        /// <param name="iBank"> bank transactions</param>
        /// <param name="iAccounting">accounting transaction</param>
        /// <param name="iPercentage"> percentage of reconciliation</param>
        /// <returns></returns>
        public static void reconcile(List<Transaction> iBank, List<Transaction> iAccounting,Decimal iPercentage, List<ReconciliationLink> oReconciliationLink, out Decimal oRate)
        {

            foreach (Transaction tb in iBank) {
                decimal start = tb.Amount * (100 - iPercentage) / 100;
                decimal end = tb.Amount * (100 + iPercentage) / 100;
                if (tb.Amount < 0) {
                    (start, end) = (end, start);
                }
                //find first accounting between range start and range End 
                //date could be add as find condition
                var foundTa = iAccounting.Find(ta => start <= ta.Amount && ta.Amount <= end);
                if (foundTa != null)
                {
                    //Accounting transaction  is only linked to one bank transaction => remove transaction used
                    iAccounting.Remove(foundTa);
                    oReconciliationLink.Add(new ReconciliationLink() { TransIdAccounting = foundTa.Id, TransIdBank = tb.Id });
                }
            }

            //compute Rate
            if (iBank.Count == 0)
                oRate = 100;
            else
                oRate = oReconciliationLink.Count * 100 / iBank.Count;
        }
    }
}