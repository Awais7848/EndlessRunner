using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : PlayerInteractble
{


    protected override void OnPlayerInteract()
    {
        base.OnPlayerInteract();
        Debug.Log("Game Over !");
    }
}
