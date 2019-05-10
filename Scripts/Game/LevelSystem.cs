using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
	public static int level = 1;
	private int exp = 0;
	private int requireExp = 30;

    public static bool promoted = false;

	void Start()
    {   
		UpdateUI();
	}


    void UpdateUI()
    {
		float percentage = (float) exp / (float) requireExp;	
	}

	public int GetLevel()
    {
		return level;
	}

	public void GiveExp(int amount)
    {
		exp += amount;

		CheckLevelUp();
	}

	void CheckLevelUp()
    {
        promoted = false;

        if (exp >= requireExp)
        {
			exp = exp - requireExp;
			requireExp += 50;
			level++;
            promoted = true;
            GameObject.FindGameObjectWithTag("promoter").GetComponent<PlayerLevelManager>().promotePlayer();
			CheckLevelUp();
		}

        UpdateUI();
	}

}
