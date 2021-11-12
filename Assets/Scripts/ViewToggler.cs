using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewToggler : MonoBehaviour
{

    public GameObject scrapbook;
    public GameObject envelope;
    bool scrapEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        scrapbook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleScrap();
        }
    }

    void ToggleScrap()
    {
        if (scrapEnabled == true)
        {
            scrapbook.SetActive(false);
            envelope.SetActive(true);
            scrapEnabled = false;
        }
        else
        {
            scrapbook.SetActive(true);
            envelope.SetActive(false);
            scrapEnabled = true;
        }
    }
}
