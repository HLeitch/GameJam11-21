using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peelable : MonoBehaviour
{
    BoxCollider2D _mCollider;
    Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        _mCollider = GetComponent<BoxCollider2D>();
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on peelable");
    }
    private void OnMouseDrag()
    {
        //Move collider to mouse position
        Vector3 worldMousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);
        _mCollider.gameObject.transform.position = worldMousePos;
        Debug.Log("NewPeelable position" + worldMousePos.ToString());
    }


}
