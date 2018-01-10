using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Partiality.Modloader;
using UnityEngine;

namespace Partiality {
    public class PartialityManager {

        //-----Instance-----
        public static PartialityManager Instance {
            get { return internal_instance; }
        }
        private static PartialityManager internal_instance;

        public static string mainPath;
        public ModManager modManager;

        public PartialityManager() {
            modManager = new ModManager();
            modManager.Init();
        }

        public static void CreateInstance() {
            if( Instance != null )
                return;

            internal_instance = new PartialityManager();
        }

    }
}