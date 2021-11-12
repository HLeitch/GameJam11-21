using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    public Sprite _face;
    public Sprite _Background;

    public Peelable _peelingCorner;
    Stamp_Image _Image;
    private SpriteRenderer _mSpriteRenderer;
    public GameObject _cornerBone;
    Vector3 originalCornerPosition;

    // Start is called before the first frame update
    void Start()
    {
        _mSpriteRenderer = GetComponent<SpriteRenderer>();
        _Image = GetComponentInChildren<Stamp_Image>();
        _mSpriteRenderer.sprite = _Background;
        originalCornerPosition = _cornerBone.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Moves the top left corner of the stamp
    public void MoveEdge(Vector3 newPosition)
    {
        //closer to center of screen than can mesh
        if((originalCornerPosition-Vector3.zero).magnitude > (newPosition-Vector3.zero).magnitude)
                {
            DeformRightCorner(newPosition);
        }
        //gameObject.transform.position = newPosition;
    }

    public void DeformRightCorner(Vector3 newPosition)
    {

        _cornerBone.transform.position = newPosition;




    }
}
