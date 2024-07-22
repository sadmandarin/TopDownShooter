using UnityEngine;

public class AddingExp : MonoBehaviour
{
    [SerializeField] private BaseEnemy _baseEnemy;
    private Score _score;

    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnDestroy()
    {
        _score.AddingScore(_baseEnemy.ExpForKill);
    }
}
