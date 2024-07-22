using System.Collections;
using UnityEngine;

public class DestroyBonusIfNotPuckup : MonoBehaviour
{
    private int _destroyTime = 5;

    private void Start()
    {
        StartCoroutine(DestroyBonus());
    }

    private IEnumerator DestroyBonus()
    {
        yield return new WaitForSeconds(_destroyTime);

        Destroy(gameObject);
    }
}
