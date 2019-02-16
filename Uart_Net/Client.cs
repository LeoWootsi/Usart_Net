using System.Net.Sockets;
using System.IO;

namespace Uart_Net
{
    class Client
    {
        public TcpClient TcpClient { get; private set; }
        public int descriptor { get; set; }
        public BinaryReader br { get; private set; }
        public BinaryWriter bw { get; private set; }

        public Client(TcpClient client)
        {
            TcpClient = client;
            NetworkStream networkStream = client.GetStream();
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
        }
        public void Close()
        {
            TcpClient.Close();
        }
                   
    }
}
