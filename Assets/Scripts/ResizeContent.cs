using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeContent : MonoBehaviour
{
    [Header("Component")]
    public Transform ChildCount; //자식을 셀 Transform
    public RectTransform ResizeObject; //크기 조절할 RectTransform

    [Header("Variable")]
    public float Unit; //크기 단위

    void Update()
    {
        ResizeObject.sizeDelta = new Vector2(ResizeObject.rect.width, ChildCount.childCount * Unit); //높이 재조정
    }
}