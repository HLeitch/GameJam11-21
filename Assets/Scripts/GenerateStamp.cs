using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStamp : MonoBehaviour
{
    CreateStamp mommyStamp;
    GameObject back;
    GameObject front;
    ScrapbookFiller myScrapbook;
    SpriteCombine myCombiner;
    Sprite mergedImage;
    public Material newMat;
    public GameObject PhysicalStampPrefab;


    // Start is called before the first frame update
    void Start()
    {
        mommyStamp = FindObjectOfType<CreateStamp>();
        myScrapbook = FindObjectOfType<ScrapbookFiller>();
        myCombiner = FindObjectOfType<SpriteCombine>();

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

        mergedImage = myCombiner.Merge(mommyStamp.backingSprites[randy1], mommyStamp.imageSprites[randy2]);
        newMat.SetTexture("_MainTex",mergedImage.texture);

        GameObject newg = Instantiate(PhysicalStampPrefab,this.transform);
        newg.transform.position = new Vector3(4f, 1f, -2.5f);

        myScrapbook.AddStamp(randy1, randy2);
    }
}
