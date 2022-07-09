using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace SaveLoadSystem {
    public static class SaveGameManager {
        public static SaveData CurrentSaveData = new SaveData();

        public const string SaveDirectory = "/SaveData/";
        public const string FileName = "SaveGame.sav";

        public static bool Save() {

            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);

            GUIUtility.systemCopyBuffer = dir + FileName;

            return true;
        }
    }
}

