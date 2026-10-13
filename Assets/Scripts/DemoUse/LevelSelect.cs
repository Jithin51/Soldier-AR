using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   public void PlayOnRoom()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayOnTable()
    {
        SceneManager.LoadScene(2);
    }
}
