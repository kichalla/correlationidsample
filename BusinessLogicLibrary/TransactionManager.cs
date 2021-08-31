using System;

namespace BusinessLogicLibrary
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ICorrelationIdAccessor _correlationIdAccessor;

        public TransactionManager(ICorrelationIdAccessor correlationIdAccessor)
        {
            _correlationIdAccessor = correlationIdAccessor;
        }

        public void SendMoney(TransferInfo transferInfo)
        {
            var correlationId = _correlationIdAccessor.GetCorrelationId();
        }
    }

    public interface ICorrelationIdAccessor
    {
        string GetCorrelationId();
    }

    public interface ITransactionManager
    {
        void SendMoney(TransferInfo transferInfo);
    }
    public class TransferInfo { }
}
