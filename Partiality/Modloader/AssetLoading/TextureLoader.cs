using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partiality.Modloader.AssetLoading {
    public class TextureLoader {
        public static TextureLoader textureLoader;

        public void Init() {
            textureLoader = this;
        }
    }
}