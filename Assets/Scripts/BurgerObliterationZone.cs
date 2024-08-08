using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerObliterationZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient"))
        {
            Destroy(collision.gameObject);
        }
    }
}
