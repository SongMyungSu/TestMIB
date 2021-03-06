﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSingleton : MonoBehaviour
{
    public static GameSingleton Instance = null;
    public GlobalTypes.GameKind GameKind = GlobalTypes.GameKind.Sudda;

    private string GetArg(string name)
    {
        string[] Args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < Args.Length; ++i)
        {
            if(Args[i].ToLower() == name && Args.Length > i + 1)
            {
                return Args[i + 1];
            }
        }

        return null;
    }

    private void Init()
    {
        string FindGameKind = GetArg("gamekind");
        if (FindGameKind != null)
        {
            try
            {
                GameKind = (GlobalTypes.GameKind)System.Enum.Parse(typeof(GlobalTypes.GameKind), FindGameKind, true);
            }
            catch (System.Exception e)
            {
                // TODO: Assert 작업 해야함.
            }
        }
        else
        {
            // TODO: Assert 작업 해야함.
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            Init();

            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
