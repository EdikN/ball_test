using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch : MonoBehaviour
{
    public void score() {
        SceneManager.LoadScene("best_score");
    }
    public void menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void main()
    {
        SceneManager.LoadScene("main");
    }
}
