using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float horizontalValue = 0;
    private float verticalValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float correctMovementSpeed = movementSpeed / 100;

        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalValue, verticalValue, 0) * correctMovementSpeed;
    }
}
