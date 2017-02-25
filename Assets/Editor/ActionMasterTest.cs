using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster actionMaster;

    [SetUp]
    public void Setup(){
       actionMaster = new ActionMaster();
    }

    [Test]
	public void PassingTest() {
	    Assert.AreEqual (1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn(){
        Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy(){
		Assert.AreEqual (tidy, actionMaster.Bowl (8));
	}

    [Test]
    public void T03Bowl28ReturnsEndTurn(){
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }
}