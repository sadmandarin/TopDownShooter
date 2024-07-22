using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _shootingSpeed;

    public float ShootingSpeed { get { return _shootingSpeed; } }
    public int Damage { get { return _damage; } }
}
