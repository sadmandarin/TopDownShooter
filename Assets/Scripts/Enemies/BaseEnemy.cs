using System;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float _spawnProbability;
    [SerializeField] private int _moveSpeed;
    [SerializeField] protected int _hp;
    [SerializeField] private int _expForkill;

    public float SpawnProbability { get { return _spawnProbability; } }
    public int HP {  get { return _hp; } }
    public int ExpForKill {  get { return _expForkill; } }

    public event Action ZeroHp;

    protected EnemyMove _enemyMove;

    protected virtual void Start()
    {
        _enemyMove = gameObject.GetComponent<EnemyMove>();

        MoveToPlayer(_moveSpeed);
    }

    protected abstract void MoveToPlayer(int speed);

    public virtual void ReduceHp(int damage)
    {
        if (_hp > damage)
            _hp -= damage;
        else
        {
            _hp = 0;
            ZeroHp?.Invoke();
        }
            

    }
}
