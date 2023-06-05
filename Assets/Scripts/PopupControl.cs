using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
 
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        Destroy(gameObject, 3f);
    }
}
