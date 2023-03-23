using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private Vector2 playerInput;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float correctMovementSpeed = movementSpeed;

        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1);

        rb.velocity = new Vector3(playerInput.x, playerInput.y, 0) * correctMovementSpeed;
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;

    }
}
