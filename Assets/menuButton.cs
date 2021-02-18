using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
    public Button menu;

    // Update is called once per frame
    void Start()
    {
        menu.onClick.AddListener(goToMenu);
    }

    private void goToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
