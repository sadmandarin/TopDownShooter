using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isImortal;
    private float _bonusTime = 10;

    public bool IsImortal { get { return _isImortal; } private set { _isImortal = value; } }

    public void SetImortal()
    {
        _isImortal = true;

        StartCoroutine(ImmortalOff());
    }

    private IEnumerator ImmortalOff()
    {
        yield return new WaitForSeconds(_bonusTime);

        _isImortal = false;
    }
}
