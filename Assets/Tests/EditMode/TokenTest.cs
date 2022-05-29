using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TokenTest
{
    GameManager GM;
    Token token;
    GameObject t;
    // A Test behaves as an ordinary method
    [Test]
    public void TestSetTokenOwner()
    {
        t.AddComponent<Token>();
        t.AddComponent<MeshRenderer>();
        t.GetComponent<Token>().SetTokenOwner(0);
        Assert.Equals(0, t.GetComponent<Token>().playerIndex);
        
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
  
}
