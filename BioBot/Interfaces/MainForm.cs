using BioBot.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBot.Injecteur;
using System.Threading;
using System.Diagnostics;
using BioBot.Connexion;
using BioBot.Utilities;
using BioBot.IO;
using BioBot.Protocol.Network.messages.connection;
using BioBot.Protocol.Network.messages.queues;

namespace BioBot
{
    public partial class MainForm : Form
    {
        //"213.248.126.39", 5555
        private Injector inject;
        private ChildForm child;
        private ConsoleForm Log = new ConsoleForm();
        private ServeurListener serveurListener;
        private ClientListener clientListener;
        private PackIdNames packIdNames = new PackIdNames();

        private Thread InjectorMITM;
        public Dictionary<int, bool> DofusInjected { get; set; }
        private bool MitmActivated = false;
        public int id { get; set; }
        public int Length { get; set; }
        public byte[] ContentTreated { get; set; }
        private dynamic _ticket = null;
        private int serverID = (int)ServerNameEnum.Domen;

        public MainForm()
        {
            InitializeComponent();
            Log.MdiParent = this;
            Log.Show();
            DofusInjected = new Dictionary<int, bool>();
            clientListener = new ClientListener();
            clientListener.onClientConnected += onClientListenerConnected;
        }

        public void onClientListenerConnected(ServeurListener serveurListener)
        {
            Log.WriteLog("Nouveau client Dofus connecté.", ConsoleForm.TypeOfText.Information);
            child = new ChildForm();
            GenerateChid();
            serveurListener.onReception += forwardtoserver;
            clientListener.onClientConnected += forwardtoclient
        }

        private void forwardtoserver(ServeurListener sender, byte[] buffer)
        {
            try {
                PManager(buffer);
                sender.Send(ContentTreated);
            }
            catch { }
        }

        private void forwardtoclient(ClientListener sender, byte[] buffer)
        {
            try { }
            catch { }
        }

