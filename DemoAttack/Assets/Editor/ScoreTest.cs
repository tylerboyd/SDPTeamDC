using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreTest
{
    [Test]
    public void ScoreDoesIncrease()
    {
        //Arrange
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<PlayerScore>();
        var starting_score = 400;
        var expected_score = 600;

        //Act
        var new_score = gameObject.GetComponent<PlayerScore>().AddScore_Test(starting_score);

        //Assert
        Assert.AreEqual(expected_score, new_score);
    }

    [Test]
    public void GoldDoesIncrease()
    {
        //Arrange
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<PlayerScore>();
        var starting_gold = 230;
        var expected_gold = 250;

        //Act
        var new_gold = gameObject.GetComponent<PlayerScore>().AddGold_Test(starting_gold);

        //Assert
        Assert.AreEqual(expected_gold, new_gold);
    }
}
