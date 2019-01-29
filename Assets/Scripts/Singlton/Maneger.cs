using UnityEngine;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

public class Maneger : MonoBehaviour
{
    public static Maneger Instance;

    public GameData GD;

    private BinaryFormatter BF;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            GD = new GameData();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Save()
    {
        BF = new BinaryFormatter();

        var Hash = new Hashtable
        {
            { "DiveTime", GD.DiveTime },
            { "TimesPlayed", GD.TimesPlayed }
        };

        var fs = new FileStream(Application.streamingAssetsPath + "\\GameData.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        BF.Serialize(fs, Hash);

        fs.Close();
    }

    public void Load()
    {
        BF = new BinaryFormatter();
        var Hash = new Hashtable();
        var fs = new FileStream(Application.streamingAssetsPath + "\\GameData.dat", FileMode.Open, FileAccess.ReadWrite);

        Hash = (Hashtable)BF.Deserialize(fs);

        fs.Close();

        foreach(DictionaryEntry de in Hash)
        {
            if(de.Key.ToString() == "DiveTime")
            {
                GD.DiveTime = (int)de.Value;
            }
            if (de.Key.ToString() == "TimesPlayed")
            {
                GD.TimesPlayed = (int)de.Value;
            }
        }
    }

    public void OnDiveComplete()
    {

        GD.TimesPlayed++;
        GD.DiveTime += 2;
    }
}