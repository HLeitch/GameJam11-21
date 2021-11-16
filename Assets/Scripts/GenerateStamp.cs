using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStamp : MonoBehaviour
{
    //CreateStamp mommyStamp;
    GameObject back;
    GameObject front;
    ScrapbookFiller myScrapbook;
    SpriteCombine myCombiner;
    Sprite mergedImage;
    public Material newMat;
    public GameObject PhysicalStampPrefab;
    public GameObject[] backingStamps;
    public GameObject[] imageStamps;
    public Sprite[] backingSprites;
    public Sprite[] imageSprites;
    public GameObject buttonHolder;


    // Start is called before the first frame update
    void Start()
    {
        //mommyStamp = FindObjectOfType<CreateStamp>();
        myScrapbook = FindObjectOfType<ScrapbookFiller>();
        myCombiner = FindObjectOfType<SpriteCombine>();

        //GenerateImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateImages()
    {
        int randy1 = Random.Range(0, 10);
        int randy2 = Random.Range(0, 10);

        mergedImage = myCombiner.Merge(backingSprites[randy1], imageSprites[randy2]);
        newMat.SetTexture("_MainTex",mergedImage.texture);

        
        GameObject newg = Instantiate(PhysicalStampPrefab,new Vector3(4.5f, 1f, -2.5f), Quaternion.identity);
        newg.transform.parent = this.gameObject.transform;
        //newg.transform.position = new Vector3(4f, 1f, -2.5f);

        myScrapbook.AddStamp(randy1, randy2);
    }

    public void InPeel()
    {
        buttonHolder.SetActive(false);
    }

    public void OutPeel()
    {
        buttonHolder.SetActive(true);
    }
}
