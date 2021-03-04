using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public Text text;
    int points = 0;
    public GameObject trigger;

    void Update()
    {
        text.text = points.ToString();
    }
    public void addPoint(int Point)
    {
        points ++;
    }
    public void restart()
    {

        SceneManager.LoadScene("Leve_One");
    }
}
