using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGun : MonoBehaviour
{
    [SerializeField] private GunBase _gun;

    public GunBase Gun {  get { return _gun; } }
}
