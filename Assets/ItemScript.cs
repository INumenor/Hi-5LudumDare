using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
   public float maxGrindValue = 5;
   public float maxPotionValue = 5;
   public bool isGrindable = false;
   public bool isPotionable = false;
   private float grindValue = 0;
   private float potionValue = 0;
   [SerializeField] private GameObject grindedVersion;
   
   public float _grindValue
   {
      get
      {
         return grindValue;
      }
      set
      {
         grindValue = value;
         Debug.Log(grindValue);
         if (value >= maxGrindValue)
         {
            Debug.Log("İşlemi tamamla");
            isGrindable = false;
            GameObject shineyObject = Instantiate(grindedVersion, new Vector2(0, 0), Quaternion.identity);
            shineyObject.transform.parent = this.transform.parent;
            shineyObject.transform.localPosition = Vector2.zero;
            //Destroy(this);
            Destroy(gameObject);
         }
      }
   }
}
