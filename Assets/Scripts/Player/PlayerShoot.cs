using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private BulletMove _bullet;

    public bool IsShooting;
    [SerializeField] private GunBase _gun;

    private Coroutine _coroutine;
    private float _spreadAngle = 10f;
    private int _bulletCount = 5;
    private bool _isAvaiableShooting = true;

    public GunBase GunType { get { return _gun; } }

    private void Update()
    {
        if (_gun != null)
        {
            if (IsShooting && _coroutine == null && _isAvaiableShooting)
                _coroutine = StartCoroutine(ShootBullet());
            else if (_coroutine != null && IsShooting == false)
            {
                
                StopCoroutine(_coroutine);
                _coroutine = null;
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

    private IEnumerator ShootBullet()
    {
        while (true)
        {
            if (_gun is Shotgun)
            {
                float angleStep = _spreadAngle / (_bulletCount -1);
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

                yield return new WaitForSeconds(1 / _gun.ShootingSpeed);
            }

            else if (_gun is Pistol || _gun is SMG)
            {
                GameObject bullet = Instantiate(_bullet.gameObject, transform.position + transform.forward, Quaternion.identity);
                
                bullet.GetComponent<BulletMove>().SetDirection(transform.forward);
                bullet.GetComponent<BulletMove>().SetGunType(_gun);

                yield return new WaitForSeconds(1 / _gun.ShootingSpeed);
            }
            else
            {
                GameObject bullet = Instantiate(_bullet.gameObject, transform.position + transform.forward, Quaternion.identity);

                bullet.GetComponent<BulletMove>().SetDirection(transform.forward);
                bullet.GetComponent<BulletMove>().SetGunType(_gun);

                yield return new WaitForSeconds(1 / _gun.ShootingSpeed);
            }
        }
    }

    
}
