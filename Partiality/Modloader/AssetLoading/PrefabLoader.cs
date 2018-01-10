using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiality.Modloader.AssetLoading {
    public class PrefabLoader {
        public static PrefabLoader prefabLoader;

        public void Init() {
            prefabLoader = this;
        }
    }
}
