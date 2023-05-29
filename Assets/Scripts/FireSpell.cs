using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{

    LineRenderer Line;
    [SerializeField]
    bool isStretching;
    [SerializeField]
    float _StretchSpeed = 2f;

    void Start()
    {
        Line= GetComponent<LineRenderer>();
        isStretching = true;

        StartCoroutine(Stretch());
    }

    
    IEnumerator Stretch()
    {
        while(isStretching)
        {
            Line.SetPosition(1, Line.GetPosition(1) + (Vector3.up * _StretchSpeed * Time.deltaTime));
            GenerateMeshCollider();
            yield return null;
        }
    }

    public void GenerateMeshCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();

        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }


        Mesh mesh = new Mesh();
        Line.BakeMesh(mesh, true);

        // if you need collisions on both sides of the line, simply duplicate & flip facing the other direction!
        // This can be optimized to improve performance ;)
        int[] meshIndices = mesh.GetIndices(0);
        int[] newIndices = new int[meshIndices.Length * 2];

        int j = meshIndices.Length - 1;
        for (int i = 0; i < meshIndices.Length; i++)
        {
            newIndices[i] = meshIndices[i];
            newIndices[meshIndices.Length + i] = meshIndices[j];
        }
        mesh.SetIndices(newIndices, MeshTopology.Triangles, 0);

        collider.sharedMesh = mesh;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
