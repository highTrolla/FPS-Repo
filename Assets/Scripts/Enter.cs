using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{

    public bool title;

    private void Start()
    {
        title = true;
    }


    void Update()
    {
        if (title = true && Input.GetKeyDown(KeyCode.Space))
        {
            print("gogo");
            title = false;
            WorldManager.Load(WorldManager.Scene.MainLevel);
        }
    }
}
