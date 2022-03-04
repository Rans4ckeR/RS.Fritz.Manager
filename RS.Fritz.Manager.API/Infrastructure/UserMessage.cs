namespace RS.Fritz.Manager.API
{
    public sealed record UserMessage
    {
        public UserMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}