using System.Collections;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private int _speed = 7;
    private Vector3 _direction;
    private Vector3 _targetPositionForGrenade;
    private float _grenadeExplosionRadius = 2f;

    public GunBase GunType;

    private void Start()
    {
        StartCoroutine(Move());
    }

    public void SetGunType(GunBase guntype)
    {
        GunType = guntype;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetTargetPoint(Vector3 target)
    {
        _targetPositionForGrenade = target;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (!(GunType is GrenadeLauncher))
            {
                transform.Translate(_direction * _speed * Time.deltaTime);

                yield return null;

                if (GunType is Shotgun)
                    Destroy(gameObject, 7 / _speed);
                else
                    Destroy(gameObject ,40 / _speed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPositionForGrenade, _speed * Time.deltaTime);

                yield return null;

                if (Vector3.Distance(transform.position, _targetPositionForGrenade) < 0.1f)
                {
                    Explode();
                }
            }
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _grenadeExplosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.GetComponent<BaseEnemy>())
            {
                BaseEnemy enemy = nearbyObject.GetComponent<BaseEnemy>();
                if (enemy != null)
                {
                    enemy.ReduceHp(GunType.Damage);
                }
            }
        }

        Destroy(gameObject);
    }
}
