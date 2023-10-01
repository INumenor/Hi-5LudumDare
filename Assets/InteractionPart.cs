using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.parent.GetComponent<CharacterController>().checking(other);
    }
}
