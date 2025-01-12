using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractble : MonoBehaviour
{
    [Header("Interaction Method")]
    [SerializeField] bool Trigger;

     Collider[] colliders; 

    private void Awake()
    {
        colliders = GetComponents<Collider>();


        foreach(Collider collider in colliders)
        {
            collider.isTrigger = Trigger;
            
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (Trigger)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerInteract();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!Trigger)
        {
            if (collision.collider.CompareTag("Player"))
            {
                OnPlayerInteract();
            }
        }
    }


    protected virtual void OnPlayerInteract()
    {
        Debug.Log("Compare Tag");
       

    }
}
