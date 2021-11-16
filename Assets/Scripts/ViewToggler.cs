using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewToggler : MonoBehaviour
{

    public GameObject scrapbook;
    public GameObject envelope;
    bool scrapEnabled = false;
    ScrapbookFiller myScrapbook;
    // Start is called before the first frame update
    void Start()
    {
        scrapbook.transform.position = new Vector3(-20, scrapbook.transform.position.y, scrapbook.transform.position.z);
        myScrapbook = FindObjectOfType<ScrapbookFiller>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    ToggleScrap();
        //}
    }

    public void ToggleScrap()
    {
        if (scrapEnabled == true)
        {
            myScrapbook.scrapbookMiddle = false;
            scrapbook.transform.position = new Vector3(-20, scrapbook.transform.position.y, scrapbook.transform.position.z);
            envelope.transform.position = new Vector3(0, envelope.transform.position.y, envelope.transform.position.z);
            scrapEnabled = false;
        }
        else
        {
            myScrapbook.scrapbookMiddle = true;
            scrapbook.transform.position = new Vector3(0, scrapbook.transform.position.y, scrapbook.transform.position.z);
            envelope.transform.position = new Vector3(-20, envelope.transform.position.y, envelope.transform.position.z);
            scrapEnabled = true;
        }
    }
}
