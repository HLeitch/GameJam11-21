using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapbookFiller : MonoBehaviour
{
    int currentStamp;
    public Vector2[] stampLocations;
    public Vector2[] textLocations;
    GameObject back;
    GameObject front;
    public Text newText;
    GenerateStamp envelope;
    public bool scrapbookMiddle = false;
    // Start is called before the first frame update
    void Start()
    {
        envelope = FindObjectOfType<GenerateStamp>();
        SetLocations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLocations()
    {
        stampLocations = new Vector2[38];
        textLocations = new Vector2[38];
        int lastLocation = 0;
        for (int y = 0; y <= 3; y++)
        {
            for (int x = 0; x <= 4; x++)
            {
                if (x == 4 && y == 0)
                {
                }
                else
                {
                    stampLocations[lastLocation].x = -7.21f + (1.388f * x);
                    stampLocations[lastLocation].y = 3.5f - (2.0f * y);

                    textLocations[lastLocation].x = -7.21f + (1.388f * x);
                    textLocations[lastLocation].y = (3.25f - (2.0f * y)) - 0.74f;

                    lastLocation++;
                }
            }

        }

        for (int y = 0; y <= 3; y++)
        {
            for (int x = 0; x <= 4; x++)
            {
                if (x == 0 && y == 0)
                {
                }
                else
                {
                    stampLocations[lastLocation].x = 1.62f + (1.388f * x);
                    stampLocations[lastLocation].y = 3.5f - (2.0f * y);

                    textLocations[lastLocation].x = 1.62f + (1.388f * x);
                    textLocations[lastLocation].y = (3.25f - (2.0f * y)) - 0.74f;

                    lastLocation++;
                }
            }

        }
    }

    public void AddStamp(int a, int b)
    {
        if (scrapbookMiddle == false)
        {
            Debug.Log("Scrapbook is off to the side!" + this.transform.localPosition.x);
            Vector2 tempTransform = stampLocations[currentStamp];
            tempTransform.x = stampLocations[currentStamp].x - 20;
            tempTransform.y = stampLocations[currentStamp].y;
            stampLocations[currentStamp] = tempTransform;
            int randyRotate = Random.Range(-10, 11);
            back = Instantiate(envelope.backingStamps[a], tempTransform, Quaternion.Euler(0, 0, randyRotate));
            back.transform.localScale = new Vector2(0.6f, 0.6f);
            back.transform.parent = gameObject.transform;

            front = Instantiate(envelope.imageStamps[b], tempTransform, Quaternion.Euler(0, 0, randyRotate));
            front.transform.localScale = new Vector2(0.6f, 0.6f);
            front.transform.parent = gameObject.transform;
        }
        else
        {
            Debug.Log("Scrapbook is in the middle!" + this.transform.localPosition.x);
            int randyRotate = Random.Range(-10, 11);
            back = Instantiate(envelope.backingStamps[a], stampLocations[currentStamp], Quaternion.Euler(0, 0, randyRotate));
            back.transform.localScale = new Vector2(0.6f, 0.6f);
            back.transform.parent = gameObject.transform;

            front = Instantiate(envelope.imageStamps[b], stampLocations[currentStamp], Quaternion.Euler(0, 0, randyRotate));
            front.transform.localScale = new Vector2(0.6f, 0.6f);
            front.transform.parent = gameObject.transform;
        }
    }

    public void UpdateScore(int score)
    {
        if (scrapbookMiddle == true)
        {
            newText = Instantiate(newText, textLocations[currentStamp], Quaternion.identity);
            newText.text = score.ToString();
            newText.transform.parent = gameObject.transform;
            if (score >= 75)
                newText.color = new Color32(0, 63, 0, 255);
            else if (score < 75 && score >= 50)
                newText.color = new Color32(207, 169, 0, 255);
            else if (score < 50)
                newText.color = Color.red;
            currentStamp++;
        }
        else
        {
            Vector2 tempTransform = textLocations[currentStamp];
            tempTransform.x = textLocations[currentStamp].x - 20;
            tempTransform.y = textLocations[currentStamp].y;
            textLocations[currentStamp] = tempTransform;
            newText = Instantiate(newText, textLocations[currentStamp], Quaternion.identity);
            newText.text = score.ToString();
            newText.transform.parent = gameObject.transform;
            if (score >= 75)
                newText.color = new Color32(0, 63, 0, 255);
            else if (score < 75 && score >= 50)
                newText.color = new Color32(207, 169, 0, 255);
            else if (score < 50)
                newText.color = Color.red;
            currentStamp++;
            envelope.OutPeel();
        }
    }
}
