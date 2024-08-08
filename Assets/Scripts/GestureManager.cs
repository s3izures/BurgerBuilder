using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    static public GestureManager Instance { get; private set; }
    [SerializeField] float touchTolerance = 25;
    Vector2 startPosition = Vector2.zero;
    Vector2 swipeDir = Vector2.zero;

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

    public bool OnTap(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            startPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            float distance = (touch.position - startPosition).magnitude;

            // Check against a threshold to make sure they didnt move enough to be a swipe
            if (distance <= touchTolerance)
            {
                Debug.Log("Tap!");
                return true;
            }
        }

        return false;
    }
    public bool OnSwipe(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            startPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            float distance = (touch.position - startPosition).magnitude;

            // Counts as swipe if this distance is matched or exceeded
            if (distance > touchTolerance)
            {
                swipeDir = (touch.position - startPosition).normalized;
                Debug.Log("Swipe!");
                return true;
            }
        }

        return false;
    }
    public Vector2 GetSwipeDir()
    {
        return swipeDir;
    }
}
