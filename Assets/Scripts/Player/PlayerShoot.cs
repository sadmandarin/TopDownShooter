using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private BulletMove _bullet;
    [SerializeField] private GameObject _grenade;
    [SerializeField] private GunBase _gun;

    private Coroutine _coroutine;
    private float _spreadAngle = 10f;
    private int _bulletCount = 5;
    private Vector3 _targetForGrenade;
    private bool _isShootingInProgress;

    public bool IsShooting;
    public GunBase GunType { get { return _gun; } }

    private void Update()
    {
        if (_gun != null)
        {
            if (IsShooting && !_isShootingInProgress)
            {
                _isShootingInProgress = true;
                _coroutine = StartCoroutine(ShootBullet());
            }
        }
    }

    public void SetGunType(GunBase gun)
    {
        if (_gun != null)
        {
            _gun = null;
        }

        _gun = gun;
    }

    public void SetTargetForGrenade(Vector3 target)
    {
        _targetForGrenade = target;
    }

    private IEnumerator ShootBullet()
    {
        while (IsShooting)
        {
            Debug.Log("Shooting");

            if (_gun is Shotgun)
            {
                Debug.Log("Shotgun");
                float angleStep = _spreadAngle / (_bulletCount - 1);
                float startAngle = -_spreadAngle / 2;
                for (int i = 0; i < _bulletCount; i++)
                {
                    float angle = startAngle + (angleStep * i);

                    Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                    Vector3 bulletDirection = (transform.forward + offset).normalized;

                    GameObject bullet = Instantiate(_bullet.gameObject, transform.position + transform.forward, Quaternion.LookRotation(bulletDirection));

                    bullet.GetComponent<BulletMove>().SetDirection(bulletDirection);
                    bullet.GetComponent<BulletMove>().SetGunType(_gun);
                }
            }
            else if (_gun is Pistol || _gun is SMG)
            {
                Debug.Log("Pistol");

                GameObject bullet = Instantiate(_bullet.gameObject, transform.position + transform.forward, Quaternion.identity);

                bullet.GetComponent<BulletMove>().SetDirection(transform.forward);
                bullet.GetComponent<BulletMove>().SetGunType(_gun);
            }
            else
            {
                Debug.Log("Grenade");
                GameObject bullet = Instantiate(_grenade, transform.position + transform.forward, Quaternion.identity);

                bullet.GetComponent<BulletMove>().SetTargetPoint(_targetForGrenade);
                bullet.GetComponent<BulletMove>().SetGunType(_gun);
            }

            yield return new WaitForSeconds(1 / _gun.ShootingSpeed);
        }

        _isShootingInProgress = false;
    }
}
