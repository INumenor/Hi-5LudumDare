using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    public GameObject HoldSpot;
    private GameObject ItemHolding;
   
   
    private void OnCollisionStay2D(Collision2D other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            ItemHolding = other.gameObject;
            ItemHolding.transform.position = HoldSpot.transform.position;
            ItemHolding.transform.parent = HoldSpot.transform;
            ItemHolding.GetComponent<SpriteRenderer>().sortingOrder +=1 ;
            if (ItemHolding.GetComponent<Rigidbody2D>())
            {
                ItemHolding.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
    }
    
}
