using System;
using UnityEngine;

public class GameInputManager : MonoBehaviour {
    private InputSystem_Actions inputActions;
    public static GameInputManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }


    public Vector2 GetPlayerMovement() {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }

}
