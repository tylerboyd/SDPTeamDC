using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreTest {

    [Test]
    public void ScoreShouldIncreaseTest()
    {
        PlayerScore playerScore = new PlayerScore();
        var originalScore = playerScore.score;

        playerScore.SendMessage("AddScore");

        Assert.AreEqual(originalScore + 200, playerScore.score);
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    /*[UnityTest]
    public IEnumerator ScoreTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        var score = GameObject.FindGameObjectWithTag("Hero");


        Assert.AreEqual(200, score);

        yield return null;
    }*/
}
