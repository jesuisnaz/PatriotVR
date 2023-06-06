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
        if (collision.gameObject.GetComponent<EnemyHit>() != null)
        {
            collision.gameObject.GetComponent<EnemyHit>().EnemyDestroyed();
        }
        else if (collision.gameObject.GetComponent<IShootable>() != null)
        {
            collision.gameObject.GetComponent<IShootable>().OnHit();
        }

    }
}
