using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _guns;
    [SerializeField] private List<GameObject> _bonuses;

    private Coroutine _bonusSpawn;
    private Coroutine _gunSpawn;
    private int _bonusSpawnTimer = 27;
    private int _gunSpawnTimer = 10;
    private Vector2 _fieldSize = new Vector2(40, 30);
    private Camera _mainCamera;

    private void Start()
    {
        _bonusSpawn = StartCoroutine(BonusSpawn());
        _gunSpawn = StartCoroutine(GunSpawn());
    }

    private IEnumerator BonusSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_bonusSpawnTimer);

            Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

            float minX = Mathf.Max(bottomLeft.x, -_fieldSize.x / 2);
            float maxX = Mathf.Min(topRight.x, _fieldSize.x / 2);
            float minZ = Mathf.Max(bottomLeft.z, -_fieldSize.y / 2);
            float maxZ = Mathf.Min(topRight.z, _fieldSize.y / 2);

            float spawnX, spawnZ;

            spawnX = Random.Range(minX, maxX);
            spawnZ = Random.Range(minZ, maxZ);

            Vector3 spawnPos = new(spawnX, 0.5f, spawnZ);

            float random = Random.Range(0, maxInclusive: 1);

            if (random <= 0.5)
                Instantiate(_bonuses[0], spawnPos, Quaternion.identity);
            else
                Instantiate(_bonuses[1], spawnPos, Quaternion.identity);
        }
    }

    private IEnumerator GunSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_gunSpawnTimer);

            Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

            float minX = Mathf.Max(bottomLeft.x, -_fieldSize.x / 2);
            float maxX = Mathf.Min(topRight.x, _fieldSize.x / 2);
            float minZ = Mathf.Max(bottomLeft.z, -_fieldSize.y / 2);
            float maxZ = Mathf.Min(topRight.z, _fieldSize.y / 2);

            float spawnX, spawnZ;

            spawnX = Random.Range(minX, maxX);
            spawnZ = Random.Range(minZ, maxZ);

            Vector3 spawnPos = new(spawnX, 0.5f, spawnZ);

            float random = Random.Range(0, maxInclusive: 1);

            if (random < 0.25)
                Instantiate(_guns[0], spawnPos, Quaternion.identity);
            else if(random >= 0.75)
                Instantiate(_guns[1], spawnPos, Quaternion.identity);
            else if (random >= 0.5 && random < 0.75)
                Instantiate(_guns[2], spawnPos, Quaternion.identity);
            else if(random >= 0.25 && random < 0.5)
                Instantiate(_guns[3], spawnPos, Quaternion.identity);
        }
    }
}
