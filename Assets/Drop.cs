using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Drop : MonoBehaviour, IDropHandler
{
    private RectTransform[] rectTransform;
    float x, y; 
    string txt;
    bool check = false;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        Text text = GetComponentInChildren<Text>();
        var puzzle = FindObjectOfType<Puzzle>();
        txt = eventData.pointerDrag.GetComponentInChildren<Text>().text;
        text.color = Color.blue;
        text.text = txt;
        
        check = true;
        
        rectTransform = eventData.pointerDrag.GetComponentsInChildren<RectTransform>();

           
        var nameOfGameObject = this.gameObject.name;
        int x = Convert.ToInt32(char.GetNumericValue(nameOfGameObject[0]));
        int y = Convert.ToInt32(char.GetNumericValue(nameOfGameObject[2]));
        puzzle.UpdateList(x, y, Convert.ToInt32(txt));
        
        

    }



}
