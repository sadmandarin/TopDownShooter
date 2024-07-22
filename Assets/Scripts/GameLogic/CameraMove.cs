using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Vector3 _offset = new Vector3(0, 2, 0);

    private void LateUpdate()
    {
        if (_playerTransform != null)
        {
            transform.position = _playerTransform.position + _offset;
        }
    }
}
