using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerDamageTest {

    [Test]
    public void PlayerTakesDamage_Test() {
        // Use the Assert class to test conditions.

        //ARRANGE
        GameObject player = new GameObject();
        int health = 5;
        int enemyDamage = 1;
        int expectedHealth = 4;
        player.AddComponent<HealthSystem>();

        //ACT
        var remainingHealth = player.GetComponent<HealthSystem>().Damage_Test(enemyDamage, health);

        //ASSERT
        Assert.That(remainingHealth, Is.EqualTo(expectedHealth));
    }
}
