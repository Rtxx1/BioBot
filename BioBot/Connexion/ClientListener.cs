using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBot.Connexion
{
    public class ClientListener
    {
        private Socket _socket;
        private Thread _acceptingthread;
        private IPEndPoint _localEP;

        public delegate void onClientActionEventHandler(ServeurListener serveurListener);
        public event onClientActionEventHandler onClientConnected;

        public ClientListener()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _acceptingthread = new Thread(new ThreadStart(accept));
            _localEP = new IPEndPoint(IPAddress.Loopback, 5555);
            _socket.Bind(_localEP); // écoute sur localhost
            _socket.Listen(100);
            _acceptingthread.Start(); // on démarre le thread d'acceptation
        }

        public void accept()
        {
            while (true)
            {
                Socket socket = _socket.Accept(); // on recupère la socket du nouveau client
                ServeurListener serveurListener = new ServeurListener(socket);
                onClientConnected?.Invoke(serveurListener); // on l'envoi via l'event
            }
        }
    }
}
