using UnityEngine;
using SimpleJSON;
using System.IO;

public class SaveS
{
    static string path = Application.persistentDataPath + "/Save.json";

    public static void Save()
    {
        JSONObject obj = new JSONObject();

        JSONArray arr = new JSONArray();
        foreach (int time in StaticValues.time)
        {
            arr.Add(time);
        }

        File.WriteAllText(path, obj.ToString());
        Debug.Log(path);
    }

    public static void Load()
    {
        try
        {
            string jsonstr = File.ReadAllText(path);
            JSONObject obj = (JSONObject)JSON.Parse(jsonstr);

            for (int i = 0; i < obj["time"].Count; i++)
            {
                StaticValues.time[i] = obj["time"][i];
            }

            Debug.Log(path);
        }
        catch { Save(); Load(); }
    }
}
