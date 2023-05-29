using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _SpellPrefab;

    Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            _anim.SetTrigger("Attack");
            SpawnSpellPrefab();
        }
    }

    public void SpawnSpellPrefab()
    {
        Instantiate(_SpellPrefab,transform.position,Quaternion.identity);
    }
}
