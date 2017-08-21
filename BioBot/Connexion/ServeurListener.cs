using System.Net.Sockets;
using System.Net;
using System.Threading;
using System;
using System.Windows.Forms;
using BioBot.Utilities;
using BioBot.IO;

namespace BioBot.Connexion
{
    public class ServeurListener
    {
        private Socket _socket;
        private Thread receiveThread;
        public IPEndPoint _remoteEP;
        public int ProtocolId = 0;

        // delegate + event pour gérer la réception et l'envoi de données
        public delegate void onDataReceivedEventHandler(byte[] buffer);
        public event onDataReceivedEventHandler onReception;

        public delegate void onDataSentEventHandler(ServeurListener sender, byte[] buffer);
        public event onDataSentEventHandler onSending;

        // delegate + event pour gérer la connexion d'un client
        public delegate void onConnectedEventHandler(ServeurListener sender);
        public event onConnectedEventHandler onConnected;

        // delegate + event pour gérer la déconnexion d'un client
        public delegate void onDisconnectedEventHandler(ServeurListener sender);
        public event onDisconnectedEventHandler onDisconnected;


        public ServeurListener(Socket socket)
        {
            _socket = socket;
            receiveThread = new Thread(new ThreadStart(Receive));
        }

        public ServeurListener(IPEndPoint remoteEP)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // on initialise la socket
            _remoteEP = remoteEP;
            receiveThread = new Thread(new ThreadStart(Receive));
        }

        /// <summary>
        /// Connexion et lancement du thread de réception des données serveur
        /// </summary>
        public void connectAndReceive()
        {
            if (!_socket.Connected)
                _socket.Connect(_remoteEP);

            receiveThread.Start();
            onConnected?.Invoke(this);
        }

        /// <summary>
        /// Déconnexion du socket et arrêt du thread
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (receiveThread != null)
                {
                    receiveThread.Abort();
                    receiveThread = null;
                }
                _socket.Close();
                _socket.Dispose();
            }
            catch
            {
            }
            onDisconnected?.Invoke(this);
        }

        /// <summary>
        /// Méthode utilisée par le thread receiveThread, permet la réception de données du serveur
        /// </summary>
        private void Receive()
        {
            while (_socket.Connected)
            {
                if (_socket.Available > 0)
                {
                    byte[] buffer = new byte[_socket.Available];
                    _socket.Receive(buffer);
                    onReception?.Invoke(buffer);
                }
            }
        }

        /// <summary>
        /// Envoi de données au serveur
        /// </summary>
        /// <param name="packet">Classe du protocol Dofus</param>
        public void Send(NetworkMessage packet)
        {
            ProtocolId = packet._ProtocolId;

            using (BigEndianWriter writer = new BigEndianWriter())
            {
                packet.Pack(writer);
                _socket.Send(writer.Data);
                onSending?.Invoke(this, writer.Data);
            }
        }
    }
}
