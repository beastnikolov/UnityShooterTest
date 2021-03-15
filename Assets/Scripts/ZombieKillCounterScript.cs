using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieKillCounterScript : MonoBehaviour
{

    int killedZombies;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText("Kill count: " + killedZombies.ToString());   
    }

    public void addKill()
    {
        killedZombies++;
    }


}
