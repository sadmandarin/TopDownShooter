using UnityEngine;

public class EnterDeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(other.gameObject);
        }
    }
}
