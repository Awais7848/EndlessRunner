using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PlayerInteractble
{



    protected override void OnPlayerInteract()
    {
        base.OnPlayerInteract();
        Debug.Log("Player Interacted");
    }
}
