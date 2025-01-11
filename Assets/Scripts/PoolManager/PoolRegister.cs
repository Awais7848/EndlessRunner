using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolRegister : MonoBehaviour
{
    [SerializeField] string poolTag;
    [SerializeField] float deactivateTime;
    // Start is called before the first frame update

    private void OnEnable()
    {
       
        Invoke("Deactivate", deactivateTime);
    }


    private void Deactivate()
    {
        //Debug.Log("Pool Tag !");

        PoolManager.Do.Destroy(poolTag, gameObject);
    }
}
