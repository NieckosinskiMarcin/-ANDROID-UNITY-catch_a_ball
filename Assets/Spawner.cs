using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> toSpawn = new List<GameObject>();
    private List<Vector2> positions = new List<Vector2>();
    private Vector2 first = new Vector2(0, -6f);
    private Vector2 second = new Vector2(0, 6f);
    private Vector2 third = new Vector2(-4f, 0);
    private Vector2 fourth = new Vector2(4f, 0);
    private Vector2 currentPos;
    private float xy_for_scale;

    private GameObject currentClick;
    private float timeToWait = 1.5f;
    private float timeCopy;
    private float timeBeetweenShort = 10f;

    void Start()
    {
        positions.Add(first);
        positions.Add(second);
        positions.Add(third);
        positions.Add(fourth);
        timeCopy = timeToWait;
    }
    // Update is called once per frame
    void Update()
    {
        timeToWait -= Time.deltaTime;
        timeBeetweenShort -= Time.deltaTime;
        if (timeToWait <= 0)
        {
            if(TouchInput.score <= 5)
            {
                currentPos = positions[Random.Range(0, 4)];
            }
            else
            {
                positions.Clear();
                first.x = Random.Range(-4f, 4f);
                second.x = Random.Range(-4f, 4f);
                third.y = Random.Range(-6f, 6f);
                fourth.y = Random.Range(-6f, 6f);
                positions.Add(first);
                positions.Add(second);
                positions.Add(third);
                positions.Add(fourth);
                currentPos = positions[Random.Range(0, positions.Count)];
            }
            currentClick = Instantiate(toSpawn[Random.Range(0,toSpawn.Count)], currentPos, toSpawn[0].transform.rotation);
            xy_for_scale = Random.Range(.4f, 1f);
            currentClick.transform.localScale = new Vector3(xy_for_scale, xy_for_scale, 1f);
            if(TouchInput.score <= 10)
            {
                timeToWait = 1.5f;
            }
            else
            {
                timeToWait = timeCopy;
            }
            if (timeBeetweenShort <= 0)
            {
                if (timeCopy >= 0.6f)
                {
                    timeCopy -= 0.1f;
                }
                timeBeetweenShort = 10f;
            }
        }
    }
 }
