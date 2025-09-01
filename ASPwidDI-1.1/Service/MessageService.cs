namespace ASPwidDI_1._1.Service
{
    public class MessageService : IMessageService
    {
        private string _message = "Hello from DI!";

        public string GetMessage() => _message;

        public void SaveMessage(string msg)
        {
            _message = msg;
        }
    }
}