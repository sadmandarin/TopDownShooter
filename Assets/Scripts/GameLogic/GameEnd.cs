using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private Player _player;
    [SerializeField] private GameObject _gameEndPanel;

    private void Start()
    {
        _player = GetComponent<Player>();
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnterDeadZone>())
        {
            Time.timeScale = 0;

            _gameEndPanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<BaseEnemy>())
        {
            if (_player.IsImortal)
                Destroy(other.gameObject);

            else
            {
                Time.timeScale = 0;

                _gameEndPanel.SetActive(true);
            }
        }
    }
}
