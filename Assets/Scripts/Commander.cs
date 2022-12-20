using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    [Header("Object")]
    public Transform MainCamera; //메인 카메라
    public Transform Astronaut; //우주비행사 Transform

    [Header("Component")]
    public Transform[] OrbitAxis = new Transform[3]; //궤도 Transform
    public Transform AddPlanetObject; //행성 추가하는 오브젝트
    public Transform Storage; //저장소

    [Header("Script")]
    public DataBase DataBaseScript; //DataBase 스크립트
    public UIController UIControllerScript; //UIController 스크립트

    public void Start()
    {
        Screen.SetResolution(615, 1280, true); //해상도 설정
        MainCamera.position = new Vector3(0f, 0f, 0f); //메인 카메라 위치 초기화
        PlacePlanet();
    }

    public void ChangeToMain() //메인 화면으로 이동하는 함수
    {
        MainCamera.position = new Vector3(0f, 0f, 0f); //메인 화면으로 이동
    }

    public void ChangeToAddPlanet() //행성을 추가하는 화면으로 이동하는 함수
    {
        MainCamera.position = new Vector3(50f, 0f, 0f);
    }

    public void ChangeToAddPlanetName()
    {
        MainCamera.position = new Vector3(100f, 0f, 0f); //이름 적는 화면으로 이동하는 함수
    }

    public void Update()
    {
        AddPlanetRotation();
        Astronaut.Rotate(0f, 30f * Time.deltaTime, -20f * Time.deltaTime); //우주 비행사 천천히 회전
    }

    public void AddPlanetRotation() //행성 추가 화면에서 행성 회전을 담당하는 함수
    {
        AddPlanetObject.rotation = Quaternion.Slerp(AddPlanetObject.rotation, Quaternion.Euler(AddPlanetObject.eulerAngles.x, AddPlanetObject.eulerAngles.y, StaticSet.AddPlanetDegree), Time.deltaTime * 5f); //선택된 행성의 방향으로 서서히 회전
    }

    public void PlacePlanet() //행성 배치하는 함수
    {
        /* 이미 존재하는 행성 제거 */
        if (OrbitAxis[0].childCount > 0) Destroy(OrbitAxis[0].GetChild(0).gameObject);
        if (OrbitAxis[1].childCount > 0) Destroy(OrbitAxis[1].GetChild(0).gameObject);
        if (OrbitAxis[2].childCount > 0) Destroy(OrbitAxis[2].GetChild(0).gameObject);

        List<PlayerInfo> PlayerInfoList = DataBaseScript.LoadDataBase(); //데이터베이스의 값을 불러옴
        PlayerInfoList[0].Planets.Sort(delegate (Planet a, Planet b) //레벨 순으로 정렬
        {
            if (a.Level < b.Level) return 1;
            else return -1;
        }
        );
        UIControllerScript.FindedPlanet.text = "발견 행성 : " + PlayerInfoList[0].Planets.Count + "개"; //텍스트 갱신
        float[] OrbitDistance = new float[3] { 8f, 12.25f, 16.5f }; //궤도와의 거리
        for (int i = 0; i < PlayerInfoList[0].Planets.Count && i < 3; i += 1)
        {
            GameObject GoalPlanet = Storage.Find(PlayerInfoList[0].Planets[i].Type + "-" + PlayerInfoList[0].Planets[i].Level).gameObject; //목표 행성오브젝트 담음
            GameObject P = Instantiate(GoalPlanet, OrbitAxis[i].position + OrbitAxis[i].right * OrbitDistance[i], GoalPlanet.GetComponent<Transform>().rotation); //행성 생성
            P.SetActive(true); //행성 활성화
            P.AddComponent<PlanetInfo>(); //컴포넌트 추가
            P.GetComponent<PlanetInfo>().Name = PlayerInfoList[0].Planets[i].Name; //행성 이름 삽입
            P.GetComponent<PlanetInfo>().UIControllerScript = UIControllerScript; //UIController 스크립트 삽입
            P.GetComponent<Transform>().SetParent(OrbitAxis[i]); //궤도에 삽입
        }
    }

    public void ChangeToPlanetScene() //행성 정보 창으로 이동하는 함수
    {
        MainCamera.position = new Vector3(-50f, 0f, 0f); //메인 카메라 위치 이동
    }

    public void ChangeToSearch() //검색 화면으로 이동하는 함수
    {
        MainCamera.position = new Vector3(-100f, 0f, 0f); //메인 카메라 위치 이동
    }
}