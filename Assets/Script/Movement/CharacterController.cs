using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] private GameObject InteractionSpot;
    public float Vertical, Horizontal;
    private int Health = 3;

    public int _Health
    {
        get
        {
            return Health;
        }
        set
        {
            Health = value;
            if (Health <= 0)
            {
                Debug.Log("GAME OVER");
            }
        }
    }

    Vector2 movement;

    public Rigidbody2D myRigidBody2D;
    public GameObject HoldSpot;
    private GameObject ItemHolding;
    public bool IsHolding=false;
    [SerializeField] Animator chanimator;
    private Collider2D _other;
    private GameObject target;
    private bool pickuping = false;
    private Vector2 LastDirection;

    public void ChangeInteractionDirection(int arg)
    {
        InteractionSpot.transform.rotation = Quaternion.Euler(Vector3.forward * arg);
    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //Debug.Log(movement.x + ":x" + " " + movement.y + ":y");
        if (movement.sqrMagnitude <= 0.1)
        {
            
            //chanimator.SetFloat("Horizontal", movement.x);
            //chanimator.SetFloat("Vertical", movement.y);
            chanimator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            chanimator.SetFloat("Horizontal", movement.x);
            chanimator.SetFloat("Vertical", movement.y);
            chanimator.SetFloat("Speed", movement.sqrMagnitude);
            
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    LastDirection = Vector2.right;
                }
                else
                {
                    LastDirection = Vector2.left;
                }
            }
            else
            {
                if (movement.y > 0)
                {
                    LastDirection = Vector2.up;
                }
                else
                {
                    LastDirection = Vector2.down;
                }
            }
        }

        
        
        if (IsHolding == false)
        {
            chanimator.SetBool("isHolding", false);
        }
        else if(IsHolding == true)
        {
            chanimator.SetBool("isHolding",true);
            //chanimator.SetFloat("Horizontal", movement.x);
            //chanimator.SetFloat("Vertical", movement.y);
            //chanimator.SetFloat("Speed", movement.sqrMagnitude);
        }
        
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (target.GetComponent<GrindingMachine>() != null)
            {
                target.GetComponent<GrindingMachine>().isGrind = true;
            }
            else if (target.GetComponent<MergingSlot>() != null)
            {
                target.transform.parent.GetComponent<MergingTable>().isGrind = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            if (target.GetComponent<GrindingMachine>() != null)
            {
                target.GetComponent<GrindingMachine>().isGrind = false;
            }
            else if (target.GetComponent<MergingSlot>() != null)
            {
                target.transform.parent.GetComponent<MergingTable>().isGrind = true;
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("BBBBBB");

            if (target != null )
            {
                pickuping = true;
                //Debug.Log("Target var");
                //Debug.Log("IsHolding " + IsHolding.ToString());
                //Debug.Log("Target Fullnes " + (target.GetComponent<TileSlot>()._isFull == true).ToString());
                //Debug.Log(target.name);

                if (IsHolding == false && target.GetComponent<TileSlot>()._isFull == true)
                {
                   
                    Debug.Log(target.GetComponent<Collider2D>().enabled);
                    GameObject Item = target.transform.GetChild(0).gameObject;
                    Item.transform.position = HoldSpot.transform.position;
                    Item.transform.parent = HoldSpot.transform;
                    IsHolding = true;
                    Item.GetComponent<Collider2D>().enabled = false;
                    target.GetComponent<TileSlot>()._isFull = false;
                    Debug.Log(target.GetComponent<Collider2D>().enabled);
                    //
                }
                else if (IsHolding == true && target.GetComponent<TileSlot>()._isFull == false)
                {
                   
                    GameObject Item = HoldSpot.transform.GetChild(0).gameObject;
                    Item.transform.position = target.transform.position;
                    Item.transform.parent = target.transform;
                    IsHolding = false;
                    Item.GetComponent<Collider2D>().enabled = true;
                    target.GetComponent<TileSlot>()._isFull = true;
                    
                    //
                }

            }


            pickuping = false;
        }

        InteractionSpot.transform.localPosition = new Vector3(LastDirection.x, LastDirection.y, 0);
    }

    void FixedUpdate()
    {
        myRigidBody2D.MovePosition(myRigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void checking(Collider2D other)
    {
        if (other.CompareTag("ground") && pickuping == false || other.CompareTag("Station") && pickuping == false || other.CompareTag("Delivery") && pickuping == false)
        {
            target = other.gameObject;
        }
    }

}

