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
        string request = "GET / HTTP/1.1\r\nHost: 127.0.0.1\r\n\r\n";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(request);

        socket.Send(buffer);
        byte[] incoming = new byte[10000];
        int read = socket.Receive(incoming);
        string response = System.Text.Encoding.UTF8.GetString(incoming, 0, read);
        Console.WriteLine($"Response: {response}");
        socket.Close();
    }
}