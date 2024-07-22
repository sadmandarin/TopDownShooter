using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefab;


    private Camera _mainCamera;
    private Vector2 _fieldSize = new Vector2(40, 30);

    private float _spawnDistanceFromCamera = 1.0f;
    private float _spawnInterval = 2f;
    private float _reduceTime = 10f;

    void Start()
    {
        _mainCamera = Camera.main;

        StartCoroutine(SpawnEnemy());
        StartCoroutine(ReduceSpawnInterval());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);

            Camera mainCamera = Camera.main;
            Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
            Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

            float minX = -_fieldSize.x / 2;
            float maxX = _fieldSize.x / 2;
            float minZ = -_fieldSize.y / 2;
            float maxZ = _fieldSize.y / 2;

            float cameraMinX = bottomLeft.x;
            float cameraMaxX = topRight.x;
            float cameraMinZ = bottomLeft.z;
            float cameraMaxZ = topRight.z;

            // Расстояние до границы мира от края камеры
            float minDistance = 3.0f;

            // Проверка доступных сторон
            bool canSpawnLeft = (cameraMinX - minX) > minDistance;
            bool canSpawnRight = (maxX - cameraMaxX) > minDistance;
            bool canSpawnTop = (maxZ - cameraMaxZ) > minDistance;
            bool canSpawnBottom = (cameraMinZ - minZ) > minDistance;

            // Выбор стороны для спавна
            Vector3 spawnPosition = Vector3.zero;
            if (canSpawnLeft && (canSpawnRight || canSpawnTop || canSpawnBottom))
            {
                // Выбираем случайную сторону для спавна
                bool spawnLeftOrRight = Random.value < 0.5f;

                if (spawnLeftOrRight)
                {
                    // Спавн по горизонтали
                    spawnPosition.x = Random.Range(cameraMinX - minDistance, cameraMinX - minDistance);
                    spawnPosition.z = Random.Range(minZ, maxZ);
                }
                else
                {
                    // Спавн по вертикали
                    spawnPosition.x = Random.Range(minX, maxX);
                    spawnPosition.z = Random.Range(cameraMaxZ + minDistance, cameraMaxZ + minDistance);
                }
            }
            else if (canSpawnTop && canSpawnBottom)
            {
                // Спавн по вертикали
                spawnPosition.x = Random.Range(cameraMinX, cameraMaxX);
                spawnPosition.z = Random.Range(cameraMaxZ + minDistance, cameraMaxZ + minDistance);
            }
            else if (canSpawnBottom && canSpawnTop)
            {
                // Спавн по горизонтали
                spawnPosition.x = Random.Range(cameraMinX - minDistance, cameraMinX - minDistance);
                spawnPosition.z = Random.Range(minZ, maxZ);
            }

            float randomValue = Random.Range(0, maxInclusive: 1);

            if (randomValue < _enemyPrefab[0].GetComponent<DefaultEnemy>().SpawnProbability)
                Instantiate(_enemyPrefab[0], spawnPosition, Quaternion.identity);
            else if (randomValue > 1 - _enemyPrefab[2].GetComponent<HeavyEnemy>().SpawnProbability)
                Instantiate(_enemyPrefab[2], spawnPosition, Quaternion.identity);
            else
                Instantiate(_enemyPrefab[1], spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator ReduceSpawnInterval()
    {
        while (_spawnInterval > 0.5f)
        {
            yield return new WaitForSeconds(_reduceTime);

            _spawnInterval -= 0.1f;

            if (_spawnInterval == 0.5f)
                yield break;
        }
    }
}
