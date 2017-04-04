using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

//[TestFixture]
//public class ScoreMasterTest {
//	
//	[Test]
//	public void T00PassingTest () {
//		Assert.AreEqual (1, 1);
//	}
//
//	[Test]
//	public void T01Bowl1 () {
//		int[] rolls = { 1 };
//		string rollsString = "1";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T02Bowl12 () {
//		int[] rolls = { 1, 2 };
//		string rollsString = "12";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T03Bowl1291 () {
//		int[] rolls = { 1, 2,9,1 };
//		string rollsString = "129/";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T04Bowl10 () {
//		int[] rolls = {10};
//		string rollsString = "X ";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T05Bowl9155371733101 () {
//		int[] rolls = {9,1,5,5,3,7,1,7,3,3,10,1};
//		string rollsString = "9/5/3/1733X 1";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T06SpareFrame10 () {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,1};
//		string rollsString = "1111111111111111111/1";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T07StrikeFrame10 () {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
//		string rollsString = "111111111111111111X11";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//
//	[Test]
//	public void T08Bowl0 () {
//		int[] rolls = {0};
//		string rollsString = "-";
//		Assert.AreEqual(rollsString, ScoreDisplay.Formatrolls(rolls.ToList()));
//	}
//}
