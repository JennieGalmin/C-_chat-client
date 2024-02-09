namespace C__chat_client;

class Program
{
    static void Main(string[] args)
    {
        ServerClient serverclient = new ServerClient();
        serverclient.Client();
    }
}
