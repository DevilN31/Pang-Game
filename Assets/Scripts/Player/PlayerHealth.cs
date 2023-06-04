using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    bool _IsAlive;
    [SerializeField]
    List<Component> _ComponentsToDisable;


    public bool IsAlive { get { return _IsAlive; } }

    void Start()
    {
        _IsAlive = true;
    }

    
    public void PlayerDeath()
    {
        _IsAlive = false;
        GameEvents.SetAnimationTrigger?.Invoke("Death");
        GameEvents.PlayerDeath?.Invoke();

        foreach(var comp in _ComponentsToDisable) 
        {
            Destroy(comp);
        }
    }
}
