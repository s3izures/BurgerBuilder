using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;
    private int score = 0;
    [SerializeField] TextMeshProUGUI totalScore;
    [SerializeField] TextMeshProUGUI remark;
    [SerializeField] string fantasticRemark;
    [SerializeField] string goodRemark;
    [SerializeField] string badRemark;
    [SerializeField] string godawfulRemark;

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
    }

    private void Start()
    {
        //Generate order and random ingredient
        OrderGenerator.Instance.GenerateRandomOrder();
        IngredientSpawner.Instance.GenerateRandomIngredient();

        remark.enabled = false;
    }

    private void Update()
    {
        totalScore.text = score.ToString();
        if (stackList.Count > 8)
        {
            StackFull();
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

    /*================================================
     * INGREDIENT + ORDER STUFF
     * ===============================================*/

    List<IngredientType.Type> orderList = new List<IngredientType.Type>();
    List<IngredientType.Type> stackList = new List<IngredientType.Type>();
    IngredientType.Type currentIngredient;

    public void AddToList(IngredientType.Type ord, bool isOrder)
    {
        if (isOrder)
        {
            orderList.Add(ord);
        }
        else
        {
            stackList.Add(ord);
        }
    }
    public void ClearList(bool isOrder)
    {
        if (isOrder)
        {
            orderList.Clear();
        }
        else
        {
            stackList.Clear();
        }
    }
    public void SetCurrentIngredient(IngredientType.Type type)
    {
        currentIngredient = type;
    }
    public IngredientType.Type GetCurrentIngredient()
    {
        return currentIngredient;
    }
    public int CheckListCorrects()
    {
        int corrects = 0;

        for (int i = 0; i < stackList.Count; i++)
        {
            if (i < orderList.Count)
            {
                if (stackList[i] == orderList[i])
                {
                    Debug.Log("Correct!");
                    corrects++;
                }
                else
                {
                    Debug.Log("THE LAMB IS RAW");
                    corrects--;
                }
            }
            else
            {
                Debug.Log("NO LAMB SAUCE???");
                corrects--;
            }    
        }

        if (stackList.Count < orderList.Count)
        {
            corrects -= orderList.Count - stackList.Count;
        }

        return corrects;
    }
    public void StackFull()
    {
        remark.enabled = true;
        remark.text = "Stack full";

        //Submit
        StartCoroutine(BurgerDestroyer());
    }
    public void SubmitBurger()
    {
        //Do checks
        int muliplier = CheckListCorrects();

        remark.enabled = true;
        if (muliplier == orderList.Count + 1)
        {
            remark.text = fantasticRemark;
        }
        else if (muliplier > 1)
        {
            remark.text = goodRemark;
        }
        else if (muliplier == 1)
        {
            remark.text = badRemark;
        }
        else
        {
            remark.text = godawfulRemark;
        }

        AddScore(muliplier * 10);

        //Submit
        StartCoroutine(BurgerDestroyer());
    }
    IEnumerator BurgerDestroyer()
    {
        yield return new WaitForSeconds(3);

        remark.enabled = false;
        ClearList(false);
        ClearList(true);
        OrderGenerator.Instance.RefreshOrder();
        IngredientSpawner.Instance.ClearIngredients();
        IngredientSpawner.Instance.GenerateRandomIngredient();
    }
}
