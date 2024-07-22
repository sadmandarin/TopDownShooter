using UnityEngine;

public class EnterSlowSpeedZone : MonoBehaviour
{
    private float _slowCoeff = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<PlayersMove>().ReduceSpeed(_slowCoeff);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<PlayersMove>().BackToNormalSpeed(_slowCoeff);
        }
    }
}
