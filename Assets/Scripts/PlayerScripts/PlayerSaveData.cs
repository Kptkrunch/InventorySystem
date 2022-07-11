using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SaveLoadSystem;


public class PlayerSaveData : MonoBehaviour
{
    public int currentHealth = 10;
    private PlayerData MyData = new PlayerData();

    void Update()
    {
        var transformCache = transform;
        MyData.PlayerPosition = transformCache.position;
        MyData.PlayerRotation = transformCache.rotation;
        MyData.CurrentHealth = currentHealth;

        if(Keyboard.current.tKey.wasPressedThisFrame) {
            SaveGameManager.CurrentSaveData.PlayerData = MyData;
            SaveGameManager.SaveGame();
        }

        if (Keyboard.current.gKey.wasPressedThisFrame) {
            SaveGameManager.LoadGame();
            MyData = SaveGameManager.CurrentSaveData.PlayerData;
            transform.position = MyData.PlayerPosition;
            transform.rotation = MyData.PlayerRotation;
            currentHealth = MyData.CurrentHealth;

        }
    }
}

[System.Serializable] 
public struct PlayerData {

    public Vector2 PlayerPosition;
    public Quaternion PlayerRotation;
    public int CurrentHealth;
}
