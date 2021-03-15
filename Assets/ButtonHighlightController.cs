using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlightController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Sprite defaultSprite;
    public Sprite highlightSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = highlightSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = defaultSprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
