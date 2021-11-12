using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStamp : MonoBehaviour
{
    CreateStamp mommyStamp;
    GameObject back;
    GameObject front;
    ScrapbookFiller myScrapbook;
    // Start is called before the first frame update
    void Start()
    {
        mommyStamp = FindObjectOfType<CreateStamp>();
        myScrapbook = FindObjectOfType<ScrapbookFiller>();
        GenerateImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateImages()
    {
        int randy1 = Random.Range(0, 10);
        int randy2 = Random.Range(0, 10);

        back = Instantiate(mommyStamp.backingStamps[randy1], transform.position, Quaternion.identity);
        back.transform.parent = gameObject.transform;

        front = Instantiate(mommyStamp.imageStamps[randy2], transform.position, Quaternion.identity);
        front.transform.parent = gameObject.transform;
    }
}
