using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardTests
{
    Board board;
    CheckboxStatus[] Checkboxes = new CheckboxStatus[24];

    [Test]
    public void CheckboxVerification()
    {
        board = GameObject.FindObjectOfType<Board>();
        board.CheckboxAssignation();

        for (int i = 0; i < 24; i++)
        { 
            Assert.AreEqual(i, board.Checkbox[i].checkboxIndex);
        }
    }
}
