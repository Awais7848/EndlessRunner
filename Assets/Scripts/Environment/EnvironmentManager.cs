using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnvironmentManager : MonoBehaviour
{
    string poolName = "Patch";

    float zdiff = 105;
    float lastOffset=-455f;

    public static EnvironmentManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void   Start()
    {
       
        Application.targetFrameRate = 60;
        for (int i = 0; i < 3; i++)
        {
           GameObject g= PoolManager.SpawnObject("Patch", new Vector3(0, 0, lastOffset), Quaternion.identity);
          lastOffset += zdiff;
        }
    }


  public  void Respawn(GameObject patch)
    {
        // PoolManager.Do.Destroy("Patch", patch);
        //   PoolManager.Do.Spawn("Patch", new Vector3(0, 0, lastOffset), Quaternion.identity);
        patch.transform.position = new Vector3(0, 0, lastOffset);
        lastOffset += zdiff;
    }

}
