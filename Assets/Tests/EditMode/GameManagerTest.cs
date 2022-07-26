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
    public void TestNexturn()//prueba si pasa al siguiente turno
    {
        gameManager.currentPlayerIndex = 1;//asigna el primer turno al jugador 2
        gameManager.NextTurn();//ahora es el turno del jugador de indice 1
        Assert.AreEqual(0,gameManager.currentPlayerIndex);
    }

    [Test]
    public void TestVictory()//comprobar que 
    {
        gameManager.currentPlayerIndex = 0;//turno del jugador 1
        gameManager.availableTokens = new int[] {9,2};//jugador 1 tine 9 fichas , jugador 2 tiene 2 fichas 
        Assert.AreEqual(true, gameManager.Victory());
    }
    /*
     [Test]
     public void TestSpawnToken()//prueba de generación de las fichas 
     {
         gameManager.maxTokens = 10; //cantidad máxima de fichas por jugador
         gameManager.spawnTokens();//instancia todas las fichas
         Assert.AreEqual(20,gameManager.arrayToken.Length);
     }*/
}
