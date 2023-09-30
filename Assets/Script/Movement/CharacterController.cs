using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    public float Vertical, Horizontal;

    Vector2 movement;

    public Rigidbody2D myRigidBody2D;
    public GameObject HoldSpot;
    private GameObject ItemHolding;
    public bool IsHolding=false;
    private bool KeyPress=false;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("ground") && KeyPress==false )
        {

            ItemHolding = other.gameObject;
            KeyPress = true;
            
            if (ItemHolding.transform.childCount>0 && IsHolding==false && ItemHolding.GetComponent<TileSlot>()._isFull==true)
            {
                
                GameObject Item = ItemHolding.transform.GetChild(0).gameObject;
                Item.transform.position = HoldSpot.transform.position;
                Item.transform.parent = HoldSpot.transform;
                IsHolding = true;
                ItemHolding.GetComponent<TileSlot>()._isFull = false;
            }
            else if (ItemHolding.transform.childCount == 0 && IsHolding==true && ItemHolding.GetComponent<TileSlot>()._isFull == false)
            {
                GameObject Item = HoldSpot.transform.GetChild(0).gameObject;
                Item.transform.position = ItemHolding.transform.position;
                Item.transform.parent = ItemHolding.transform;
                IsHolding = false;
                ItemHolding.GetComponent<TileSlot>()._isFull = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            KeyPress = false;
        }
        
    }
}

