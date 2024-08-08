using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;
    private int score;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance)
        {
            Destroy(this);
        }

        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    /*================================================
     * SCORE
     * ===============================================*/

    public void AddScore(int amt)
    {
        score += amt;
    }
    public int GetScore()
    {
        return score;
    }
}
