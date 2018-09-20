using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tyler Boyd: 16951977

public class GameHandler : MonoBehaviour {

    public Transform pfHealthBar;
    


    private void Start()
    {
        //This code needs to go into the enemy and player classes
        //@TIM Check the PlayerHandler and EnemyHandler classes of the game I sent you to see how they implemented it
        HealthSystem healthSystem = new HealthSystem(100);
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }
}
