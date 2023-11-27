using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed
    public float moveSpeed = 5f; //Speed of movement
    public float turnSpeed = 3f; //Speed of turn
    public float sprintMultiplier = 1.5f; //Multiplier for sprint speed
    public float jumpForce = 5f; //Force of jump
    public float lookSpeed = 3f; //Speed of looking up and down
    public float lookLimit = 80f; //Limit for looking up and down

    public float horizontalRotation = 0f; //Track horizontal rotation
    public float verticalRotation = 0f; //Track vertical rotation
    private bool isGrounded; //Check if player is grounded

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= moveSpeed * sprintMultiplier * Time.deltaTime;
        }
        else
        {
            movement *= moveSpeed * Time.deltaTime;
        }

        transform.Translate(movement);

        //Turning
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        horizontalRotation += mouseX * turnSpeed;
        verticalRotation += mouseY * lookSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -lookLimit, lookLimit);

        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded= false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //Check if the player is grounded
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
