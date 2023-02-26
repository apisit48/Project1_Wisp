using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button l1;
    public Button l2;
    public Button l3;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        l1 = root.Q<Button>("Level1");
        l2 = root.Q<Button>("Level2");
        l3 = root.Q<Button>("Level3");

        l1.clicked += L1ButtonPressed;
        l2.clicked += L2ButtonPressed;
        l3.clicked += L3ButtonPressed;
    }

    void L1ButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    void L2ButtonPressed()
    {
        SceneManager.LoadScene("Level2");
    }

    void L3ButtonPressed()
    {
        SceneManager.LoadScene("Level3");
    }
}
