namespace VatakorTestCaseAPI.Rabbit
{
    public interface IRabbitMq
    {
        void SendMessage(object obj);
        void SendMessage(string message);
    }
}
