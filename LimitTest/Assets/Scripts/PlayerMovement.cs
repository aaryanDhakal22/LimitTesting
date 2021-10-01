using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    
    //movement vars
    public float movementSpeed = 6.9f;

    //jump & gravity
    public float gravity = 9.81f;
    public float jumpSpeed = 2f;
    public float storeJump;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }//start

    // Update is called once per frame
    void Update()
    {
        //movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        //jump & gravity

        if(characterController.isGrounded){
            
            if(Input.GetButtonDown("Jump")){
                storeJump = jumpSpeed;
            }
        }//ground check

        
        storeJump -= gravity * Time.deltaTime;
        move.y = storeJump;




        characterController.Move(move * movementSpeed * Time.deltaTime);




    }//update
}
