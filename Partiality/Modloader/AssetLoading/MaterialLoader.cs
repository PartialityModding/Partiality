using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiality.Modloader.AssetLoading {
    public class MaterialLoader {
        public static MaterialLoader materialLoader;

        public void Init() {
            materialLoader = this;
        }
    }
}