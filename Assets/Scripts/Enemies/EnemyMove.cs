using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void OnEnable()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public IEnumerator MoveEnemy(int speed)
    {
        while (Vector3.Distance(transform.position, _player.position) > 0.1)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.position, speed * Time.deltaTime);

            yield return null;
        }
    }
}
