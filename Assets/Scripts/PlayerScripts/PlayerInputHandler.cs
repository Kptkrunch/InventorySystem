using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
	public GameObject playerPrefab;
	private PlayerController playerController;
	
	private void Awake()
	{
		if (playerPrefab != null)
		{
			playerController = playerPrefab.GetComponent<PlayerController>();
		}
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		Debug.Log("OnMove being called");
		playerController.OnMove(context);
	}
}
