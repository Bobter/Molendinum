using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicTest
{
    Board boardTest;
    Logic logicTest;
    GameManager GMTest;
    CheckboxStatus[] CheckboxTest = new CheckboxStatus[24];



    [Test]
    // El jugador forma un molino
    public void hasaMill()
    {

        boardTest = GameObject.FindObjectOfType<Board>();
        logicTest = GameObject.FindObjectOfType<Logic>();
        logicTest.Rules();

        for (int i = 0; i < 24; ++i)
        {
            CheckboxTest[i] = new CheckboxStatus();
            CheckboxTest[i].checkboxIndex = i;
        }
        boardTest.Checkbox = CheckboxTest;

        //Haciendo que el molino vertical formado por las posciciones 2, 14 y 23
        //Pertenezcan a un solo jugador
        boardTest.Checkbox[2].tokenPlayerIndex = 0;
        boardTest.Checkbox[14].tokenPlayerIndex = 0;
        boardTest.Checkbox[23].tokenPlayerIndex = 0;
        int end = 23;
        Assert.AreEqual(true, logicTest.Mill(end, boardTest, 0));
    }

    [Test]
    //No se forma molino porque una de las casillas no le pertenece al jugador actual
    public void NOhasaMill()
    {
        boardTest = GameObject.FindObjectOfType<Board>();
        logicTest = GameObject.FindObjectOfType<Logic>();
        logicTest.Rules();

        for (int i = 0; i < 24; ++i)
        {
            CheckboxTest[i] = new CheckboxStatus();
            CheckboxTest[i].checkboxIndex = i;
        }
        boardTest.Checkbox = CheckboxTest;

        //Haciendo que el molino horizontal formado por las posciciones 6, 7 y 8
        //Casilla ocupada por otro jugador 
        boardTest.Checkbox[0].tokenPlayerIndex = 1; //casilla pertenece a otro jugador
        boardTest.Checkbox[1].tokenPlayerIndex = 0;
        boardTest.Checkbox[2].tokenPlayerIndex = 0;
        int end = 0;
        Assert.AreEqual(false, logicTest.Mill(end, boardTest, 1));
    }
    [Test]
    //Movimiento hacia una casilla ocupada
    public void NOValidMovement()
    {
        boardTest = GameObject.FindObjectOfType<Board>();
        logicTest = GameObject.FindObjectOfType<Logic>();

        for (int i = 0; i < 24; ++i)
        {
            CheckboxTest[i] = new CheckboxStatus();
            CheckboxTest[i].checkboxIndex = i;
        }
        boardTest.Checkbox = CheckboxTest;

        //Movimiento no válido ya que va a una casilla ya ocupada
        //siendo el inicio y final 2 vecinos
        int begin = 2;
        int end = 1;
        //Casilla final ocupada por el jugador 0
        boardTest.Checkbox[end].tokenPlayerIndex = 0;
        //Siendo el turno de 1
        Assert.AreEqual(false, logicTest.ValidMovement(begin, end, boardTest, 1));
    }

    [Test]
    //Vuelo activado
    public void Fly()
    {
        boardTest = GameObject.FindObjectOfType<Board>();
        logicTest = GameObject.FindObjectOfType<Logic>();
        GMTest = GameObject.FindObjectOfType<GameManager>();
        //Movimiento válido ya que el jugador tiene 3 fichas 
        //el inicio y final NO son vecinos
        int begin = 3;
        int end = 17;
        //Jugador 0
        int CurrentPlayer = 0;
        GMTest.availableTokens[CurrentPlayer] = 3;
        Assert.AreEqual(true, logicTest.ValidMovement(begin, end, boardTest, CurrentPlayer));
    }

    [Test]
    //Movimiento valido ya que se mueve hacia un vecino
    public void canMove()
    {
        boardTest = GameObject.FindObjectOfType<Board>();
        logicTest = GameObject.FindObjectOfType<Logic>();

        for (int i = 0; i < 24; ++i)
        {
            CheckboxTest[i] = new CheckboxStatus();
            CheckboxTest[i].checkboxIndex = i;
        }
        boardTest.Checkbox = CheckboxTest;

        // Movimiento válido 
        //el inicio y final SON vecinos
        int begin = 16;
        int end = 19;
        //Jugador 0
        int CurrentPlayer = 0;
        boardTest.Checkbox[end].tokenPlayerIndex = -1;
        Assert.AreEqual(true, logicTest.ValidMovement(begin, end, boardTest, CurrentPlayer));
    }
}
