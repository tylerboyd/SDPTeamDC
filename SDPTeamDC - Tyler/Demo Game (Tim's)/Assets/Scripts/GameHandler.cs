using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tyler Boyd: 16951977

public class GameHandler : MonoBehaviour {

    public Transform pfHealthBar;

    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
        

        /*Debug.Log("Health: " + healthSystem.GetHealthPercentage() + "%");
        healthSystem.Damage(20);
        Debug.Log("Health: " +healthSystem.GetHealthPercentage() + "%");
        healthSystem.Heal(10);
        Debug.Log("Health: " + healthSystem.GetHealthPercentage() + "%");
        */

    }
}
