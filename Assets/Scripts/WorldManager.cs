using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{

    public enum Scene
    {
        Title,
        MainLevel,
    }
   
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
