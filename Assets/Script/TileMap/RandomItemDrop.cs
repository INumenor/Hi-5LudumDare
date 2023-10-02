using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RandomItemDrop : MonoBehaviour
{
    private GameObject[] AllTile;
    [SerializeField] List<GameObject> EmptyTile;
    [SerializeField] GameObject[] RandomItem;
    [SerializeField] private AudioSource _audioItemFall;
    private float maxtimevalue = 10f;
    private float timevalue = 5f;

    private void Start()
    {
        AllTile = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            AllTile[i] = transform.GetChild(i).gameObject;
        }
    }
     void Update()
    {
        
        timer();
        
    }
     
     public void timer()
     {
        
         if (timevalue <= 0)
         {
             timevalue = maxtimevalue;
             RandomItemCreator();
             _audioItemFall.Play();
             //Item fall
         }
         else
         {
             timevalue -= Time.deltaTime;
         }
     }
     
    public void RandomItemCreator()
    {
        EmptyTile.Clear();
        for (int i = 0; i < AllTile.Length; i++)
        {
            if (AllTile[i].GetComponent<TileSlot>()._isFull == false)
            {
                EmptyTile.Add(AllTile[i]);
            }
        }
        int iLengt = EmptyTile.Count;
        int iRandomSlot = Random.Range(0, iLengt);
        Debug.Log(RandomItem.Length);
        int iRandomItem = Random.Range(0, RandomItem.Length);
        if(EmptyTile[iRandomSlot].GetComponent<TileSlot>()._isFull == false)
        {
            GameObject CopyRandomItem = Instantiate(RandomItem[iRandomItem], new Vector2(0, 0), Quaternion.identity);
            CopyRandomItem.transform.parent = EmptyTile[iRandomSlot].transform;
            CopyRandomItem.name = RandomItem[iRandomItem].name;
            CopyRandomItem.transform.localPosition = new Vector2(0, 0);
            EmptyTile[iRandomSlot].GetComponent<TileSlot>()._isFull = true;
        }
    }



}
