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
    public Vector3 _originalCornerPosition;
    public Transform corner;
    public Rigidbody _mRB;

    public float distanceToRotationRatio = 0.1f;
    private Vector3 _originalBoneRotation;

    public float minTimeAllowed = 1.5f;
    float timeAllowed = 3.0f;
    public float timeTaken = 0.0f;
    bool scored = false;

    ScrapbookFiller _mScrapbook;
    public CreateStamp cS;
    public GameObject timerObject;
    public GameObject timer;


    // Start is called before the first frame update
    void Start()
    {
        _originalCornerPosition = corner.position;

        _originalBoneRotation = _cornerBone.transform.rotation.eulerAngles;
        _mScrapbook = FindObjectOfType<ScrapbookFiller>();
        cS = FindObjectOfType<CreateStamp>();
        _mRB = GetComponentInChildren<Rigidbody>();
        timer = Instantiate(timerObject, new Vector2(transform.position.x - 4, transform.position.y - 4), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Moves the top left corner of the stamp
    public void MoveEdge(Vector3 newPosition)
    {
        //proposed new position is closer to center of screen than original point
        if ((_originalCornerPosition - Vector3.zero).magnitude > (newPosition - Vector3.zero).magnitude)
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
        if (scored == false)
        {
            float diffInDesiredAndCurrentZrotation = (DiffInDistance * distanceToRotationRatio);

            if (diffInDesiredAndCurrentZrotation < 0.3) { diffInDesiredAndCurrentZrotation = 0; }

            _cornerBone.transform.Rotate(0, 0, -diffInDesiredAndCurrentZrotation);

            timeTaken += Time.deltaTime;

            if (_cornerBone.transform.rotation.z < -0.6)
            {

                if (timeTaken > timeAllowed || timeTaken < minTimeAllowed)
                {
                    //fail
                    scored = true;

                    _mScrapbook.UpdateScore(0);
                    Debug.Log("Fail");
                    _mRB.useGravity = true;
                    StartCoroutine(Death());
                }
                else
                {
                    scored = true;
                    _mScrapbook.UpdateScore((int)((timeTaken / timeAllowed) * 100));

                    Debug.Log("Score: " + (int)((timeTaken / timeAllowed)));
                    _mRB.useGravity = true;
                    StartCoroutine(Death());
                }

            }
        }
    }

    IEnumerator Death()
    {
        Debug.Log("IN DEATH");
        _peelingCorner.active = false;
        Destroy(timer);
        yield return new WaitForSeconds(3.0f);
        //cS.SpawnStamp();
        Destroy(this.gameObject);


    }
}
