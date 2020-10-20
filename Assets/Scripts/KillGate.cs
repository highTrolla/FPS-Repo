using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGate : MonoBehaviour
{
    public float unlockCount;

    void Update()
    {
        if (Enemy.deathCount >= unlockCount)
        {
            Destroy(this.gameObject);
        }
    }
}
