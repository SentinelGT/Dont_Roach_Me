using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
