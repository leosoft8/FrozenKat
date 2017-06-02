using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoinsController : MonoBehaviour {

	private static Text s_TotalCoinsText;
	private static int s_TotalCoins;
	private static Dictionary<string, int> m_CollectionableList;

	void Awake () {
		m_CollectionableList = new Dictionary<string, int> ();
		s_TotalCoinsText = GetComponentInChildren<Text> ();
		s_TotalCoins = 0;
	}

	void Start () {
		s_TotalCoinsText.text = s_TotalCoins.ToString();
		this.ChargeCollectionableList ();
	}

	public static void UpdateCoins (string CollectableName) {
		int AuxCoins = 0;
		m_CollectionableList.TryGetValue (CollectableName, out AuxCoins);
		s_TotalCoins += AuxCoins;
		s_TotalCoinsText.text = s_TotalCoins.ToString();
	}

	public int GetTotalCoins () {
		return s_TotalCoins;
	}

	private void ChargeCollectionableList (){
		m_CollectionableList.Add ("Fridge", 100);
		m_CollectionableList.Add ("CatFood", 50);
		m_CollectionableList.Add ("Ham", 75);
		m_CollectionableList.Add ("Sushi", 120);
	}
}
