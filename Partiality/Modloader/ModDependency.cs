using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiality.Modloader {
    public struct ModDependency {
        public string requiredID;
        public string requiredVersion;

        public ModDependency(string id, string version) {
            requiredID = id;
            requiredVersion = version;
        }

        public override int GetHashCode() {
            return ( requiredID + requiredVersion ).GetHashCode();
        }
    }
}
