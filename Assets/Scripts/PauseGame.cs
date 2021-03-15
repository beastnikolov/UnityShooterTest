using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausedText;
    bool isPaused;

    // Update is called once per frame
    private void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyUp("p"))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                pausedText.GetComponent<TextMeshProUGUI>().enabled = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                pausedText.GetComponent<TextMeshProUGUI>().enabled = true;
            }
        }
    }
}
