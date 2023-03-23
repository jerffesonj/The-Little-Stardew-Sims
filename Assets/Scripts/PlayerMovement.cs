using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator anim;

    private PlayerInput playerInput;
    private Vector2 moveVector;
    private Rigidbody2D rb;
    private bool isMoving = false;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveVector.x, moveVector.y, 0) * movementSpeed;
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Movement.performed += OnMovementPerformed;
        playerInput.Player.Movement.canceled += OnMovementCancelled;
    }
    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Movement.performed -= OnMovementPerformed;
        playerInput.Player.Movement.canceled -= OnMovementCancelled;
    }

    void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        isMoving = true;
        anim.SetBool("Moving", isMoving);
    }

    void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
        isMoving = false;
        anim.SetBool("Moving", isMoving);
    }
}
