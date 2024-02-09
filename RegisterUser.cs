using System.Net.Sockets;
using System.Text;

public class RegisterUser
{


    public bool registerUser(Socket socket){
        Console.WriteLine("Välj användarnamn");
        string? username = Console.ReadLine();
        Console.WriteLine("Välj lösenord");
        string? password = Console.ReadLine();

        string credentials = $"{username}:{password}";

        byte [] sendBuffer = Encoding.UTF8.GetBytes(credentials);
        socket.Send(sendBuffer);

        byte[] receiveBuffer = new byte[5000];
        int read = socket.Receive(receiveBuffer);
        string response = Encoding.UTF8.GetString(receiveBuffer, 0, read);
        Console.WriteLine(response);

        return response.StartsWith("Användaren har registrerats");
    }
}