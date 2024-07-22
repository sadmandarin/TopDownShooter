using UnityEngine;

public class PickUpGunBonus : MonoBehaviour
{
    private PlayerShoot _playerShoot;
    private GameObject _currentGun;
    [SerializeField] private GameObject _gun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _playerShoot = other.gameObject.GetComponent<PlayerShoot>();

            _currentGun = Instantiate(_gun);


            _playerShoot.SetGunType(_currentGun.GetComponent<BonusGun>().Gun);
            Debug.Log("Succes");

            Destroy(gameObject);
        }
    }
}
