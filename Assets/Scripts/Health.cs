using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite LifeSprite;
    public Sprite DeadSprite;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }
            if (i < health)
            {
                hearts[i].sprite = LifeSprite;
            }
            else
            {
                hearts[i].sprite = DeadSprite;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }

        }
    }

}
