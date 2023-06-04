using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    public static SaveLoadManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SaveInt(string key,int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void Savefloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveBool(string key, bool value) 
    {
        int temp = value == true? 1 : 0;
        PlayerPrefs.SetInt(key, temp);
    }

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public int LoadInt(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else
        {
            Debug.LogError($"<SaveLoadManager> No key {key} found");
            return -1;
        }
    }

    public float LoadFloat(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }
        else
        {
            Debug.LogError($"<SaveLoadManager> No key {key} found");
            return -1;
        }
    }

    public bool LoadBool(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key) == 1 ? true : false;
        }
        else
        {
            Debug.LogError($"<SaveLoadManager> No key {key} found");
            return false;
        }
    }

    public string LoadString(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }
        else
        {
            Debug.LogError($"<SaveLoadManager> No key {key} found");
            return "";
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Clear PlayerPrefs")]
    void ClearPlayerPrefes()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("<SaveLoadManager> Cleared PlayerPrefes");
    }
#endif

}
