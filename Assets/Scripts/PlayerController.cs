using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float playerSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer() {

        Vector2 movementInput = GameInputManager.Instance.GetPlayerMovement();

        Vector2 movement = movementInput * playerSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }
}