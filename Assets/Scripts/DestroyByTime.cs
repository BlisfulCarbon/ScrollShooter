using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float destroyTime = 0;
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
