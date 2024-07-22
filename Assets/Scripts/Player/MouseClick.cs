using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private PlayersRotate _playersRotate;
    private PlayerShoot _playerShoot;

    private void Start()
    {
        _playersRotate = GetComponent<PlayersRotate>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _playerShoot.IsShooting = true;

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            targetPosition.y = 0.5f;

            _playersRotate.Rotate(targetPosition);
        }            

        else if (Input.GetMouseButtonUp(0))
            _playerShoot.IsShooting = false;
    }
}
