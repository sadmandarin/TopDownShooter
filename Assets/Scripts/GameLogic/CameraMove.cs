using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Vector2 mapMinBounds = new(-20, -15);
    private Vector2 mapMaxBounds = new(20, 15);
    private int _cameraZOffset = 2;
    private float _cameraHalfHeight;
    private float _cameraHalfWidth;

    void Start()
    {
        Camera camera = Camera.main;
        _cameraHalfHeight = camera.orthographicSize;
        _cameraHalfWidth = _cameraHalfHeight * camera.aspect;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _playerTransform.position;

        float clampedX = Mathf.Clamp(targetPosition.x, mapMinBounds.x + _cameraHalfWidth, mapMaxBounds.x - _cameraHalfWidth);
        float clampedY = Mathf.Clamp(targetPosition.z, mapMinBounds.y + _cameraHalfHeight, mapMaxBounds.y - _cameraHalfHeight);

        Vector3 cameraPosition = new Vector3(clampedX, targetPosition.y, clampedY) + new Vector3(0, _cameraZOffset, 0);

        transform.position = cameraPosition;
    }
}
