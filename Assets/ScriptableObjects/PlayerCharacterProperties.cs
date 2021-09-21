using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Type", menuName = "Player Type")]
public class PlayerCharacterProperties : ScriptableObject
{
    [SerializeField]
    private float _zAxisSpeed = 0,_checkSphereRadius=0, _playerDragValue = 0;

    public float zAxisSpeed
    {
        get
        {
            return _zAxisSpeed;
        }
        set
        {
            _zAxisSpeed = value;
        }
    }
    public float checkSphereRadius => _checkSphereRadius;
    public float playerDragValue => _playerDragValue;
}



