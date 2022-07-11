using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveLoadSystem;

public class SaveGameTester : MonoBehaviour
{
    public void SaveGame() {
        SaveGameManager.SaveGame();
    }

    public void LoadGame() {
        SaveGameManager.LoadGame();
    }
}
