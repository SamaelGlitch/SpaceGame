using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        if (player != null)
        {
            healthText.text = player.GetCurrentHealth().ToString() + " HP";
        }
        else
        {
            healthText.text = "0 HP";
        }
    }
}
