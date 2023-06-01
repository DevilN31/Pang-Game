using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    bool _IsAlive;
    [SerializeField]
    List<Component> _ComponentsToDisable;

    Animator _anim;

    public bool IsAlive { get { return _IsAlive; } }

    void Start()
    {
        _IsAlive = true;
        _anim = GetComponentInChildren<Animator>();
    }

    
    public void PlayerDeath()
    {
        _IsAlive = false;
        _anim.SetTrigger("Death");

        foreach(var comp in _ComponentsToDisable) 
        {
            Destroy(comp);
        }
    }
}
