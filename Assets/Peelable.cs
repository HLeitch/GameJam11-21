using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peelable : MonoBehaviour
{
    BoxCollider2D _mCollider;
    Camera _mCamera;
    public Stamp _mStamp;

    // Start is called before the first frame update
    void Start()
    {

        _mCollider = GetComponent<BoxCollider2D>();
        _mCamera = Camera.main;
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
        Vector3 worldMousePos = _mCamera.ScreenToWorldPoint(Input.mousePosition);
        worldMousePos = new Vector3(worldMousePos.x, worldMousePos.y, 0f);
        _mCollider.gameObject.transform.position = worldMousePos;

        Debug.Log("NewPeelable position" + _mCollider.gameObject.transform.position.ToString());

        _mStamp.MoveEdge(worldMousePos);
    }


}
