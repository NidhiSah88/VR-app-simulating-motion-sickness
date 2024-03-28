using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBodyMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public CharacterController characterController;
    public float speed = 300f;
    public float gravity = -9.8f;
    public float Gravity = 9.8f;
    private float velocity = 0;

// for collision

    private Rigidbody rb;
    public float movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
// for collision
      
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        if(characterController.isGrounded){
            velocity = 0;
            velocity -= Gravity * Time.deltaTime;
        }
        else{
            characterController.Move(new Vector3(0, velocity, 0));
        }

        Vector3 movement = new Vector3(x, 0.0f, y);
        rb.AddForce(movement * movementSpeed);
    }
// for collision
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false); // Disable the pickup object on collision
        }
    }
    
   
}
