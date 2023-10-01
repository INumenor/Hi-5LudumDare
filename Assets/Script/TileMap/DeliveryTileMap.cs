using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeliveryTileMap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Circle;
    [SerializeField] GameObject Area;
    [SerializeField] float xbuffer;
    [SerializeField] float ybuffer;

    void Awake()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        int i = 0;
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    i++;
                    //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                    GameObject CopyCircle = Instantiate(Circle, new Vector2(x - (bounds.size.x) + xbuffer, y - (bounds.size.y) + ybuffer), Quaternion.identity);
                    CopyCircle.name = "CopyCircle" + x + y;
                    CopyCircle.transform.parent = Area.transform;
                    CopyCircle.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = i.ToString();
                }
                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
                
            }
        }
    }
}
