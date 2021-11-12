using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    public Sprite _face;
    public Sprite _Background;

    public Peelable _peelingCorner;
    Stamp_Image _Image;
    
    // Start is called before the first frame update
    void Start()
    {
        _Image = GetComponentInChildren<Stamp_Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Moves the top left corner of the stamp
    public void MoveEdge(Vector3 newPosition)
    {
        _Image.DeformLeftCorner(newPosition);
    }    
}
