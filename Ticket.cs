namespace TestProject1
{
    internal struct Ticket
    {
        internal enum ERequestType
        {
            Payment,
            Subscription,
            Cancellation
        }

        public ERequestType RequestType { get; private set; }

        public int Turn { get; private set; }

        public Ticket(ERequestType requestType, int turn)
        {
            RequestType = requestType;
            Turn = turn;
        }
    }
}