using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealth : MonoBehaviour
{

    [SerializeField]
    GameObject _SheepPrefab;
    [SerializeField]
    bool _IsAlive = true;

    private void Start()
    {
        _IsAlive= true;
    }

    public void Split()
    {
        if (_IsAlive)
        {
            _IsAlive = false;
            GameEvents.AddScore?.Invoke();

            if (transform.localScale.x <= 0.4f)
                Destroy(gameObject);
            else
            {

                GameObject sheep1 = Instantiate(_SheepPrefab, transform.position, Quaternion.identity);
                sheep1.transform.localScale *= 0.8f;
                sheep1.GetComponent<SheepMovementController>().SetDirection(-1);

                GameObject sheep2 = Instantiate(_SheepPrefab, transform.position, Quaternion.identity);
                sheep2.transform.localScale *= 0.8f;
                sheep2.GetComponent<SheepMovementController>().SetDirection(1);

                Destroy(this.gameObject);
            }
        }
    }
}
