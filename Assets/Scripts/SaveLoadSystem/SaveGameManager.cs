using System.IO;
using UnityEngine;


namespace SaveLoadSystem {
    public static class SaveGameManager {
        public static SaveData CurrentSaveData = new SaveData();

        private const string SaveDirectory = "/SaveData/";
        private const string FileName = "SaveGame.sav";

        public static bool SaveGame() {

            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);

            GUIUtility.systemCopyBuffer = dir;

            return true;
        }

        public static void LoadGame() {

            string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
            SaveData tempData = new SaveData();

            if (File.Exists(fullPath)) {
                string json = File.ReadAllText(fullPath);
                tempData = JsonUtility.FromJson<SaveData>(json);
            } else {
                // place code here in the future
            }

            CurrentSaveData = tempData;
        }
    }


}

