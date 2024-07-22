using System.Collections;
using UnityEngine;

public class PlayersRotate : MonoBehaviour
{
    private float _rotationSpeed = 180f;
    private Coroutine _coroutine;

    public void Rotate(Vector3 targetPosition)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Rotation(targetPosition));
    }

    IEnumerator Rotation(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
