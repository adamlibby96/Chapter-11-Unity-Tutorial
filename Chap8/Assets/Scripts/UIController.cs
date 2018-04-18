using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField] private Text healthLabel;
    [SerializeField] private InventoryPopup popup;
    
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnHealthUpdated);
    }

    // Use this for initialization
    void Start () {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        popup.gameObject.SetActive(false);
        OnHealthUpdated();
	}
    
    private void OnHealthUpdated()
    {
        string message = "Health: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
        healthLabel.text = message;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);
            popup.Refresh();
        }
    }
}
