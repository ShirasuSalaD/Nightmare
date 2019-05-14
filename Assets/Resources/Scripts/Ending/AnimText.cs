using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimText : MonoBehaviour
{
    public Text text;

    void TextReset()
    {
        text.text = "";
    }

    void Text1()
    {
        text.text = "うわああ！";
    }

    void Text2()
    {
        text.text = "(夢…か…)";
    }
}
