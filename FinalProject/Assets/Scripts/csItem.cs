﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csItem : MonoBehaviour {
	public GameObject[] itemPrefabs = new GameObject[3];
	public GameObject itemSpawn;
	GameObject item;

	int itemType;

	// Use this for initialization
	void Start () {
		itemType = Random.Range (0, 3);
		getItem ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.Log(itemPrefabs[0]+" "+itemPrefabs[1]+" "+itemPrefabs[2]);
		Debug.Log (item.name);
	}

	void getItem(){
		//UI에 아이템 생성
		//item = Instantiate(itemPrefabs[itemType], itemSpawn.transform);

	}
}