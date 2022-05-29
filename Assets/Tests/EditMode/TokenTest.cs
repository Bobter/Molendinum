using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TokenTest
{
    GameManager GM;
    Token token;
    // A Test behaves as an ordinary method
    [Test]
    public void TestGetCurrentPlayer()//prueba de obtención del indice del jugador actual
    {   GM= GameObject.FindObjectOfType<GameManager>();
        GM.currentPlayerIndex = 1;
        token = GameObject.FindObjectOfType<Token>();
        token.gameManager = GM;
        token.SetTokenOwner(1);
        Assert.AreEqual(1,token.GetCurrentPlayer());
    }
    [Test]
    public void TestSetTokenOwner0()//pueba de función de inicialización de la ficha
    {
        token = GameObject.FindObjectOfType<Token>();
        token.SetTokenOwner(0);
        Assert.AreEqual(Color.black, token.tokenMeshColor);
    }

    [Test]
    public void TestSetTokenOwner1()//pueba de función de inicialización de la ficha
    {
        token = GameObject.FindObjectOfType<Token>();
        token.SetTokenOwner(1);
        Assert.AreEqual(Color.white, token.tokenMeshColor);
    }

}
