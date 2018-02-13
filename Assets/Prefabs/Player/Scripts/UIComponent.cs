using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComponent : MonoBehaviour {

	public PlayerComponent player;
	public Slider healthBar;
	public Text healthText;
	public Text levelText;

	// Use this for initialization
	void Start () {
		healthBar.maxValue = Character.InitialHealth;	
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = player.Health;
		healthText.text = "HP: " + player.Health + "/" + healthBar.maxValue;

		levelText.text = "Level: " + player.Level;
	}
}
