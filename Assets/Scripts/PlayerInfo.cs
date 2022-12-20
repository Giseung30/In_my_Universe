using System.Collections;
using System.Collections.Generic;

public class Meeting
{
    public string Date;//만난 날짜
    public string Explain;//설명

    public Meeting(string date, string explain)
    {
        Date = date;
        Explain = explain;
    }
}

public class Planet
{
    public string Name;//행성이름
    public int Level;//행성레벨
    public int Type;//행성 타입
    public string Date;//생성날짜
    public int Times;//만난횟수
    public List<Meeting> Meetings;//만남정보

    public Planet(string name, int level, int type, string date, int times, List<Meeting> meetings)
    {
        Name = name;
        Level = level;
        Type = type;
        Date = date;
        Times = times;
        Meetings = meetings;
    }
}

public class PlayerInfo
{
    public string Name;//사람이름
    public int PlanetCount;//행성갯수
    public List<Planet> Planets;//행성들

    public PlayerInfo(string name, int planetCount, List<Planet> planets)
    {
        Name = name;
        PlanetCount = planetCount;
        Planets = planets;
    }
}