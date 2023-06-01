using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _SpellPrefab;
    [SerializeField]
    float _AttackSpeed = 1.5f;

    Animator _anim;
    float counter;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SpawnSpellPrefab();
        }
    }

    public void SpawnSpellPrefab()
    {
        if (counter >= _AttackSpeed)
        {
            counter = 0;
            _anim.SetTrigger("Attack");
            Instantiate(_SpellPrefab, transform.position, Quaternion.identity);
        }
        else
            return;
    }
}
