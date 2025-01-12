using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PlayerInteractble
{
    [SerializeField] AudioClip coinCollect;
    Vector3 offset = new Vector3(0, 1.5f, 0f);

    protected override void OnPlayerInteract()
    {

        base.OnPlayerInteract();
        AudioSource.PlayClipAtPoint(coinCollect, transform.position);
        PoolManager.SpawnObject("CoinCollect", transform.position+offset, Quaternion.identity);
        this.gameObject.SetActive(false);
        Debug.Log("Player Interacted");

    }
}
