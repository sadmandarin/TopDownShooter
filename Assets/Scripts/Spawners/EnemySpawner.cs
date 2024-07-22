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

            Vector3 cameraPos = _mainCamera.transform.position;

            float cameraHeight = 2f * _mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * _mainCamera.aspect;

            float minX = -_fieldSize.x / 2;
            float maxX = _fieldSize.x / 2;
            float minZ = -_fieldSize.y / 2;
            float maxZ = _fieldSize.y / 2;

            float spawnX, spawnZ;

            if (Random.value < 0.5f)
            {
                spawnX = (Random.value < 0.5f) ? cameraPos.x - cameraWidth / 2 - _spawnDistanceFromCamera : cameraPos.x + cameraWidth / 2 + _spawnDistanceFromCamera;
                spawnZ = Random.Range(cameraPos.z - cameraHeight / 2, cameraPos.z + cameraHeight / 2);
            }
            else
            {
                spawnX = Random.Range(cameraPos.x - cameraWidth / 2, cameraPos.x + cameraWidth / 2);
                spawnZ = (Random.value < 0.5f) ? cameraPos.z - cameraHeight / 2 - _spawnDistanceFromCamera : cameraPos.z + cameraHeight / 2 + _spawnDistanceFromCamera;
            }

            spawnX = Mathf.Clamp(spawnX, minX, maxX);
            spawnZ = Mathf.Clamp(spawnZ, minZ, maxZ);

            Vector3 spawnPosition = new(spawnX, 0, spawnZ);

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
