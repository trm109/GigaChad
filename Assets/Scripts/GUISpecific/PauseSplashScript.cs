using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSplashScript : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreen;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            paused = !paused;

        if (paused)
            pauseScreen.SetActive(true);
        else
            pauseScreen.SetActive(false);

        if (paused && Input.GetKeyDown("q") && (Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftAlt)))
            SceneManager.LoadScene("IntroScreen");
    }
}
