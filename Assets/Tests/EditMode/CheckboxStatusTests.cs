using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CheckboxStatusTests
{
    Board board;
    CheckboxStatus checkboxstatus;
    CheckboxStatus[] Checkboxes = new CheckboxStatus[24];

    [Test]
    public void TagVerification()
    {
        board = GameObject.FindObjectOfType<Board>();
        board.CheckboxAssignation();

        for (int i = 0; i < 24; i++)
        {
            Assert.True(board.Checkbox[i].CompareTag("box"));
        }
    }

    [Test]
    public void AvailabilityVerificationAtStart()
    {
        checkboxstatus = GameObject.FindObjectOfType<CheckboxStatus>();
        checkboxstatus.main();

        Assert.AreEqual(true, checkboxstatus.checkboxAvailable);
    }

    [Test]
    public void tokenPlayerIndexAtStart()
    {
        checkboxstatus = GameObject.FindObjectOfType<CheckboxStatus>();
        checkboxstatus.main();

        Assert.AreEqual(-1, checkboxstatus.tokenPlayerIndex);
    }

}
