using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiality.Modloader {
    public class PartialityMod {

        public string ModID = "NULL";
        public string Version = "0000";
        public int loadPriority = 0;
        public string author = "NULL";

        public bool isEnabled;

        public ModDependency[] modDependencies = new ModDependency[]{ };

        internal void BaseInit() {
            Init();
        }

        internal void BaseLoad() {
            OnLoad();
        }

        public void DisableMod() {
            if( !isEnabled )
                return;
            isEnabled = false;
            OnDisable();
        }

        public void EnableMod() {
            if( isEnabled )
                return;
            isEnabled = true;
            OnEnable();
        }

        internal virtual void Init() {

        }

        internal virtual void OnLoad() {

        }

        internal virtual void OnDisable() {

        }

        internal virtual void OnEnable() {

        }

    }
}