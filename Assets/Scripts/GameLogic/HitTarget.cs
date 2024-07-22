using UnityEngine;

public class HitTarget : MonoBehaviour
{
    private GunBase _gunType;

    private void Start()
    {
        _gunType = GetComponent<BulletMove>().GunType;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.GetComponent<BaseEnemy>())
            {
                other.gameObject.GetComponent<BaseEnemy>().ReduceHp(_gunType.Damage);

                Destroy(gameObject);
            }
        }
    }
}
