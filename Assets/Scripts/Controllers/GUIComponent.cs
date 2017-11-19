using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIComponent : MonoBehaviour {

	public GameObject player;
	public Button meleeButton;
	public Button rangedButton;

	void Start()
	{
		meleeButton.onClick.AddListener (delegate() {SetFighterType(new MeleeFighter());});
		rangedButton.onClick.AddListener (delegate() {SetFighterType (new RangedFighter());});
	}

	// Use this for initialization
	private void OnGUI()
	{
		
	}

	private void SetFighterType(Fighter fighterSelected)
	{
		var playerCharacter = player.GetComponent<Character> ();
		playerCharacter.Fighter = fighterSelected;

		this.gameObject.SetActive (false);

		var playerComponent = player.GetComponent<PlayerComponent> ();
		playerComponent.Enabled = true;
	}
}
