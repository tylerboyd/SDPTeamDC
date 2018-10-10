using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class UnitTests
{

    [Test]
    public void ScoreShouldIncreaseTest()
    {
        //Arrange
        var gameObject = new GameObject();
        gameObject.AddComponent<PlayerScore>();
        var score_increment = 200;
        var starting_score = 400;
        var expected_score = 600;

        //Act
        var new_score = gameObject.GetComponent<PlayerScore>().Score_Test(starting_score, score_increment);

        //Assert
        Assert.AreEqual(expected_score, new_score);
    }

    [Test]
    public void PlayerGoldShouldIncrease()
    {
        //Arrange
        var gameObject = new GameObject();
        var initial_gold = 80;
        var gold_increment = 20;
        var expected_gold = 100;
        gameObject.AddComponent<PlayerScore>();

        //Act
        var new_gold = gameObject.GetComponent<PlayerScore>().Gold_Test(initial_gold, gold_increment);

        //Assert
        Assert.AreEqual(expected_gold, new_gold);
    }

    [Test]
    public void PlayerTakesDamageTest()
    {
        //Arrange
        GameObject player = new GameObject();
        int health = 5;
        int enemyDamage = 1;
        int expectedHealth = 4;
        player.AddComponent<HealthSystem>();

        //Act
        var remainingHealth = player.GetComponent<HealthSystem>().Damage_Test(enemyDamage, health);

        //Assert
        Assert.That(remainingHealth, Is.EqualTo(expectedHealth));
    }

   
}
