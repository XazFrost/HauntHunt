using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int requiredKillsForStar1 = 3;
    public int requiredKillsForStar2 = 5;
    public int requiredKillsForStar3 = 10;

    private int currentKills = 0;

    private void UpdateStarVisibility()
    {
        star1.SetActive(currentKills >= requiredKillsForStar1);
        star2.SetActive(currentKills >= requiredKillsForStar2);
        star3.SetActive(currentKills >= requiredKillsForStar3);
    }

    public void IncreaseKillCount()
    {
        currentKills++;
        UpdateStarVisibility();
    }
}
