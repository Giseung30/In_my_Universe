using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlanetInfo : MonoBehaviour
{
    [Header("Information")]
    public int PlanetNumber; //행성 번호
    public float Degree; //각도

    [Header("Object")]
    public Transform SelectedPlanet; //선택된 행성

    [Header("Script")]
    public UIController UIControllerScript; //UIController 스크립트
    public Commander CommanderScript; //총괄하는 스크립트

    public void OnMouseDown() //행성이 클릭되었을 때
    {
        if (PlanetNumber == StaticSet.AddPlanetNumber) //현재 행성 번호와 클릭된 행성의 번호가 일치하면
        {
            StartCoroutine(UIControllerScript.Shining()); //반짝이는 함수 실행
            CommanderScript.ChangeToAddPlanetName(); //이름 입력하는 함수로 이동
            UIControllerScript.AddPlanetField.SetActive(true); //이름 입력하는 필드 활성화
        }
        else //현재 행성 번호와 클릭된 행성의 번호가 일치하지 않으면
        {
            StaticSet.AddPlanetNumber = PlanetNumber;
            StaticSet.AddPlanetDegree = Degree;
            if (SelectedPlanet.childCount > 0) //자식이 존재하면
                Destroy(SelectedPlanet.GetChild(0).gameObject); //기존에 있던 행성 제거
            GameObject Clone = Instantiate(gameObject, SelectedPlanet.position, SelectedPlanet.rotation); //현재 행성을 생성하여 배치
            Clone.GetComponent<Transform>().SetParent(SelectedPlanet); //부모 변경
        }
    }
}