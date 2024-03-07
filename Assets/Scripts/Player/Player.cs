using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
    }
}
