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

    [Header("Scene Switching")]
    [SerializeField] Animator animator;
    [SerializeField] Image fadeImage;
    private int targetScene = 0;

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
        animator.SetBool("Switch", false);
        fadeImage.raycastTarget = false;
    }

    /*================================================
     * SCENE SWITCHING
     * ===============================================*/

    public void ChangeScene(int index)
    {
        StartCoroutine(FadeSceneBack());
        targetScene = index;
        animator.SetBool("Switch", true);
        fadeImage.raycastTarget = true;
        SceneManager.LoadScene(targetScene);
    }
    IEnumerator FadeSceneBack()
    {
        while (IsTargetScene())
        {
            yield return new WaitUntil(IsTargetScene);
        }
        yield return new WaitForSeconds(0.5f);
        fadeImage.raycastTarget = false;
        animator.SetBool("Switch", false);
    }
    private bool IsTargetScene()
    {
        return SceneManager.GetActiveScene().buildIndex != targetScene;
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
