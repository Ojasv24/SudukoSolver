using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class No_Solution : MonoBehaviour
{
    Color color1;
    Color color2;
    Image image;
    Text text;

    void Start()
    {
        this.gameObject.SetActive(false);
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
        color1 = image.color;
        color2 = text.color;
        color1.a = 0f;
        color2.a = 0f;
        image.color = color1;
        text.color = color2;

        
    }

    public IEnumerator FadeIn()
    {
        this.gameObject.SetActive(true);
        for (int i = 1; i < 80; i++)
        {

            color1.a = i / 100f;
            color2.a = i / 100f;
            image.color = color1;
            text.color = color2;
            yield return null;
        }
        
    }
    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2);
        for (int i = 80; i > 0; i--)
        {
            color1.a = i / 100f;
            color2.a = i / 100f;
            image.color = color1;
            text.color = color2;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }


}
