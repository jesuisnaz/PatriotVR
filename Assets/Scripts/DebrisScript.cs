using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisScript : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
