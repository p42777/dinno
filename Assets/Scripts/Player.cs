using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{

    private CharacterController character;
    private Vector3 direction;
    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;

    // Awake is called automatically when the script is initialized
    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    // OnEnable is called when the script is enabled
    private void OnEnable()
    {
        direction = Vector3.zero; // reset the direction to zero
    }

    // Update is called once per frame when game is running
    void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;
        if (character.isGrounded)
        {
            // no gravity applied if player on ground
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            { // check every single frame
                direction = Vector3.up * jumpForce;
            }
        }
        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

}
