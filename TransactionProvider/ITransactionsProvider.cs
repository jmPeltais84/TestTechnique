using Corpus;
namespace DataProvider
{
    public interface ITransactionsProvider 
    {
        List<Transaction> GetTransactions();
    }
}