using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    [SerializeField] private int level = 0;
   public void LoadNextLvl (int  lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadNextLvl(level);
    }

}
