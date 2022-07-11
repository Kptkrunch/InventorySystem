using System;
using System.Collections;
using System.Collections.Generic;
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

	void OnMove(InputAction.CallbackContext context)
	{
		playerController.OnMove(context);
	}
}
