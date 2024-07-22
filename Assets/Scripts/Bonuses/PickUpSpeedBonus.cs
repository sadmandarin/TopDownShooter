using UnityEngine;

public class PickUpSpeedBonus : MonoBehaviour
{
    private float _speedScaler = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayersMove>())
        {
            other.gameObject.GetComponent<PlayersMove>().SpeedUpBonus(_speedScaler);

            Destroy(gameObject);
        }
    }
}
