using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private int _speed = 7;
    private Vector3 _direction;
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

        //StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
            yield return null;

            if (GunType is Shotgun)
                Destroy(gameObject, 7 / _speed);

            else if (GunType is GrenadeLauncher)
                Destroy(gameObject, 7 / _speed);

            else
                Destroy(gameObject ,40 / _speed);
        }
    }
}
