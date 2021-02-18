using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public Text text;
    public List<GameObject> lifes = new List<GameObject>();
    public static int score = 0;
    public int lifesCounter = 0;
    public GameObject menuButton;
    public GameObject gameOverText;
    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            //Debug.Log("Touched " + touchPosWorld.x + "" +  touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            if (hitInformation.collider != null)
            {
                GameObject touchedObject = hitInformation.transform.gameObject;
                if (touchedObject.tag == "goodClick")
                {
                    score += 1;
                    Destroy(touchedObject);
                }
                else if (touchedObject.tag == "badClick")
                {
                    if (score >= 10)
                    {
                        score -= 10;
                    }
                    else
                    {
                        score = 0;
                    }
                    lifes[lifesCounter].SetActive(true);
                    lifesCounter++;
                    if (lifesCounter == lifes.Count)
                    {
                        Time.timeScale = 0;
                        menuButton.SetActive(true);
                        gameOverText.SetActive(true);
                    }
                    Destroy(touchedObject);
                }
            }

        }
    }
}
