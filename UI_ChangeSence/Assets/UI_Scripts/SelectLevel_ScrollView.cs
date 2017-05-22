using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SelectLevel_ScrollView : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    private float[] pages = new[] { 0f, 0.25f, 0.5f, 0.75f, 1f };
    private int NowPage;
    private bool isDraging=false;
    private Vector2 oldPos;
    private ScrollRect scrollRect;
    private float speed = 3f;


    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    void Update()
    {
        if (!isDraging)
        {
            if (null != scrollRect)
            {
                scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, pages[NowPage], speed * Time.deltaTime);
            }
            if (Mathf.Abs(scrollRect.horizontalNormalizedPosition-pages[NowPage])<0.003f)
            {
                scrollRect.horizontalNormalizedPosition = pages[NowPage];
                isDraging = true;
            }

        }
    }

    public Action<int> RefreshToggle;
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
        oldPos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (oldPos.x - eventData.position.x < 0)
        {
            if (NowPage > 0)
            {
                NowPage--;
                isDraging = false;
                RefreshToggle(NowPage);
            }
        }
        else
        {
            if (NowPage < 4)
            {
                NowPage++;
                isDraging = false;
                RefreshToggle(NowPage);
            }
        }
    }
    public void ShowPage1(bool isOn)
    {
        if (isOn)
        {
            NowPage = 0;
            isDraging = false;
        }
    }
    public void ShowPage2(bool isOn)
    {
        if (isOn)
        {
            NowPage = 1;
            isDraging = false;
        }
    }
    public void ShowPage3(bool isOn)
    {
        if (isOn)
        {
            NowPage = 2;
            isDraging = false;
        }
    }
    public void ShowPage4(bool isOn)
    {
        if (isOn)
        {
            NowPage = 3;
            isDraging = false;
        }
    }
    public void ShowPage5(bool isOn)
    {
        if (isOn)
        {
            NowPage = 4;
            isDraging = false;
        }
    }
}

