using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private BaseEnemy _enemy;

    private void OnEnable()
    {
        _enemy = GetComponent<BaseEnemy>();
        _enemy.ZeroHp += DestroyEnemyOnZeroHp;
    }

    private void OnDisable()
    {
        _enemy.ZeroHp -= DestroyEnemyOnZeroHp;
    }

    void DestroyEnemyOnZeroHp()
    {
        Destroy(gameObject);
    }

}

