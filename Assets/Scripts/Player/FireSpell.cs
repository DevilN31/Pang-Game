using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{

    [SerializeField]
    bool isStretching;
    [SerializeField]
    float _StretchSpeed = 2f;

    LineRenderer _line;
    EdgeCollider2D _edgeCollider;


    void Start()
    {
        _line= GetComponent<LineRenderer>();
        _edgeCollider= GetComponent<EdgeCollider2D>();

        isStretching = true;

        StartCoroutine(Stretch());
    }

    
    IEnumerator Stretch()
    {
        while(isStretching)
        {
            _line.SetPosition(1, _line.GetPosition(1) + (Vector3.up * _StretchSpeed * Time.deltaTime));
            SetEdgeCollider();
            yield return null;
        }
    }
   

    void SetEdgeCollider()
    {
        List<Vector2> edges = new List<Vector2>();

        for(int i=0; i<_line.positionCount;i++) 
        {
            Vector3 point = _line.GetPosition(i);
            edges.Add(point);
        }

        _edgeCollider.SetPoints(edges);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            return;

        if(collision.gameObject.TryGetComponent<SheepHealth>(out SheepHealth sheep))
        {
            sheep.Split();
        }

        Destroy(gameObject);
    }
}
