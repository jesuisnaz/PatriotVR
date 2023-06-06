using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    [SerializeField] private GameObject enemyExplosion;
    [SerializeField] private GameObject enemyFractured;
    [SerializeField] internal float scoreMultiplier = 10f;
    private GameController gameController;

    private bool IsDestroyed = false;

    private void Start()
    {
        gameController = GameController.Instance;
    }

    public void EnemyDestroyed()
    {
        if (IsDestroyed)
        {
            return;
        }

        IsDestroyed = true;
        Explode();
        gameController.HandleEnemyDestroyed(this);
    }

    public void Explode()
    {
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
        GameObject fractured = Instantiate(enemyFractured, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        PushObjectsCloseToExplosion(fractured);
    }

    private void PushObjectsCloseToExplosion(GameObject fractured)
    {
        Collider[] colliders = Physics.OverlapSphere(fractured.transform.position, 10f);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<Rigidbody>() == null) continue;
            collider.GetComponent<Rigidbody>().AddExplosionForce(20f, this.transform.position, 1f, 0, ForceMode.Impulse);
        }
    }
}
