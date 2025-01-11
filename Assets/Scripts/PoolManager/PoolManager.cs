using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    
    [System.Serializable]

    class ObjectsToPool
    {

      public  string Tag;
      public   GameObject prefab;
      public  int size;


    }



    public static PoolManager Do;

    [Header("Objects To Pool")]
    [SerializeField] ObjectsToPool[] pool;
   
    Dictionary<string,Queue<GameObject>>  PoolObjects;
    

    GameObject temp;
    private void Awake()
    {
        Do = this;
        PoolObjects = new Dictionary<string, Queue<GameObject>>();
        foreach(ObjectsToPool poolObject in pool)
        {
            Queue<GameObject> objects = new Queue<GameObject>();


            for(int i=0;i<poolObject.size;i++)
            {
                GameObject temp = Instantiate(poolObject.prefab);
                temp.name=poolObject.Tag;
                temp.SetActive(false);

                objects.Enqueue(temp);

            }

            PoolObjects.Add(poolObject.Tag, objects);
            
        }
       
    }
    public GameObject Spawn(string Tag,Vector3 position,Quaternion rotation,Transform parent=null)
    {
        Debug.Log(PoolObjects[Tag]);
        temp = PoolObjects[Tag].Dequeue();
        if (parent!=null)
        {
            temp.transform.parent = parent;
        }
        temp.transform.position = position;
        temp.transform.rotation = rotation;

        temp.SetActive(true);


        return temp;

    }

    public void Destroy(string Tag,GameObject gameObject)
    {
        Debug.Log(tag);
        gameObject.SetActive(false);
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;

        PoolObjects[Tag].Enqueue(gameObject);


    }

}
