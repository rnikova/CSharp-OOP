using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
           this.Id = id;
           this.Status = status;
           this.From = from;
           this.To = to;
           this.Amount = amount;
        }

        public int Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public TransactionStatus Status { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string From { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string To { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public decimal Amount { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int CompareTo(ITransaction other)
        {
            throw new System.NotImplementedException();
        }
    }
}
