using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateAnim : MonoBehaviour
{
    
    public Animator anim;
    public bool _val = true;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("UpdateVal", 0, 5f);
    }




    void UpdateVal()
    {

        anim.SetBool("isRunning", _val);
        _val = !_val;
    }
}
