using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Partiality.Modloader.AssetLoading;

using UnityEngine;

namespace Partiality.Modloader {
    public class ModManager {

        public List<PartialityMod> loadedMods;
        private Dictionary<string, PartialityMod> loadedModsDictionary;
        private Dictionary<string, string> loadedModsInfo;

        public void Init() {

            loadedMods = new List<PartialityMod>();
            loadedModsDictionary = new Dictionary<string, PartialityMod>();
            loadedModsInfo = new Dictionary<string, string>();

            LoadAllMods();
        }

        public void LoadAllMods() {

            //Get all the .dll files in the "Mods" folder and subfolders for the game
            string modsPath = Path.Combine( PartialityManager.mainPath, "Mods" ) + '/';
            string[] modFiles = Directory.GetFiles( modsPath, "*.dll", SearchOption.AllDirectories );

            //Check for dependencies. Load mods that have all dependencies, skip ones that don't.
            foreach( string filePath in modFiles ) {
                try {
                    Assembly modAssembly = Assembly.LoadFrom( filePath );
                    Debug.Log( "Loaded Assembly :" + modAssembly.FullName );
                } catch( System.Exception e ) {
                    Debug.LogError( e );
                }
            }

            Type modType = typeof( PartialityMod );
            List<Type> modTypes = new List<Type>();

            //Loop through all types that are loaded currently.
            foreach( Assembly currentAssembly in AppDomain.CurrentDomain.GetAssemblies() ) {
                try {
                    foreach( Type t in currentAssembly.GetTypes() ) {
                        try {
                            //If the base type matches the partiality mod type, then load it as a mod.
                            if( t.BaseType == modType ) {
                                modTypes.Add( t );
                            }
                        } catch( System.Exception e ) {
                            Debug.LogError( e );
                        }
                    }
                } catch( System.Exception e ) {
                    Debug.LogError( e );
                }
            }

            //Load mods from types
            foreach( Type t in modTypes ) {
                try {
                    PartialityMod newMod = (PartialityMod)Activator.CreateInstance( t );

                    newMod.BaseInit();
                    newMod.Init();

                    loadedMods.Add( newMod );
                    loadedModsDictionary.Add( newMod.ModID, newMod );
                    loadedModsInfo.Add( newMod.ModID, newMod.Version );

                    Debug.Log("Initialized mod " + newMod.ModID + "succesfully." );

                } catch( System.Exception e ) {
                    Debug.LogError( "Problem loading mod from type " + t.Name + "! \n" + e );
                }
            }

            //Call mod load function
            foreach( PartialityMod pMod in loadedMods ) {
                Debug.Log( "Loaded mod " + pMod.ModID + " succesfully." );
                try {
                    pMod.BaseLoad();
                    pMod.OnLoad();
                    pMod.OnEnable();
                } catch( System.Exception e ) {
                    Debug.LogError( e );
                }
            }

        }

        public void DisableMod(string modID) {
            if( loadedModsDictionary.ContainsKey( modID ) )
                DisableMod( loadedModsDictionary[modID] );
        }
        public void DisableMod(PartialityMod mod) {
            mod.DisableMod();
        }

        public void EnableMod(string modID) {
            if( loadedModsDictionary.ContainsKey( modID ) )
                EnableMod( loadedModsDictionary[modID] );
        }
        public void EnableMod(PartialityMod mod) {
            mod.EnableMod();
        }

    }
}