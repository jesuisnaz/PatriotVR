using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;
using static UnityEngine.GraphicsBuffer;

public class FighterEnemy : MonoBehaviour, IEnemy, ICloneable
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

    public void Notify(GameController.GameState state)
    {
        if (this == null) return;
        if (state == GameController.GameState.GAME_OVER)
        {
            Debug.Log("Handling game over event in fighter");
            GameController.Instance.UnsubscribeFromEvents(GameState.GAME_OVER, this);
            GetComponent<EnemyHit>().Explode();
        }
    }
}
