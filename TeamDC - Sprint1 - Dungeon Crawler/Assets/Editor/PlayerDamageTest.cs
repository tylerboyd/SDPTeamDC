using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerDamageTest {

    [Test]
    public void PlayerTakesDamage() {

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

    [Test]
    public void PlayerNotBelowZeroHealth()
    {

        //ARRANGE
        GameObject player = new GameObject();
        int health = 5;
        int enemyDamage = 7;
        int expectedHealth = 0;
        player.AddComponent<HealthSystem>();

        //ACT
        var remainingHealth = player.GetComponent<HealthSystem>().Damage_Test(enemyDamage, health);

        //ASSERT
        Assert.That(remainingHealth, Is.EqualTo(expectedHealth));
    }
}
