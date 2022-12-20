using UnityEngine;
using System.IO;
using LitJson;
using System.Collections.Generic;

public class DataBase : MonoBehaviour
{
    public void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/PlayerInfoData1.json"))//파일이 존재하지 않으면
        {
            List<PlayerInfo> PlayerInfoList = new List<PlayerInfo>();
            PlayerInfoList.Add(new PlayerInfo("기승", 0, new List<Planet>()));
            JsonData InfoJson = JsonMapper.ToJson(PlayerInfoList);
            File.WriteAllText(Application.persistentDataPath + "/PlayerInfoData1.json", InfoJson.ToString());
            Debug.Log("파일 생성 완료");
        }
    }

    public List<PlayerInfo> LoadDataBase() //데이터베이스로부터 값을 읽어오는 함수
    {
        List<PlayerInfo> PlayerInfoList = new List<PlayerInfo>();
        if (File.Exists(Application.persistentDataPath + "/playerinfodata1.json")) //파일이 존재하면
        {
            string jsonStr = File.ReadAllText(Application.persistentDataPath + "/PlayerInfoData1.Json");
            JsonData PlayerData = JsonMapper.ToObject(jsonStr);

            int PlayerDataCount;
            try { PlayerDataCount = PlayerData.Count; }
            catch { PlayerDataCount = 0; }
            for (int i = 0; i < PlayerDataCount; i += 1)
            {
                JsonData PlanetData = PlayerData[i]["Planets"];
                List<Planet> PlanetInfoList = new List<Planet>();
                int PlanetDataCount;
                try { PlanetDataCount = PlanetData.Count; }
                catch { PlanetDataCount = 0; }
                for (int j = 0; j < PlanetDataCount; j += 1)
                {
                    JsonData MeetingData = PlanetData[j]["Meetings"];
                    List<Meeting> MeetingInfoList = new List<Meeting>();
                    int MeetingDataCount;
                    try { MeetingDataCount = MeetingData.Count; }
                    catch { MeetingDataCount = 0; }
                    for (int k = 0; k < MeetingDataCount; k += 1)
                    {
                        MeetingInfoList.Add(new Meeting(MeetingData[k]["Date"].ToString(), MeetingData[k]["Explain"].ToString()));

                    }
                    PlanetInfoList.Add(new Planet(PlanetData[j]["Name"].ToString(), int.Parse(PlanetData[j]["Level"].ToString()), int.Parse(PlanetData[j]["Type"].ToString()), PlanetData[j]["Date"].ToString(), int.Parse(PlanetData[j]["Times"].ToString()), MeetingInfoList));
                }
                PlayerInfoList.Add(new PlayerInfo(PlayerData[i]["Name"].ToString(), int.Parse(PlayerData[i]["PlanetCount"].ToString()), PlanetInfoList));
            }
        }
        return PlayerInfoList;
    }

    public void AddPlanetInDataBase(Planet NewPlanet) //행성 추가하는 함수
    {
        List<PlayerInfo> PlayerInfoList = LoadDataBase(); //데이터베이스에서 값 읽어옴
        PlayerInfoList[0].Planets.Add(NewPlanet); //새 행성 추가
        JsonData infoJson = JsonMapper.ToJson(PlayerInfoList);
        File.WriteAllText(Application.persistentDataPath + "/PlayerInfoData1.json", infoJson.ToString()); //파일로 저장
        Debug.Log("행성 추가 완료");
    }

    public void DeletePlanetInDataBase() //행성 삭제하는 함수
    {
        List<PlayerInfo> PlayerInfoList = LoadDataBase(); //데이터베이스에서 불러옴
        for (int i = 0; i < PlayerInfoList[0].Planets.Count; i += 1) //데이터베이스의 행성 탐색
        {
            if (PlayerInfoList[0].Planets[i].Name == StaticSet.ClickedPlanetName) //일치하는 이름 탐색
            {
                PlayerInfoList[0].Planets.RemoveAt(i); //행성 정보 삭제
                break;
            }
        }
        JsonData infoJson = JsonMapper.ToJson(PlayerInfoList);
        File.WriteAllText(Application.persistentDataPath + "/PlayerInfoData1.json", infoJson.ToString()); //파일로 저장
    }

    public void AddMeetingInDataBase() //만남 날짜를 데이터베이스에 추가하는 함수
    {
        List<PlayerInfo> PlayerInfoList = LoadDataBase(); //데이터베이스에서 불러옴
        for (int i = 0; i < PlayerInfoList[0].Planets.Count; i += 1) //데이터베이스의 행성 탐색
        {
            if (PlayerInfoList[0].Planets[i].Name == StaticSet.ClickedPlanetName) //일치하는 이름 탐색
            {
                PlayerInfoList[0].Planets[i].Meetings.Add(new Meeting(StaticSet.ClickedDay.ToString(), "")); //만나는 날짜 추가
                PlayerInfoList[0].Planets[i].Times += 1; //만난 횟수 증가
                PlayerInfoList[0].Planets[i].Level = PlayerInfoList[0].Planets[i].Times / 3; //레벨 지정
                break;
            }
        }
        JsonData infoJson = JsonMapper.ToJson(PlayerInfoList);
        File.WriteAllText(Application.persistentDataPath + "/PlayerInfoData1.json", infoJson.ToString()); //파일로 저장
    }
}