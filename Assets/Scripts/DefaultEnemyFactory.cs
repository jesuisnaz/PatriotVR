using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject fighterEnemy;
    [SerializeField] private GameObject shahedEnemy;
    [SerializeField] private GameStateEventManager gameStateEventManager;

    internal override FighterEnemy DoCreateFighter(Vector3 spawnPoint, Transform parent)
    {
        GameObject newEnemy = fighterEnemy.GetComponent<ICloneable>().clone(spawnPoint, parent.rotation);
        newEnemy.transform.SetParent(parent);
        return newEnemy.GetComponent<FighterEnemy>();
    }

    internal override ShahedEnemy DoCreateShahed(Vector3 spawnPoint, Transform parent)
    {
        GameObject newEnemy = shahedEnemy.GetComponent<ICloneable>().clone(spawnPoint, parent.rotation);
        newEnemy.transform.SetParent(parent);
        return newEnemy.GetComponent<ShahedEnemy>();
    }

    internal override void SubscribeToEvents(IEventListener listener)
    {
        gameStateEventManager.Subscribe(GameController.GameState.GAME_OVER, listener);
    }

}
