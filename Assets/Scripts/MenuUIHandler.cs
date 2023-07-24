using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField input;
    public void StartGame()
    {
        GameManager.Instance.playerName = input.text;
        GameManager.Instance.StartGame();
    }
    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
