public class HeavyEnemy : BaseEnemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void MoveToPlayer(int speed)
    {
        StartCoroutine(_enemyMove.MoveEnemy(speed));
    }

    public override void ReduceHp(int damage)
    {
        base.ReduceHp(damage);
    }
}
