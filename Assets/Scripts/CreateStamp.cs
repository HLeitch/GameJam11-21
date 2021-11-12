using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStamp : MonoBehaviour
{
    public GameObject[] backingStamps;
    public GameObject[] imageStamps;
    public Sprite[] backingSprites;
    public Sprite[] imageSprites;
    public GameObject stamp;
    Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint.x = 0;
        spawnPoint.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 newSpawn;
            newSpawn.x = spawnPoint.x + 2;
            newSpawn.y = spawnPoint.y;
            spawnPoint = newSpawn;
            SpawnStamp();
        }
    }

    public void SpawnStamp()
    {
        var newStamp = Instantiate(stamp, spawnPoint, Quaternion.identity);
    }
}
