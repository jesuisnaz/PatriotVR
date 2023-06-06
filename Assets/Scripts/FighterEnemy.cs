using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FighterEnemy : MonoBehaviour, ICloneable
{
    [Header("Enemy's speed")]
    public float speed = 20f;
    private GameObject target;

    private void Awake()
    {
        target = GameObject.Find("FighterJetTarget");
    }

    private void Start()
    {
        Destroy(this.gameObject, 15f);
        gameObject.transform.LookAt(target.transform);
    }

    private void Update()
    {
        transform.position += MovePerTime();
    }

    internal virtual Vector3 MovePerTime()
    {
        return speed * Time.deltaTime * this.transform.forward.normalized;
    }

    public GameObject clone(Vector3 position, Quaternion rotation)
    {
        return Instantiate(this.gameObject, position, Quaternion.identity);
    }
}
