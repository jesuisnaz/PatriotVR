using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShahedHit : MonoBehaviour
{

    [SerializeField] private GameObject shahedExplosion;
    [SerializeField] private GameObject shahedFractured;
    private GameController gameController;

    private bool IsDestroyed = false;

    private void Awake()
    {
        gameController = GameController.Instance;
    }

    public void ShahedDestroyed()
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
        Instantiate(shahedExplosion, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
        GameObject fractured = Instantiate(shahedFractured, this.transform.position, this.transform.rotation);
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
