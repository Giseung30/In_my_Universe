using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [Header("Script")]
    public Commander CommanderScript; //총괄하는 스크립트
    public DataBase DataBaseScript; //데이터베이스 스크립트

    [Header("MainMenu")]
    public Image MainMenuImage; //MainMenu 이미지
    public Image AddPlanetImage;
    public Image SearchPlanetImage;
    public Image OptionImage;

    [Header("Option")]
    public GameObject OptionObject; //Option 오브젝트
    public Image[] OptionImages; //Option 기능에 포함된 Image들
    public Text[] OptionTexts; //Option 기능에 포함된 Text들

    [Header("AddPlanet")]
    public GameObject AddPlanetUI; //행성 추가 UI
    public GameObject AddPlanetField; //행성 추가 이름 입력 칸

    [Header("UI")]
    public GameObject MainUI; //메인 UI
    public Image WhiteScreen; //하얀색 화면
    public Text FindedPlanet; //발견한 행성의 개수

    [Header("PlanetScene")]
    public GameObject PlanetSceneObject; //행성 장면 오브젝트
    public Transform ClickedPlanet; //클릭된 행성 Transform
    public GameObject PlanetSceneUI; //행성 장면 UI
    public Text PlanetName; //행성 이름 Text
    public Text PlanetLevel; //행성 레벨 Text
    public Image[] PlanetLevelImages = new Image[3]; //레벨 이미지
    public Sprite FilledButton; //채워있는 버튼 이미지
    public Sprite UnFilledButton; //비워있는 버튼 이미지
    public GameObject ConfirmObject; //확인 오브젝트
    public Transform DayTransform; //일 수를 담는 Transform

    [Header("Search")]
    public GameObject SearchUI; //탐색 UI
    public GameObject ButtonSample; //버튼 샘플
    public Transform Content; //Scroll View Content

    [Header("Sound")]
    public AudioSource _backGroundMusicAudioSource; //배경음 음악 오디오 소스
    public Toggle _backGroundMusicToggle; //배경음 음악 토글

    public void Start()
    {
        MainMenuImage.gameObject.SetActive(false); //MainMenu 비활성화
        OptionObject.SetActive(false); //환경설정 오브젝트 비활성화
        AddPlanetUI.SetActive(false); //행성 추가 UI 비활성화
        AddPlanetField.SetActive(false); //행성 추가 이름 입력 필드 비활성화
    }

    public void OnClickMainMenuButton() //MainMenuButton을 클릭했을 때 실행되는 함수
    {
        StartCoroutine(MainMenuControl(MainMenuImage.gameObject.activeSelf)); //코루틴 실행
    }

    public IEnumerator MainMenuControl(bool State) //MainMenu 활성화하는 코루틴
    {
        if (State) //MainMenu을 비활성화 시켜야 하면
        {
            MainMenuImage.color = new Color(MainMenuImage.color.r, MainMenuImage.color.g, MainMenuImage.color.b, 1f); //색상 초기화
            AddPlanetImage.color = new Color(AddPlanetImage.color.r, AddPlanetImage.color.g, AddPlanetImage.color.b, 1f); //색상 초기화
            SearchPlanetImage.color = new Color(SearchPlanetImage.color.r, SearchPlanetImage.color.g, SearchPlanetImage.color.b, 1f); //색상 초기화
            OptionImage.color = new Color(OptionImage.color.r, OptionImage.color.g, OptionImage.color.b, 1f); //색상 초기화
            while (MainMenuImage.color.a > 0f) //아직 어두워지지 않으면
            {
                MainMenuImage.color -= new Color(0f, 0f, 0f, Time.deltaTime); //점점 어두워짐
                AddPlanetImage.color -= new Color(0f, 0f, 0f, Time.deltaTime); //색상 초기화
                SearchPlanetImage.color -= new Color(0f, 0f, 0f, Time.deltaTime); //색상 초기화
                OptionImage.color -= new Color(0f, 0f, 0f, Time.deltaTime); //색상 초기화
                yield return new WaitForEndOfFrame(); //다음 프레임까지 대기
            }
            MainMenuImage.gameObject.SetActive(false); //게임 오브젝트 비활성화
            yield return null;
        }
        else //MainMenu을 활성화 시켜야 하면
        {
            MainMenuImage.gameObject.SetActive(true); //게임 오브젝트 활성화
            MainMenuImage.color = new Color(MainMenuImage.color.r, MainMenuImage.color.g, MainMenuImage.color.b, 0f); //색상 초기화
            AddPlanetImage.color = new Color(AddPlanetImage.color.r, AddPlanetImage.color.g, AddPlanetImage.color.b, 0f); //색상 초기화
            SearchPlanetImage.color = new Color(SearchPlanetImage.color.r, SearchPlanetImage.color.g, SearchPlanetImage.color.b, 0f); //색상 초기화
            OptionImage.color = new Color(OptionImage.color.r, OptionImage.color.g, OptionImage.color.b, 0f); //색상 초기화
            while (MainMenuImage.color.a < 1f) //아직 밝아지지 않으면
            {
                MainMenuImage.color += new Color(0f, 0f, 0f, Time.deltaTime); //점점 밝아짐
                AddPlanetImage.color += new Color(0f, 0f, 0f, Time.deltaTime); //색상 초기화
                SearchPlanetImage.color += new Color(0f, 0f, 0f, Time.deltaTime); //색상 초기화
                OptionImage.color += new Color(0f, 0f, 0f, Time.deltaTime); //색상 초기화
                yield return new WaitForEndOfFrame(); //다음 프레임까지 대기
            }
            yield return null;
        }
    }

    public void OnClickOptionButton() //OptionButton을 클릭했을 때 실행되는 함수
    {
        StartCoroutine(OptionControl(OptionObject.activeSelf)); //코루틴 실행
    }

    public IEnumerator OptionControl(bool State) //Option 관리하는 코루틴
    {
        float Alpha; //알파값으로 사용할 변수
        if (State) //비활성화 시켜야 하면
        {
            Alpha = 1f; //투명도 초기화
            for (int i = 0; i < OptionImages.Length; i += 1) //Option 이미지 초기화
            {
                OptionImages[i].color = new Color(OptionImages[i].color.r, OptionImages[i].color.g, OptionImages[i].color.b, Alpha);
            }
            for (int i = 0; i < OptionTexts.Length; i += 1) //Option 텍스트 초기화
            {
                OptionTexts[i].color = new Color(OptionTexts[i].color.r, OptionTexts[i].color.g, OptionTexts[i].color.b, Alpha);
            }
            while (Alpha > 0f) //투명도가 아직 남아있으면
            {
                Alpha -= Time.deltaTime;
                for (int i = 0; i < OptionImages.Length; i += 1) //Option 이미지 초기화
                {
                    OptionImages[i].color = new Color(OptionImages[i].color.r, OptionImages[i].color.g, OptionImages[i].color.b, Alpha); //불투명도 서서히 증가
                }
                for (int i = 0; i < OptionTexts.Length; i += 1) //Option 텍스트 초기화
                {
                    OptionTexts[i].color = new Color(OptionTexts[i].color.r, OptionTexts[i].color.g, OptionTexts[i].color.b, Alpha); //불투명도 서서히 증가
                }
                yield return new WaitForEndOfFrame(); //다음 프레임까지 대기
            }
            OptionObject.SetActive(false); //Option 오브젝트 비활성화
        }
        else //활성화 시켜야 하면
        {
            OptionObject.SetActive(true); //Option 오브젝트 활성화
            Alpha = 0f; //투명도 초기화
            for (int i = 0; i < OptionImages.Length; i += 1) //Option 이미지 초기화
            {
                OptionImages[i].color = new Color(OptionImages[i].color.r, OptionImages[i].color.g, OptionImages[i].color.b, Alpha);
            }
            for (int i = 0; i < OptionTexts.Length; i += 1) //Option 텍스트 초기화
            {
                OptionTexts[i].color = new Color(OptionTexts[i].color.r, OptionTexts[i].color.g, OptionTexts[i].color.b, Alpha);
            }
            while (Alpha < 1f) //투명도가 다 밝아지지 않으면
            {
                Alpha += Time.deltaTime;
                for (int i = 0; i < OptionImages.Length; i += 1) //Option 이미지 초기화
                {
                    OptionImages[i].color = new Color(OptionImages[i].color.r, OptionImages[i].color.g, OptionImages[i].color.b, Alpha); //불투명도 서서히 증가
                }
                for (int i = 0; i < OptionTexts.Length; i += 1) //Option 텍스트 초기화
                {
                    OptionTexts[i].color = new Color(OptionTexts[i].color.r, OptionTexts[i].color.g, OptionTexts[i].color.b, Alpha); //불투명도 서서히 증가
                }
                yield return new WaitForEndOfFrame(); //다음 프레임까지 대기
            }
        }
        yield return null;
    }

    public void OnClickOptionExitButton() //Option의 닫기 버튼을 누르면 실행되는 함수
    {
        StartCoroutine(OptionControl(true));//Option 오브젝트 비활성화
    }

    public void OnClickAddPlanetButton(bool State) //행성을 추가하는 버튼을 클릭하면 실행되는 함수
    {
        if (State) //활성화 시키려면
        {
            StartCoroutine(Shining()); //반짝이는 코루틴 실행
            CommanderScript.ChangeToAddPlanet(); //행성 추가하는 화면으로 이동
            MainUI.SetActive(false); //Main UI 비활성화
            AddPlanetUI.SetActive(true); //행성 추가하는 UI 활성화
        }
        else //비활성화 시키려면
        {
            StartCoroutine(Shining()); //반짝이는 코루틴 실행
            CommanderScript.ChangeToMain(); //메인 화면으로 이동
            MainUI.SetActive(true); //Main UI 활성화
            AddPlanetUI.SetActive(false); //행성 추가하는 UI 비활성화
            AddPlanetField.SetActive(false); //이름 입력하는 UI 비활성화
            AddPlanetField.GetComponent<InputField>().text = ""; //이름 입력하는 필드 초기화
        }
    }

    public IEnumerator Shining() //반짝하는 함수
    {
        WhiteScreen.color = new Color(WhiteScreen.color.r, WhiteScreen.color.g, WhiteScreen.color.b, 1f); //투명도 초기화
        yield return new WaitForSeconds(0.2f); //대기
        while (WhiteScreen.color.a > 0f) //투명도가 아직 밝아지지 않으면
        {
            WhiteScreen.color -= new Color(0f, 0f, 0f, Time.deltaTime); //불투명도 서서히 감소
            yield return new WaitForEndOfFrame(); //다음 프레임까지 대기
        }
        yield return null;
    }

    public void OnClickAddPlanetConfirmButton() //행성 추가 확인 버튼을 클릭했을 때 실행되는 함수
    {
        DataBaseScript.AddPlanetInDataBase(new Planet(AddPlanetField.GetComponent<InputField>().text, 0, StaticSet.AddPlanetNumber, System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), 0, new List<Meeting>()));
        CommanderScript.PlacePlanet(); //행성 배치
        OnClickAddPlanetButton(false); //행성 추가 비활성화 시키는 버튼
    }

    public void PlanetSceneReset(bool State) //행성 정보 장면을 초기화 시키는 함수
    {
        if (State) //활성화시켜야 하면
        {
            List<PlayerInfo> PlayerInfoList = DataBaseScript.LoadDataBase(); //데이터베이스에서 불러옴
            if (ClickedPlanet.childCount > 0) Destroy(ClickedPlanet.GetChild(0).gameObject); //원래의 행성 제거
            for (int i = 0; i < PlayerInfoList[0].Planets.Count; i += 1) //데이터베이스의 행성 탐색
            {
                if (PlayerInfoList[0].Planets[i].Name == StaticSet.ClickedPlanetName) //일치하는 이름 탐색
                {
                    /* 행성 탐색 */
                    GameObject GoalPlanet = CommanderScript.Storage.Find(PlayerInfoList[0].Planets[i].Type + "-" + PlayerInfoList[0].Planets[i].Level).gameObject;
                    GameObject P = Instantiate(GoalPlanet, ClickedPlanet.position, ClickedPlanet.rotation); //행성 생성
                    P.GetComponent<Transform>().SetParent(ClickedPlanet); //행성 부모 변경
                    P.GetComponent<Transform>().localScale = new Vector3(2.5f, 2.5f, 2.5f); //크기 재조정
                    P.SetActive(true); //활성화
                    PlanetLevel.text = "Lv " + (PlayerInfoList[0].Planets[i].Level + 1); //행성 레벨 삽입
                    for (int j = 0; j < 3; j += 1) PlanetLevelImages[j].sprite = UnFilledButton; //채워지지 않은 레벨 버튼으로 초기화
                    for (int j = 0; j < PlayerInfoList[0].Planets[i].Times % 3; j += 1) PlanetLevelImages[j].sprite = FilledButton; //채운 레벨 버튼으로 채움
                    for (int j = 1; j < 31; j += 1)
                    {
                        DayTransform.Find(j.ToString()).GetComponent<DayButton>().IsExist = false; //일 수 존재 여부 초기화
                        DayTransform.Find(j.ToString()).GetComponent<Text>().color = new Color(128f / 255f, 128f / 255f, 128f / 255f); //색상 초기화
                    }
                    for (int j = 0; j < PlayerInfoList[0].Planets[i].Meetings.Count; j += 1)
                    {
                        DayTransform.Find(PlayerInfoList[0].Planets[i].Meetings[j].Date).GetComponent<DayButton>().IsExist = true; //일 수 채움 
                        DayTransform.Find(PlayerInfoList[0].Planets[i].Meetings[j].Date).GetComponent<Text>().color = new Color(1f, 1f, 1f); //색상 채움
                    }
                    break; //반복문 빠져나옴
                }
            }
            MainUI.SetActive(false); //Main UI 비활성화
            PlanetName.text = StaticSet.ClickedPlanetName; //클릭된 행성의 이름 삽입
            PlanetSceneUI.SetActive(true); //행성 장면 UI 활성화
            CommanderScript.ChangeToPlanetScene(); //카메라 이동
        }
        else //비활성화시켜야 하면
        {
            MainUI.SetActive(true); //Main UI 활성화
            PlanetSceneUI.SetActive(false); //행성 장면 UI 비활성화
            CommanderScript.PlacePlanet(); //행성 재배치
            CommanderScript.ChangeToMain(); //카메라 이동
        }
        StartCoroutine(Shining()); //반짝이는 코루틴 실행
    }

    public void ActivatePlanetConfirm() //행성 기록창 활성화하는 함수
    {
        ConfirmObject.GetComponent<Transform>().Find("Date").GetComponent<Text>().text = "2019.12." + string.Format("{0:00}", StaticSet.ClickedDay); //날짜 출력
        ConfirmObject.SetActive(true); //확인 오브젝트 활성화
    }

    public void OnClickConfirmButton(bool State) //확인 오브젝트의 Yes 또는 No 버튼을 클릭했을 때 실행되는 함수
    {
        if (State) //Yes 버튼을 클릭하면
        {
            DataBaseScript.AddMeetingInDataBase(); //데이터베이스에 만남 정보 추가
            ConfirmObject.SetActive(false); //확인 오브젝트 비활성화
            PlanetSceneReset(true); //행성 장면 초기화
        }
        else //No 버튼을 클릭하면
        {
            ConfirmObject.SetActive(false); //확인 오브젝트 비활성화
        }
    }

    public void OnClickDeletePlanetButton() //행성 삭제 버튼을 누르면 실행되는 함수
    {
        DataBaseScript.DeletePlanetInDataBase(); //행성 제거
        PlanetSceneReset(false); //행성 장면 종료
    }

    public void OnClickSearchButton(bool State) //검색 버튼을 누르면 실행되는 함수
    {
        if (State) //활성화해야 하면
        {
            MainUI.SetActive(false); //Main UI 비활성화
            SearchUI.SetActive(true); //탐색 UI 활성화
            List<GameObject> Test = new List<GameObject>(); //리스트 생성
            for (int i = 1; i < Content.childCount; i += 1) //버튼들을 탐색하며
            {
                Test.Add(Content.GetChild(i).gameObject); //리스트에 담음
            }
            for (int i = 0; i < Test.Count; i += 1) Destroy(Test[i]); //모든 버튼 파괴

            List<PlayerInfo> PlayerInfoList = DataBaseScript.LoadDataBase(); //데이터베이스에서 불러옴
            PlayerInfoList[0].Planets.Sort(delegate (Planet a, Planet b) //레벨 순으로 정렬
            {
                if (a.Level < b.Level) return 1;
                else return -1;
            }
);
            for (int i = 0; i < PlayerInfoList[0].Planets.Count; i += 1) //데이터베이스의 행성 탐색
            {
                Transform ButtonTransform = Instantiate(ButtonSample).transform; //버튼 생성
                ButtonTransform.gameObject.SetActive(true); //활성화
                ButtonTransform.SetParent(Content); //부모 변경
                ButtonTransform.localScale = new Vector3(1f, 1f, 1f); //크기 조정
                ButtonTransform.Find("Name").GetComponent<Text>().text = PlayerInfoList[0].Planets[i].Name;
                ButtonTransform.Find("Level").GetComponent<Text>().text = "Lv " + (PlayerInfoList[0].Planets[i].Level + 1);
                string[] Str = PlayerInfoList[0].Planets[i].Date.Split('-'); //생성일 분해
                ButtonTransform.Find("CreateDate").GetComponent<Text>().text = "생성일 : " + Str[0] + '-' + Str[1] + '-' + Str[2] + ' ' + Str[3] + ':' + Str[4] + ':' + Str[5];
                ButtonTransform.Find("Times").GetComponent<Text>().text = "방문 횟수 : " + PlayerInfoList[0].Planets[i].Times;
                ButtonTransform.GetComponent<PlanetButton>().Name = PlayerInfoList[0].Planets[i].Name; //버튼에 이름 삽입
            }
            CommanderScript.ChangeToSearch(); //검색 화면으로 카메라 이동
        }
        else //비활성화해야 하면
        {
            MainUI.SetActive(true); //Main UI 활성화
            SearchUI.SetActive(false); //탐색 UI 비활성화
            CommanderScript.ChangeToMain(); //메인 화면으로 카메라 이동
        }
        StartCoroutine(Shining()); //화면 반짝임
    }

    public void OnChangedBackGroundMusic() //배경음 설정이 변경되면 실행되는 함수
    {
        if (_backGroundMusicToggle.isOn) //켜져 있으면
        {
            _backGroundMusicAudioSource.Play(); //배경음 실행
        }
        else //꺼져 있으면
        {
            _backGroundMusicAudioSource.Stop(); //배경음 종료
        }
    }
}