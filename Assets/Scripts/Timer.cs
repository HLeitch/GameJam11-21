using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    Vector2 thisPos;
    Stamp currentStamp;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        currentStamp = FindObjectOfType<Stamp>();
        thisPos.y = 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        thisPos.x = 1f - (currentStamp.timeTaken / 3);
        timer.transform.localScale = thisPos;

        if (currentStamp.timeTaken >= 3)
            Destroy(this.gameObject);
    }
}
