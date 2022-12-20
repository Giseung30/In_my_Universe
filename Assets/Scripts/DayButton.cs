using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayButton : MonoBehaviour
{
    [Header("Variable")]
    public int Day; //일
    public bool IsExist; //이미 존재하는 일인지 확인하는 변수

    [Header("Script")]
    public UIController UIControllerScript; //UIController 스크립트

    public void OnClickThisDay() //현재 일 수가 클릭되면 실행되는 함수
    {
        if (!IsExist) //존재하지 않는 일이면
        {
            StaticSet.ClickedDay = Day; //현재 일 수 삽입
            UIControllerScript.ActivatePlanetConfirm(); //확인 오브젝트 활성화
        }
    }
}