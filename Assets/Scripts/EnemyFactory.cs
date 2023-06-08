using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public FighterEnemy CreateFighter(Vector3 spawnPoint, Transform parent)
    {
        FighterEnemy enemy = DoCreateFighter(spawnPoint, parent);
        SubscribeToEvents(enemy);
        return enemy;
    }

    public ShahedEnemy CreateShahed(Vector3 spawnPoint, Transform parent)
    {
        ShahedEnemy enemy = DoCreateShahed(spawnPoint, parent);
        SubscribeToEvents(enemy);
        return enemy;
    }

    internal abstract FighterEnemy DoCreateFighter(Vector3 spawnPoint, Transform transform);

    internal abstract ShahedEnemy DoCreateShahed(Vector3 spawnPoint, Transform transform);

    internal abstract void SubscribeToEvents(IEventListener listener);
}
