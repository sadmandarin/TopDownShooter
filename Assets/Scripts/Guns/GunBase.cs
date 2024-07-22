using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _shootingSpeed;

    public float ShootingSpeed { get { return _shootingSpeed; } }
    public int Damage { get { return _damage; } }
}
