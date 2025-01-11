using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    string poolName = "Patch";

    float zdiff = 105;
    float initializeFloat = -350f;
    float lastOffset=-455f;

    public static EnvironmentManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    IEnumerator   Start()
    {
       
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 4; i++)
        {
            PoolManager.Do.Spawn("Patch", new Vector3(0, 0, lastOffset), Quaternion.identity);
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
