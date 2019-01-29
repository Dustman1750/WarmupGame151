using System;

[Serializable]
public class GameData
{
    public int DiveTime;
    public int TimesPlayed;
    public int MaxDepth;

    public GameData()
    {
        DiveTime = 0;
        TimesPlayed = 0;
        MaxDepth = 0;
    }
}
