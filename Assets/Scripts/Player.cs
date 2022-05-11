using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 10;

    public int Health { get { return _health; }
        set {
            if (_health == 0)
                return;
            _health = value;
        } 
    }   

    public void Hit(int damage)
    {
        if (damage <= 0) return;
        if (_health == 0) return;
        _health -= damage;
    }
}
