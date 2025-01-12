using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLine : MonoBehaviour
{
    [SerializeField] GameObject[] coins;

    private void OnEnable()
    {
        for(int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
        }
    }
}
