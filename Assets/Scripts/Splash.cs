using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class Splash : MonoBehaviour
{
    public int Trigger; //트리거

    [Header("1")]
    public GameObject SplashObject; //Splash를 감싸는 오브젝트
    public Text SplashText; //InMyUniverse 텍스트
    public Image SplashImage; //행성 이미지
    public PlayableDirector SplashTimeLine; //Splash 타임라인

    [Header("2")]
    public GameObject AstronautObject; //우주비행사 오브젝트
    public Text Sentence1; //"안녕하세요 모험가님"

    [Header("4")]
    public Text Sentence2; //"나를 둘러싼 나의 우주를 탐험해보세요."

    [Header("6")]
    public GameObject SpaceManObject; //텍스트 담는 오브젝트
    public GameObject Planet; //행성 오브젝트
    public GameObject MainCanvas; //Main 캔버스

    public void SetTrigger(int Value) //트리거 설정하는 함수
    {
        Trigger = Value;
    }

    public void Start() //초기화 하는 함수
    {
        SplashObject.SetActive(true); //활성화
        SplashText.color = new Color(SplashText.color.r, SplashText.color.g, SplashText.color.b, 1f); //불투명도 초기화
        SplashImage.color = new Color(SplashImage.color.r, SplashImage.color.g, SplashImage.color.b, 1f); //불투명도 초기화

        AstronautObject.SetActive(false);
        Sentence1.color = new Color(Sentence1.color.r, Sentence1.color.g, Sentence1.color.b, 0f); //불투명도 초기화

        Sentence2.color = new Color(Sentence2.color.r, Sentence2.color.g, Sentence2.color.b, 0f); //불투명도 초기화

        SpaceManObject.SetActive(true); //활성화
        Planet.SetActive(false); //행성 오브젝트 비활성화
        MainCanvas.SetActive(false); //Main 캔버스 비활성화
    }

    public void Update()
    {
        if (Trigger == 1) //1
        {
            SplashText.color += new Color(0f, 0f, 0f, -Time.deltaTime); //텍스트 투명도 증가
            SplashImage.color += new Color(0f, 0f, 0f, -Time.deltaTime); //이미지 투명도 증가
            if (SplashImage.color.a <= 0f) //모두 어두워 지면
            {
                Trigger = 0; //트리거 초기화
                SplashObject.SetActive(false); //비활성화
                SplashTimeLine.Play(); //타임라인 실행
            }
        }
        else if (Trigger == 2) //2
        {
            AstronautObject.SetActive(true); //우주비행사 보이도록 설정
            Sentence1.color += new Color(0f, 0f, 0f, Time.deltaTime); //불투명도 서서히 증가
            if (Sentence1.color.a >= 1f) //텍스트 밝아지면
            {
                Trigger = 0; //트리거 초기화
            }
        }
        else if (Trigger == 3) //3
        {
            Sentence1.color += new Color(0f, 0f, 0f, -Time.deltaTime); //불투명도 서서히 감소
            if (Sentence1.color.a <= 0f) //텍스트 어두워지면
            {
                Trigger = 0; //트리거 초기화
            }
        }
        else if (Trigger == 4) //4
        {
            Sentence2.color += new Color(0f, 0f, 0f, Time.deltaTime); //불투명도 서서히 증가
            if (Sentence2.color.a >= 1f) //텍스트 어두워지면
            {
                Trigger = 0; //트리거 초기화
            }
        }
        else if (Trigger == 5) //5
        {
            Sentence2.color += new Color(0f, 0f, 0f, -Time.deltaTime); //불투명도 서서히 감소
            if (Sentence2.color.a <= 0f) //텍스트 어두워지면
            {
                Trigger = 0; //트리거 초기화

            }
        }
        else if (Trigger == 6) //6
        {
            SpaceManObject.SetActive(false); //SpaceMan 오브젝트 비활성화
            Planet.SetActive(true); //행성 보이도록 설정
            MainCanvas.SetActive(true); //Main 캔버스 활성화
            Trigger = 0; //트리거 초기화
        }
    }
}