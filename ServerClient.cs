using System.Net;
using System.Net.Sockets;


public class ServerClient{
    public static void Client(){
        
        IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
        IPEndPoint iPEndPoint = new IPEndPoint(ipAddress, 25500);

        Socket socket = new Socket(
            ipAddress.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp

        );

        socket.Connect(iPEndPoint);

        Console.WriteLine("Skriv in ditt användarnamn");
        string? username = Console.ReadLine();
        Console.WriteLine("Skriv in ditt lösenord");
        string? password = Console.ReadLine();

        string credentials = $"{username}:{password}";
        // sparar username och password i en variabel

        byte[] sendBuffer = System.Text.Encoding.UTF8.GetBytes(credentials);
        // gör om svaret till bytes för att skicka till server
        socket.Send(sendBuffer);
        // skickar till servern
        byte[] receiveBuffer = new byte[5000];
       int read = socket.Receive(receiveBuffer);
        // tar emot svar från servern
        string response = System.Text.Encoding.UTF8.GetString(receiveBuffer, 0, read);
        // gör om svaret till en string
       Console.WriteLine($"{response}");
        

    }
}