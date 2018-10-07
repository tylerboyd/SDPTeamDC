using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerHealTest
{

    [Test]
    public void PlayerCanHeal()
    {
        //ARRANGE
        GameObject player = new GameObject();
        int health = 2;
        int maxHealth = 7;
        int playerHealing = 3;
        int expectedHealth = 5;
        player.AddComponent<HealthSystem>();

        //ACT
        var remainingHealth = player.GetComponent<HealthSystem>().Heal_Test(playerHealing, health, maxHealth);

        //ASSERT
        Assert.That(remainingHealth, Is.EqualTo(expectedHealth));
    }

    [Test]
    public void PlayerNotHealAboveMax()
    {
        //ARRANGE
        GameObject player = new GameObject();
        int health = 4;
        int maxHealth = 7;
        int playerHealing = 6;
        int expectedHealth = 7;
        player.AddComponent<HealthSystem>();

        //ACT
        var remainingHealth = player.GetComponent<HealthSystem>().Heal_Test(playerHealing, health, maxHealth);

        //ASSERT
        Assert.That(remainingHealth, Is.EqualTo(expectedHealth));
    }
}