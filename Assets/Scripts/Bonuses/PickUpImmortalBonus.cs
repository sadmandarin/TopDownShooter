using UnityEngine;

public class PickUpImmortalBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().SetImortal();

            Destroy(gameObject);
        }        
    }
}
