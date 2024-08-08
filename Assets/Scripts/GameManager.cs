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

    private void Start()
    {
        //Generate order and random ingredient
        OrderGenerator.Instance.GenerateRandomOrder();
        IngredientSpawner.Instance.GenerateRandomIngredient();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (GestureManager.Instance.OnSwipe(touch))
            {
                OrderGenerator.Instance.ClearOrder();
                OrderGenerator.Instance.GenerateRandomOrder();
            }
            else if (GestureManager.Instance.OnTap(touch))
            {

            }
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
