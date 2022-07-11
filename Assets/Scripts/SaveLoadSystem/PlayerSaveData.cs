using UnityEngine;
using UnityEngine.InputSystem;
using SaveLoadSystem;


public class PlayerSaveData : MonoBehaviour
{
    public int currentHealth = 10;
    private PlayerData myData = new PlayerData();

    private void Update()
    {
        var transformCache = transform;
        myData.playerPosition = transformCache.position;
        myData.playerRotation = transformCache.rotation;
        myData.currentHealth = currentHealth;

        if(Keyboard.current.tKey.wasPressedThisFrame) {
            SaveGameManager.CurrentSaveData.playerData = myData;
            SaveGameManager.SaveGame();
        }

        if (Keyboard.current.gKey.wasPressedThisFrame) {
            SaveGameManager.LoadGame();
            myData = SaveGameManager.CurrentSaveData.playerData;
            transform.position = myData.playerPosition;
            transform.rotation = myData.playerRotation;
            currentHealth = myData.currentHealth;

        }
    }
}

[System.Serializable] 
public struct PlayerData {

    public Vector2 playerPosition;
    public Quaternion playerRotation;
    public int currentHealth;
}
