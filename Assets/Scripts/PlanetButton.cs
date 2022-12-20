using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetButton : MonoBehaviour
{
    [Header("Variable")]
    public string Name; //행성 이름

    [Header("Script")]
    public UIController UIControllerScript; //UIController 스크립트

    public void OnClickThisButton() //현재 버튼이 클릭되면
    {
        StaticSet.ClickedPlanetName = Name; //행성 이름 삽입
        UIControllerScript.SearchUI.SetActive(false); //탐색 UI 비활성화
        UIControllerScript.PlanetSceneReset(true); //행성 장면으로 이동
    }
}