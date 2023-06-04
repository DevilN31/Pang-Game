using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator _anim;

    private void OnEnable()
    {
        GameEvents.SetAnimationBool += SetBool;
        GameEvents.SetAnimationTrigger += SetTrigger;
    }

    private void OnDisable()
    {
        GameEvents.SetAnimationBool -= SetBool;
        GameEvents.SetAnimationTrigger -= SetTrigger;
    }

    private void Awake()
    {
        _anim= GetComponentInChildren<Animator>();
    }

   void SetBool(string boolName,bool value)
    {
        _anim.SetBool(boolName,value);
    }

    void SetTrigger(string triggerName) 
    {
        _anim.SetTrigger(triggerName);
    }
}
