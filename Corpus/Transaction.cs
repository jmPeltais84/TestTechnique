namespace Corpus
{
    /// <summary>
    /// Describe Bank and accounting transaction 
    /// </summary>
    public class Transaction    
    {
        
        private int _id = -1;
        private string _description = "";
        private decimal _amount = 0;
        private DateTime _date = DateTime.MinValue;

        virtual public int Id { get => _id; set => _id = value; }
        virtual public string Description { get => _description; set => _description = value; }
        virtual public decimal Amount { get => _amount; set => _amount = value; }
        virtual public DateTime Date { get => _date; set => _date = value; }
    }
}