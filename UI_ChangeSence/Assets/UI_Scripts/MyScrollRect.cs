using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MyScrollRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler{
    
    private ScrollRect _scrollRect;
    public float Speed;
    public Toggle[] toggles;


    public ScrollRect ScrollRect
    {
        get {
            if (_scrollRect == null)
            {
                _scrollRect = this.GetComponent<ScrollRect>();
            }
            return _scrollRect;
            }
    }

    bool isDrag = false;


    void Update()
    {
        if (isDrag==false)
        { 
        this.ScrollRect.horizontalNormalizedPosition = Mathf.Lerp(this.ScrollRect.horizontalNormalizedPosition, pagePosArray[current], Speed * Time.deltaTime);
        toggles[current].isOn = true;
        }
    }



    public void OnVauleChanged(Vector2 v2)
    {
       // print(v2.x.ToString()); 
    }



    float beginPos;
  // float[] pagePosArray = new float[]{0,0.373295f,0.7329504f,1};

  float[] pagePosArray = new float[] { 0, 0.3333333f, 0.66666f, 1 };

    int current = 0;


public void OnBeginDrag(PointerEventData eventData)
{
    isDrag = true;
    beginPos = this.ScrollRect.horizontalNormalizedPosition;
}


public void OnEndDrag(PointerEventData eventData)
{
    isDrag = false;
    float offset = this.ScrollRect.horizontalNormalizedPosition - beginPos;
    if (offset>0)
    {
        if (current < pagePosArray.Length - 1)
        {
            current++;

         //   this.ScrollRect.horizontalNormalizedPosition=pagePosArray[current];
        }
        
    }
    else if(offset<0)
    {
        if (current > 0)
        {
            current--;

          //  this.ScrollRect.horizontalNormalizedPosition = pagePosArray[current];
        }

    }

}






    public void OnMovePage0(bool isMove)
{

    if (isMove)
    {
        current = 0;
        isDrag = false;
    }

}

public void OnMovePage1(bool isMove)
{

    if (isMove)
    {
        current = 1;
        isDrag = false;
    }
}

public void OnMovePage2(bool isMove)
{

    if (isMove)
    {
        current = 2;
        isDrag = false;
    }
}

public void OnMovePage3(bool isMove)
{

    if (isMove)
    {
        current = 3;
        isDrag = false;
    }
}


}
