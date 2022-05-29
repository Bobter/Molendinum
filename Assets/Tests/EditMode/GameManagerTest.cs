using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTest
{
    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    // A Test behaves as an ordinary method
    [Test]
    public void TestNexturn()//prueba de siguiente turno
    {
        gameManager.currentPlayerIndex = 1;
        gameManager.NextTurn();
        Assert.AreEqual(0,gameManager.currentPlayerIndex);
    }

    [Test]
    public void TestVictory()
    {
        gameManager.currentPlayerIndex = 0;//turno del jugador 1
        gameManager.availableTokens = new int[] {9,2};//jugador 1 tine 9 fichas , jugador 2 tiene 2 fichas 
        Assert.AreEqual(true, gameManager.Victory());
    }
}
