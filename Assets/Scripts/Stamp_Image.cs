using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stamp_Image : MonoBehaviour
{

    private MeshRenderer _mRenderer;
    public Mesh _mMesh;
    Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        _mRenderer = GetComponent<MeshRenderer>();
        _mMesh = GetComponent<MeshFilter>().mesh;
        vertices = _mMesh.vertices;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeformLeftCorner(Vector3 newPosition)
    {
        vertices[0] = newPosition;
        _mMesh.vertices = vertices;
        _mMesh.RecalculateTangents();
        _mMesh.RecalculateBounds();

    }
}
