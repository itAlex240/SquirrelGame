using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public Text text;
    int points = 0;

    void Update()
    {
        text.text = points.ToString();
    }
    public void addPoint(int Point)
    {
        points ++;
    }
}
