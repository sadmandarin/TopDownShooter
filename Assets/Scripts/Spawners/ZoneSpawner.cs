using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _deadZone;
    [SerializeField] private GameObject _slowSpeedZone;
    [SerializeField] private Transform _playerPosition;

    private int _deadZoneRadius = 1;
    private int _slowSpeedZoneRadius = 3;
    private int _deadZoneCount = 2;
    private int _slowSpeedZoneCount = 3;
    private float _minDistance = 3f;
    private Vector2 _mapSize = new(40, 30);

    private List<Vector2> spawnedPositions = new List<Vector2>();

    private void Start()
    {
        SpawnDeadZone();
        SpawnSlowZone();
    }

    void SpawnDeadZone()
    {
        for (int i = 0; i < _deadZoneCount; i++)
        {
            Vector2 position = GetRandomPosition(_deadZoneRadius);

            if (position != Vector2.zero)
            {
                Instantiate(_deadZone, new Vector3(position.x, 0, position.y), Quaternion.identity);
                spawnedPositions.Add(position);
            }
        }
    }

    void SpawnSlowZone()
    {
        for (int i = 0; i < _slowSpeedZoneCount; i++)
        {
            Vector2 position = GetRandomPosition(_slowSpeedZoneRadius);

            if (position != Vector2.zero)
            {
                Instantiate(_slowSpeedZone, new Vector3(position.x, 0, position.y), Quaternion.identity);
                spawnedPositions.Add(position);
            }
        }
    }

    private Vector2 GetRandomPosition(int zoneRadius)
    {
        float minX = -_mapSize.x /2 + (_minDistance + zoneRadius);
        float maxX = _mapSize.x / 2 - (_minDistance + zoneRadius);
        float minY = -_mapSize.y / 2 + (_minDistance + zoneRadius);
        float maxY = _mapSize.y / 2 - (_minDistance + zoneRadius);

        for (int attempt = 0; attempt < 100; attempt++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            //float x = Random.Range(_minDistance + zoneRadius, _mapSize.x - _minDistance - zoneRadius);
            //float y = Random.Range(_minDistance + zoneRadius, _mapSize.y - _minDistance - zoneRadius);

            Vector2 randomPosition = new(x, y);

            if (IsValidPosition(randomPosition, zoneRadius))
            {
                return randomPosition;
            }
        }
        return Vector2.zero;
    }

    private bool IsValidPosition(Vector2 position, float radius)
    {
        foreach (Vector2 spawnedPosition in spawnedPositions)
        {
            if (Vector2.Distance(position, spawnedPosition) < _minDistance + 2 * radius)
            {
                return false;
            }
        }

        Vector2 playerPosition2D = new Vector2(_playerPosition.position.x, _playerPosition.position.z);
        if (Vector2.Distance(position, playerPosition2D) < _minDistance + radius)
        {
            return false;
        }

        return true;
    }
}