        /// <summary>
        /// Méthode permettant de gérer la réception de données venant du serveur
        /// </summary>
        /// <param name="buffer">Données en byte[]</param>
        public void OnDataReceived(byte[] buffer)
        {
            try
            {
                PManager(buffer);

                using (BigEndianReader _reader = new BigEndianReader(ContentTreated))
                {
                    //AddItem(false, id, idNames.GetClasseName(id), Length, ContentTreated);

                    switch (id)
                    {
                        case 1:
                            /*ProtocolRequired Pr = new ProtocolRequired();
                            Pr.Deserialize(_reader);*/
                            break;
                        case 3:
                            Log.WriteLog("Connecté au serveur d'authentification (" + serveurListener._remoteEP.ToString() + ").", ConsoleForm.TypeOfText.Information);
                            /*HelloConnectMessage Hcm = new HelloConnectMessage();
                            Hcm.Deserialize(_reader);
                            byte[] credentials = RSA.Encrypt(Hcm.key, tbAccount.Text, tbPassword.Text, Hcm.salt);
                            VersionExtended Ve = new VersionExtended(2, 42, 1, 121463, 0, 0, 1, 1);
                            IdentificationMessage Im = new IdentificationMessage(Ve, "fr", credentials, 0, cbAutoconnect.Checked, false, false, 0, new int[0]);
                            AddLog(LogType.Information, "Envoi des informations d'identification...");
                            AuthentificationClient.Send(Im);*/
                            break;
                        case 10:
                            LoginQueueStatusMessage Lqsm = new LoginQueueStatusMessage();
                            Lqsm.Deserialize(_reader);
                            Log.WriteLog("Vous êtes " + Lqsm._position + "/" + Lqsm._total + " dans la file d'attente.", ConsoleForm.TypeOfText.Information);
                            break;
                        case 21:
                            Log.WriteLog("La version du client n'est pas la même que celle du serveur", ConsoleForm.TypeOfText.Erreur);
                            break;
                        case 22:
                            Log.WriteLog("Connecté avec succès.", ConsoleForm.TypeOfText.Information);
                            break;
                        case 30:
                            /*ServersListMessage Slm = new ServersListMessage();
                            Slm.Deserialize(_reader);
                            foreach (GameServerInformations i in Slm._servers)
                            {
                                if (((ServerStatusEnum)i._status == ServerStatusEnum.ONLINE || (ServerStatusEnum)i._status == ServerStatusEnum.NOJOIN)) //&& i._id == 14
                                {
                                    if (i._id.Equals(serverID))
                                    {
                                        AuthentificationClient.Send(new ServerSelectionMessage(i._id));
                                        AddLog(LogType.Information, "Connexion au serveur " + (ServerNameEnum)i._id + "...");
                                        break;
                                    }
                                }
                            }*/
                            //"Jiva = 1,\nDjaul = 3,\nRaval = 4,\nHecate = 5,\nSumens = 6,\nMenalt = 7,\nMaimane = 9,\nSilvosse = 10,\nBrumaire = 11,\nPouchecot = 12,\nSilouate = 13,\nDomen = 14,\nAmayiro = 15,\nRykkeErrel = 16,\nHyrkul = 17,\nHelsephine = 18,\nAllister = 19,\nOtomaï = 20,\nLily = 21,\nHelMunster = 23,\nDanathor = 24,\nKuri = 25,\nMylaise = 26,\nGoultard = 27,\nUlette = 28,\nVilSmisse = 29,\nMany = 30,\nCrocoburio = 32,\nLiCrounch = 33,\nFarle = 35,\nAgride = 36,\nBowisse = 37"
                            break;
                        case 42:
                        /* SelectedServerDataMessage Ssdm = new SelectedServerDataMessage();
                         Ssdm.Deserialize(_reader);
                         _ticket = AES.DecodeWithAES(Ssdm._ticket);

                         ConnectToGameServer(Ssdm._address, Ssdm._port);
                         AuthentificationClient.Disconnect();
                         AuthentificationClient = null;
                         AddLog(LogType.Information, "Connexion au serveur de jeu ...");
                         break;
                     case 101:
                         AddLog(LogType.Information, "Connecté au serveur de jeu (" + GameClient._remoteEP.ToString() + ").");
                         AuthenticationTicketMessage Atm = new AuthenticationTicketMessage("fr", (string)_ticket);
                         GameClient.Send(Atm);
                         break;
                     case 189:
                         SystemMessageDisplayMessage Smdm = new SystemMessageDisplayMessage();
                         Smdm.Deserialize(_reader);
                         break;*/
                        default:
                            if (packIdNames.GetClasseName(id) != "Id inconnu")
                            {
                                Log.WriteLog("Le paquet [" + id + "] n'est pas implémenté", ConsoleForm.TypeOfText.Not_Implemented);
                            }
                            return;
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message != "Le thread a été abandonné.")
                    Log.WriteLog(e.Message, ConsoleForm.TypeOfText.Erreur);
            }
        }

        /// <summary>
        /// Traite le paquet reçu du serveur
        /// </summary>
        /// <param name="PacketToParse">Paquet reçu</param>
        public void PManager(byte[] PacketToParse)
        {
            if (PacketToParse.Length < 2) // Si le nombre de byte contenue est plus petit que 2, on ne pourra pas lire le header du packet, dans ce cas, on sort de la méthode 
                return;
            int index = 0;
            short id_and_packet_lenght_type, packet_lenght_type;
            Length = 0;

            // Lecture jusqu'à la fin de byte[] data
            while (index != PacketToParse.Length)
            {

                // Décodage du header
                id_and_packet_lenght_type = (short)(PacketToParse[index] * 256 + PacketToParse[index + 1]); // Selection des 2 premiers octets du paquet
                id = (short)(id_and_packet_lenght_type >> 2); // Récupérer l'ID du paquet
                packet_lenght_type = (short)(id_and_packet_lenght_type & 3); // Récupérer la taille de la taille de la longueur du paquet
                index += 2; // On se déplace 2 octets plus loin

                // Récupération de la taille du paquet
                switch (packet_lenght_type)
                {
                    case 0:
                        Length = 0;
                        break;
                    case 1:
                        Length = PacketToParse[index];
                        break;
                    case 2:
                        Length = PacketToParse[index] * 256 + PacketToParse[index + 1];
                        break;
                    case 3:
                        Length = PacketToParse[index] * 65536 + PacketToParse[index + 1] * 256 + PacketToParse[index + 2];
                        break;
                    default:
                        throw new Exception("ParsePacket() - Le header du packet est mal formé.");
                }
                if (PacketToParse.Length < Length + packet_lenght_type + 2) // Si le nombre de byte contenue dans le buffer est plus petit que : 2 (taille du header) + lenghtSize(taille de la longueur du packet) + lenght (taille du packet) alors on sort de la méthode, on va recevoir prochainement la suite du packet.
                    return;
                ContentTreated = new byte[Length];
                Array.Copy(PacketToParse, index + packet_lenght_type, ContentTreated, 0, Length);
                index += Length + packet_lenght_type;
            }
        }


        #region Methodes Generales

        public void GenerateChid()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                child = new ChildForm();
                child.MdiParent = this;
                child.Show();
            });
        }

        #endregion

        #region MenuStrip

        private void DeleteFocusChild(object sender, EventArgs e)
        {
            var activeChild = this.ActiveMdiChild;
            activeChild.Close();
        }

        private void DeleteAllChilds(object sender, EventArgs e)
        {
            var mdichildrens = this.MdiChildren;
            foreach (Form c in mdichildrens)
            {
                if (c.Name == child.Name)
                    c.Close();
            }
        }

        private void AddNewChild(object sender, EventArgs e)
        {
            GenerateChid();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.ShowConsole();
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.HideConsole();
        }

        private void nettoyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.ClearConsole();
        }

        private void CloseAllDofus(object sender, EventArgs e)
        {
            try
            {
                Process[] proc = Process.GetProcessesByName("Dofus");
                foreach (Process p in proc)
                {
                    p.CloseMainWindow();
                    p.Close();
                }
            }
            catch (Exception ez) { Log.WriteLog(ez.Message, ConsoleForm.TypeOfText.Erreur); }
        }

        private void AddDofusProcess(object sender, EventArgs e)
        {
            string path = @"C:\Program Files (x86)\Ankama\Dofus\app";
            try { Process.Start(@path + @"\Dofus.exe"); Log.WriteLog("Dofus.exe lancé.", ConsoleForm.TypeOfText.Information); }
            catch (Exception ez) { Log.WriteLog(ez.Message, ConsoleForm.TypeOfText.Erreur); }
        }

        #endregion

        #region MITM

        private void DisableMITM(object sender, EventArgs e)
        {
            if (MitmActivated)
            {
                MitmActivated = false;
                inject = null;
                Log.WriteLog("MITM desactivé.", ConsoleForm.TypeOfText.Information);
            }
            else
                Log.WriteLog("MITM déjà desactivé.", ConsoleForm.TypeOfText.Information);
        }

        private void EnableMITM(object sender, EventArgs e)
        {
            try
            {
                if (!MitmActivated)
                {
                    MitmActivated = true;
                    inject = new Injector(DofusInjected);
                    InjectorMITM = new Thread(new ThreadStart(inject.Start));
                    inject.onInjectFail += onInjectionFailed;
                    inject.onInjectSuccess += onInjectionSucess;
                    InjectorMITM.Start();
                    Log.WriteLog("MITM activé.", ConsoleForm.TypeOfText.Information);
                }
                else
                    Log.WriteLog("MITM déjà activé.", ConsoleForm.TypeOfText.Information);
            }
            catch (Exception ez) { Log.WriteLog(ez.Message, ConsoleForm.TypeOfText.Erreur); }
        }

        private void onInjectionFailed(int DofusId, DllInjectionResult result, Dictionary<int, bool> dict)
        {
            DofusInjected = dict;
            switch (result)
            {
                case DllInjectionResult.DllNotFound:
                    Log.WriteLog("Dll not found.", ConsoleForm.TypeOfText.Erreur);
                    break;

                case DllInjectionResult.GameProcessNotFound:
                    Log.WriteLog("Process " + DofusId + " not found.", ConsoleForm.TypeOfText.Erreur);
                    break;

                case DllInjectionResult.InjectionFailed:
                    Log.WriteLog("Injection Failed (Process " + DofusId + ").", ConsoleForm.TypeOfText.Erreur);
                    break;
            }
        }

        private void onInjectionSucess(int DofusId, DllInjectionResult result, Dictionary<int, bool> dict)
        {
            DofusInjected = dict;
            Log.WriteLog("Le processus Dofus avec l'id = " + DofusId + " a bien été patché.", ConsoleForm.TypeOfText.Information);
        }

        #endregion
    }
}
