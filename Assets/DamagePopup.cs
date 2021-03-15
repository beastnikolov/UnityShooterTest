using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{

    private void Update()
    {
        float transpSpeed = 0.5f;
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        GetComponent<TextMeshPro>().alpha -= transpSpeed * Time.deltaTime;
    }
}
