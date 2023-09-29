using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject deathPanel = null;
    public Player player {get; set;}
    public static UIManager instance;

    private void Awake() {
        instance = this;    
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Respawn()
    {
        deathPanel.SetActive(false);
        player.Respawn();
    }
}
