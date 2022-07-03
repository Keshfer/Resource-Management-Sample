using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public Color TeamColor;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            
            
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }

    }
}
