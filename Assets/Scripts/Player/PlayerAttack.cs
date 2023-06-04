using Nati.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _SpellPrefab;
    [SerializeField]
    float _AttackSpeed = 1.5f;
    [SerializeField]
    AudioClip _AttackSound;

    float counter;

    private void OnEnable()
    {
        TouchInputController.OnPressed += SpawnSpellPrefab;
    }
    private void OnDisable()
    {
        TouchInputController.OnPressed -= SpawnSpellPrefab;

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
    }

    public void SpawnSpellPrefab(ClickableButtonType clickableButtonType)
    {
        if (clickableButtonType == ClickableButtonType.Fire)
        {
            if (counter >= _AttackSpeed)
            {
                counter = 0;
                GameEvents.SetAnimationTrigger?.Invoke("Attack");
                GameEvents.PlaySFX?.Invoke(_AttackSound);
                Instantiate(_SpellPrefab, transform.position, Quaternion.identity);
            }
            else
                return;
        }
    }
}
