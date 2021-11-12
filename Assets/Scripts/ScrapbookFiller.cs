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
    CreateStamp mommyStamp;
    // Start is called before the first frame update
    void Start()
    {
        mommyStamp = FindObjectOfType<CreateStamp>();
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
                    Debug.Log("Skipped");
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
                    Debug.Log("Skipped");
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
        int randyRotate = Random.Range(-10, 11);
        back = Instantiate(mommyStamp.backingStamps[a], stampLocations[currentStamp], Quaternion.Euler(0,0,randyRotate));
        back.transform.localScale = new Vector2(0.6f, 0.6f);
        back.transform.parent = gameObject.transform;

        front = Instantiate(mommyStamp.imageStamps[b], stampLocations[currentStamp], Quaternion.Euler(0, 0, randyRotate));
        front.transform.localScale = new Vector2(0.6f, 0.6f);
        front.transform.parent = gameObject.transform;
    }

    public void UpdateScore(int score)
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
}
