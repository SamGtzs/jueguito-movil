using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Slider musicSlider, fxSlider;

    public AudioSource audioSource;

    void Start()
    {
        string rute = Application.dataPath + "/StreamingAssets/Volume.json";

        string json = File.ReadAllText(rute);

        MusicClass volume = JsonUtility.FromJson<MusicClass>(json);

        musicSlider.value = volume.Music;
        audioSource.volume = volume.Music;

    }

    void Update()
    {
        audioSource.volume = musicSlider.value;
    }

    public void UpdateVolume()
    {
        string rute = Application.dataPath + "/StreamingAssets/Volume.json";

        MusicClass volume = new MusicClass(musicSlider.value, fxSlider.value);

        string json = JsonUtility.ToJson(volume, true);

        File.WriteAllText(rute, json);
    }
}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
