﻿using System;
using UnityEngine;

public class PlayerPrefSave : MonoBehaviour, ISystemSave
{
    public void Save(string countBlock, float time)
    {
        var oldTime = PlayerPrefs.GetFloat(countBlock);
        if (time < oldTime)
        {
            PlayerPrefs.SetFloat(countBlock, time);
        }
    }
    
    public BestScoreStruct Load(string countBlock, float currentTime)
    {
        var bestTime = PlayerPrefs.GetFloat(countBlock);
        return new BestScoreStruct(Int32.Parse(countBlock), currentTime, bestTime);
    }
}