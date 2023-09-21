using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float jumpHeight = 4.0f;
    public float playerSpeed = 15.0f;
    public float gravityValue = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <0)
        {
            playerVelocity.y = 0f;
        }   

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Here is the actual movement
        controller.Move(move * Time.deltaTime * playerSpeed);

        //Changes the direction the character faces
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
