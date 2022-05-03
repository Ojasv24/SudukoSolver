using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class Draging : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private RectTransform[] rectTransform;
    float x, y;
   

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        Debug.Log(canvas.name);
        rectTransform = GetComponentsInChildren<RectTransform>();
        Text text = GetComponentInChildren<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
         
        //Debug.Log("OnDrag");
        
        rectTransform[0].anchoredPosition += eventData.delta / canvas.scaleFactor;
        rectTransform[1].anchoredPosition += eventData.delta / canvas.scaleFactor;
        rectTransform[2].anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        rectTransform[0].anchoredPosition = new Vector2(x, y);
        rectTransform[1].anchoredPosition = new Vector2(x, y);
        rectTransform[2].anchoredPosition = new Vector2(x, y);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        x = rectTransform[0].anchoredPosition.x;
        y = rectTransform[0].anchoredPosition.y;
    }

    
}
