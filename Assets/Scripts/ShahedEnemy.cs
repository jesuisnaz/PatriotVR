using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class ShahedEnemy : MonoBehaviour, IEventListener, ICloneable
{

    [Header("Shahed's speed")]
    public float speed = 10f;

    [Header("Target to aim at")]
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendHoming(this.gameObject));
    }

    private IEnumerator SendHoming(GameObject shahed)
    {
        while (Vector3.Distance(target.transform.position, shahed.transform.position) > 0.3f)
        {
            shahed.transform.position += MovePerTime(shahed);
            shahed.transform.LookAt(target.transform);
            yield return null;
        }
        this.GetComponent<EnemyHit>().EnemyDestroyed();
        GameController.Instance.UnsubscribeFromEvents(GameState.GAME_OVER, this);
        GameController.Instance.GameOver();
    }

    internal virtual Vector3 MovePerTime(GameObject shahed)
    {
        return (target.transform.position - shahed.transform.position).normalized * speed * Time.deltaTime;
    }


    public GameObject clone(Vector3 position, Quaternion rotation)
    {
        return Instantiate(this.gameObject, position, rotation);
    }

    public void Notify(GameState state)
    {
        if (this == null) return; 
        Debug.Log("Shahed is notified");
        if (state == GameState.GAME_OVER)
        {
            Debug.Log("Handling game over event in shahed");
            GameController.Instance.UnsubscribeFromEvents(GameState.GAME_OVER, this);
            GetComponent<EnemyHit>().Explode();
        }
    }
}
