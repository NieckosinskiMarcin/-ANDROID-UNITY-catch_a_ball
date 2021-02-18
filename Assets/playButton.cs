using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    public Button play;
    public int sceneToLoad;

    // Update is called once per frame
    void Start()
    {
        play.onClick.AddListener(startGame);
    }

    private void startGame()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
