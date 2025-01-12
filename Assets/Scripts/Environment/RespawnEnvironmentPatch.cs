using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnvironmentPatch : MonoBehaviour
{
    [SerializeField] float respawnAfterSeconds;
    [SerializeField] GameObject patch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(SpawnNext), respawnAfterSeconds);
        }
    }

    void SpawnNext()
    {

        EnvironmentManager.Instance.Respawn(patch);
    }



}
