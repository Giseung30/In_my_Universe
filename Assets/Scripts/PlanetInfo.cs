using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    [Header("Variable")]
    public string Name; //행성 이름

    [Header("Script")]
    public UIController UIControllerScript; //UIController 스크립트

    public void OnMouseDown() //행성이 클릭되었을 때 실행되는 함수
    {
        Debug.Log("클릭된 행성 이름 : " + Name);
        StaticSet.ClickedPlanetName = Name; //클릭된 행성 이름 지정
        UIControllerScript.PlanetSceneReset(true); //행성 정보 장면 활성화
    }
}