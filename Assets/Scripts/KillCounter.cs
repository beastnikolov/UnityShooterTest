using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public GameObject zombieKillCounter;
    TextMeshProUGUI zombieCounterText;

    int zombieKill;

    void Start()
    {
        zombieCounterText = zombieCounterText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKill()
    {
        zombieKill++;
        zombieCounterText.SetText("Kill counter: " + zombieKill);
    }
}
