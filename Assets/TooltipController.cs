using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{

    public GameObject tooltipObject;

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        var pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        tooltipObject.transform.position = pos;
    }

    public void displayTooltip()
    {
        tooltipObject.SetActive(true);
    }

    public void hideTooltip()
    {
        tooltipObject.SetActive(false);
    }
}
