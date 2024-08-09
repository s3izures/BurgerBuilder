using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float yeetForce = 1000;
    bool isActiveRightNow = true;

    private void Start()
    {
        isActiveRightNow = true;
        rb.simulated = false;
    }
    private void Update()
    {
        if (Input.touchCount == 1 && isActiveRightNow)
        {
            Touch touch = Input.GetTouch(0);

            if (GestureManager.Instance.OnTap(touch))
            {
                rb.simulated = true;
            }
            else if (GestureManager.Instance.OnSwipe(touch))
            {
                rb.simulated = true;
                rb.AddForce(new Vector2(GestureManager.Instance.GetSwipeDir().x * yeetForce, 0));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Finish burger
        if (GameManager.Instance.GetCurrentIngredient() == IngredientType.Type.TopBun && collision.gameObject.CompareTag("Ingredient") && isActiveRightNow)
        {
            GameManager.Instance.AddToList(IngredientType.Type.TopBun, false);
            GameManager.Instance.SubmitBurger();
        }
        else if (collision.gameObject.CompareTag("Ingredient") && isActiveRightNow)
        {
            IngredientSpawner.Instance.GenerateRandomIngredient();
            GameManager.Instance.AddToList(GameManager.Instance.GetCurrentIngredient(), false);
            isActiveRightNow = false;
        }
    }
}
