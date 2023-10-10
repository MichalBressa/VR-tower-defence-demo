using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int moneyOnStart = 200;

    public static int lives;
    public int livesOnStart = 15;

    public Text moneyTextField;
    public Text livesTextField;


    void Start()
    {
        money = moneyOnStart;
        lives = livesOnStart;
    }

    private void FixedUpdate()
    {
        moneyTextField.text = money.ToString() + "$";
        livesTextField.text = lives.ToString() + " LIVES";

        
    }


    public static void PlayerDead()
    {
        Debug.Log("no more lives");
    }

}
