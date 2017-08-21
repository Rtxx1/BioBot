using BioBot.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBot.Injecteur
{
    public class Injector
    {
        public delegate void OnInjectHandler(int DofusId, DllInjectionResult result, Dictionary<int, bool> DofusMods);
        public event OnInjectHandler onInjectSuccess;
        public event OnInjectHandler onInjectFail;

        private bool stopThread { get; set; }
        public Dictionary<int, bool> DofusMods { get; set; }

        public Injector(Dictionary<int, bool> dictionary)
        {
            DofusMods = dictionary;
        }

        public void Start()
        {
            stopThread = false;
            ProcessDofus();
        }

        public void Stop()
        {
            stopThread = true;

        }

        public DllInjectionResult Inject(int dofusModId)
        {
            if (!(File.Exists(ApplicationPath + "\\No.Ankama.dll")))
            {
                throw new ArgumentException("Le fichier No.Ankama.dll ne se trouve pas dans le dossier. Veuillez vérifier cela avec votre Antivirus.");
            }
            DllInjector dllInjector = new DllInjector();
            return dllInjector.Inject(Convert.ToUInt32(dofusModId), ApplicationPath + "\\No.Ankama.dll");
        }

        public string ApplicationPath
        {
            get { return Environment.CurrentDirectory; }
        }

        public void ProcessDofus()
        {
            while (!stopThread)
            {
                List<Process> processDofusMod;

                processDofusMod = Process.GetProcessesByName("Dofus").ToList();
                if (processDofusMod.Count != 0)
                {
                    foreach (Process dofusMod in processDofusMod)
                    {
                        if (!DofusMods.ContainsKey(dofusMod.Id))
                        {
                            switch (Inject(dofusMod.Id))
                            {
                                case DllInjectionResult.DllNotFound:
                                    DofusMods.Add(dofusMod.Id, false);
                                    onInjectFail?.Invoke(dofusMod.Id, DllInjectionResult.DllNotFound, DofusMods);
                                    break;

                                case DllInjectionResult.GameProcessNotFound:
                                    DofusMods.Add(dofusMod.Id, false);
                                    onInjectFail?.Invoke(dofusMod.Id, DllInjectionResult.GameProcessNotFound, DofusMods);
                                    break;

                                case DllInjectionResult.InjectionFailed:
                                    DofusMods.Add(dofusMod.Id, false);
                                    onInjectFail?.Invoke(dofusMod.Id, DllInjectionResult.InjectionFailed, DofusMods);
                                    break;

                                case DllInjectionResult.Success:
                                    DofusMods.Add(dofusMod.Id, true);
                                    onInjectSuccess?.Invoke(dofusMod.Id, DllInjectionResult.Success, DofusMods);
                                    break;
                            };
                        }
                    }
                }
            }
        }
    }
}
