using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour
{

    public RectTransform itemPrefab;
    public List<Item> playerInventoryList;
    public ScrollRect scrollView;
    public RectTransform content;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FetchModels(Action onDone)
    {

    }
}
