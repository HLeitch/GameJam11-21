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
    public  Vector3 _originalCornerPosition;
    public Transform corner;

    public float distanceToRotationRatio = 0.1f;
    private Vector3 _originalBoneRotation;
    // Start is called before the first frame update
    void Start()
    {
        _originalCornerPosition = corner.position;

        _originalBoneRotation = _cornerBone.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Moves the top left corner of the stamp
    public void MoveEdge(Vector3 newPosition)
    {
        //proposed new position is closer to center of screen than original point
        if((_originalCornerPosition-Vector3.zero).magnitude > (newPosition-Vector3.zero).magnitude)
                {

            float diffToOriginalDistance = (_originalCornerPosition - Vector3.zero).magnitude - (newPosition - Vector3.zero).magnitude;
            DeformRightCorner(diffToOriginalDistance);





        }
        //gameObject.transform.position = newPosition;
    }

    public void DeformRightCorner(Vector3 newPosition)
    {

        _cornerBone.transform.position = newPosition;




    }
    public void DeformRightCorner(float DiffInDistance)
    {
        float diffInDesiredAndCurrentZrotation = (DiffInDistance * distanceToRotationRatio);

        if(diffInDesiredAndCurrentZrotation < 0.3) { diffInDesiredAndCurrentZrotation = 0; }

        _cornerBone.transform.Rotate(0, 0, -diffInDesiredAndCurrentZrotation);
    }
}
