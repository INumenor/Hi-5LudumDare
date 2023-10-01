using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisplay : MonoBehaviour
{
    public Texture[] Items;
    public GameObject Task;
    public GameObject Canvas;
    public GameObject[] Tasks;
    // Start is called before the first frame update
    void Start()
    {
        Task.GetComponent<CreatingTask>().obj1.texture = Items[0];
        Task.GetComponent<CreatingTask>().obj2.texture = Items[1];
        Task.GetComponent<CreatingTask>().obj3.texture = Items[2];
        GameObject CopyTask = Instantiate(Task,new Vector2(0,0),Quaternion.identity);
        CopyTask.transform.parent = Canvas.transform;
        CopyTask.transform.localPosition = new Vector2(-180,100);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
