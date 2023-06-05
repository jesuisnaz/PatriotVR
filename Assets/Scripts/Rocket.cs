using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Shot something: ");
        if (collision.gameObject.GetComponent<ShahedHit>() != null)
        {
            collision.gameObject.GetComponent<ShahedHit>().ShahedDestroyed();
        }
        else if (collision.gameObject.GetComponent<IShootable>() != null)
        {
            Debug.Log("Shot IShootable");
            collision.gameObject.GetComponent<IShootable>().OnHit();
        }

    }
}
