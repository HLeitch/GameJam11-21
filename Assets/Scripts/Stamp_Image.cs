using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stamp_Image : MonoBehaviour
{
    public Transform _front;
    public Transform _mask;
    public Transform _GradOutter;
    public Vector3 _Pos = new Vector3(-240.0f, -470.0f, 0.0f)*0.01f;

    // Start is called before the first frame update
    void Start()
    {
        _mRenderer = GetComponent<MeshRenderer>();
        _mMesh = GetComponent<MeshFilter>().mesh;
        vertices = _mCloth.vertices;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeformLeftCorner(Vector3 newPosition)
    {
        transform.position = newPosition;
        transform.eulerAngles = Vector3.zero;

        Vector3 pos = _front.localPosition;
        float theta = Mathf.Atan2(pos.y,pos.x) * 180.0f / Mathf.PI;

        if (theta <= 0.0f || theta >= 90.0f) return;

        float deg = -(90.0f - theta) * 2.0f;
        _front.eulerAngles = new Vector3(0.0f, 0.0f, deg);

        _mask.position = (transform.position + _Front.position) * 0.5f;
        _mask.eulerAngles = new Vector3(0.0f, 0.0f, deg * 0.5f);

        _GradOutter.position = _mask.position;
        _GradOutter.eulerAngles = new Vector3(0.0f, 0.0f, deg * 0.5f + 90.0f);

        transform.position = _Pos;
        transform.eulerAngles = Vector3.zero;


     //Modified from https://gnupart.tistory.com/entry/Unity3D-Simple-Page-Curl-Effect [trapung ]



    }
}
