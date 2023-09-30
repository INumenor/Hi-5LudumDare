using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] float moveSpeed ;

    public float Vertical,Horizontal;

    Vector2 movement;

    public Rigidbody2D myRigidBody2D;

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        myRigidBody2D.MovePosition(myRigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
