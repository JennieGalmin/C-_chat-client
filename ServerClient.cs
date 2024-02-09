using System.Net;
using System.Net.Sockets;


public class ServerClient{
    private Socket socket;
    private NetworkStream stream;
  
    private StreamWriter writer;
    public void Client(){
        

        IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
        IPEndPoint iPEndPoint = new IPEndPoint(ipAddress, 25500);

        socket = new Socket(
            ipAddress.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp

        );

        socket.Connect(iPEndPoint);

        stream = new NetworkStream(socket);
        reader = new StreamReader(stream);
        writer = new StreamWriter(stream);

        RegisterUser();
    }
        private void RegisterUser()
        {
        Console.WriteLine("Välkommen till C#_chat");

        Console.WriteLine("Vad vill du göra?");
        Console.WriteLine("1. Logga in");
        Console.WriteLine("2. Registrera användare");
        Console.WriteLine("3. Avsluta");

        string? choice = Console.ReadLine();

        if(choice == null){
            Console.WriteLine("Skriv in ditt val");
            return;
        }
        // if sats för om valet skulle vara blankt
        // fungerar ej!.
        
        switch(choice){

            case "1":
            Console.WriteLine("Du valde att logga in");
            
            // ska in en if sats här för att antingen fortsätta applikationen eller 
            // felmeddelande om inlogg misslyckas
            break;

            case "2":
            Console.WriteLine("Du valde att registrera användare");
            Console.WriteLine("Välj användarnamn");
            string? username = Console.ReadLine();
            Console.WriteLine("Välj lösenord");
            string? password = Console.ReadLine();
            
            SendRegistrationData(username, password);
                   
            break;

            case "3":
            Console.WriteLine("Du valde att avsluta, hejdå!");
            Environment.Exit(0);
            break;
        }
        // Switch statement för att välja vad som ska hända för varje val

        
        }
    
            private void SendRegistrationData(string username, string password)
            {
                writer.WriteLine($"{username}:{password}");
                writer.Flush();
            }
}

/*

        while(!isLoggedIn){

        

        string credentials = $"{username}:{password}";
        // sparar username och password i en variabel

        sendBuffer = System.Text.Encoding.UTF8.GetBytes(credentials);
        // gör om svaret till bytes för att skicka till server
        socket.Send(sendBuffer);
        // skickar till servern
        byte[] receiveBuffer = new byte[5000];
       int read = socket.Receive(receiveBuffer);
        // tar emot svar från servern
        string response = System.Text.Encoding.UTF8.GetString(receiveBuffer, 0, read);
        // gör om svaret till en string
       Console.WriteLine($"{response}");
        
        if(response.StartsWith("välkommen")){
            isLoggedIn = true;
        } else {
            Console.WriteLine("Fel vid inloggning");
        }

        while(isLoggedIn){

            Console.WriteLine("Skriv ett meddelande eller exit");
            string? sendMessage = Console.ReadLine();

            if(sendMessage.ToLower() == "exit"){
                break;
            } else {
            byte[] sendBuffer = System.Text.Encoding.UTF8.GetBytes(sendMessage);
            socket.Send(sendBuffer);

            }

            socket.Close();
        }

        }
    }
}}*/