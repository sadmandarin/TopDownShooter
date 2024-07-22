using System.Collections;
using UnityEditor.U2D;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(BoxCollider))]
public class PlayersMove : MonoBehaviour
{
    private string _horizontalInput = "Horizontal";
    private string _verticalInput = "Vertical";
    private Rigidbody _rigidBody;
    private float _speed = 4f;
    private int _speedBonusTime = 10;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontalInput);
        float verticalInput = Input.GetAxis(_verticalInput);

        Vector3 offset = new(horizontalInput, 0, verticalInput);

        _rigidBody.MovePosition(_rigidBody.position + _speed * offset * Time.deltaTime);
    }

    public void ReduceSpeed(float reduceSpeedScaler)
    {
        _speed *= reduceSpeedScaler;
    }

    public void BackToNormalSpeed(float reduceSpeedScaler)
    {
        _speed /= reduceSpeedScaler;
    }

    public void SpeedUpBonus(float speedScaler)
    {
        _speed *= speedScaler;

        StartCoroutine(DisableSpeedBonus(speedScaler));
    }

    private IEnumerator DisableSpeedBonus(float speedScaler)
    {
        yield return new WaitForSeconds(_speedBonusTime);

        _speed /= speedScaler;
    }
}
