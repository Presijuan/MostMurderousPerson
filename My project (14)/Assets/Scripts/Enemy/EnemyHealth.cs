using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyAI Life;
    public GameObject deathEffect;
    public GameObject healthBar;
    public GameObject healthBarBG;

    void Update()
    {
        healthBar.transform.localScale = new Vector3(Life.vida / 100, 1, 1);
    }
    
}
