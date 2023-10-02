using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
   public float maxGrindValue = 5;
   public int ID;
   public float maxPotionValue = 5;
   public bool isGrindable = false;
   public bool isPotionable = false;
   private float grindValue = 0;
   private float potionValue = 0;
   [SerializeField] private GameObject grindedVersion;
   [SerializeField] private GameObject potionVersion;

   public float _potionValue
   {
      get
      {
         return potionValue;
      }
      set
      {
         potionValue = value;
         Debug.Log(potionValue);
         if (value >= maxPotionValue)
         {
            isPotionable = false;
            Debug.Log("İşlemi tamamla");
            GameObject shineyObject = Instantiate(potionVersion, new Vector2(0, 0), Quaternion.identity);
            shineyObject.transform.parent = this.transform.parent;
            shineyObject.transform.localPosition = Vector2.zero;
            //Destroy(this);
            Destroy(gameObject);
         }
      }
   }
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
            //shineyObject.transform.SetSiblingIndex(this.transform.GetSiblingIndex() - 1);
            //Destroy(this);
            Destroy(gameObject);
         }
      }
   }
}
