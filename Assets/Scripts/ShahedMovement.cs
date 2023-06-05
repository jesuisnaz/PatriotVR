using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShahedMovement : MonoBehaviour, ICloneable
{

    [Header("Shahed's speed")]
    public float speed = 10f;

    [Header("Target to aim at")]
    public GameObject target;
    private GameController gameController;

    private void Awake()
    {
        gameController = GameController.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendHoming(this.gameObject));
    }

    private IEnumerator SendHoming(GameObject shahed)
    {
        while (Vector3.Distance(target.transform.position, shahed.transform.position) > 0.3f)
        {
            shahed.transform.position += (target.transform.position - shahed.transform.position).normalized * speed * Time.deltaTime;
            shahed.transform.LookAt(target.transform);
            yield return null;
        }
        this.GetComponent<ShahedHit>().ShahedDestroyed();
        gameController.GameOver();
    }

    public GameObject clone(Vector3 position, Quaternion rotation)
    {
        GameObject gameObject = Instantiate(this.gameObject, position, rotation);
        return gameObject;
    }
}
