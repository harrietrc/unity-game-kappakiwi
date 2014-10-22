using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
	[TestFixture]
	[Category("KiwiBird Tests")]
	internal class KiwiBirdTests
	{
		[Test]
		[Category("Teleport Tests")]
		public void TeleportRightToLeftTest()
		{
			Camera.main = new CameraMain ();
			Camera.main.camera = new CameraMainCamera ();
			Camera.main.camera.orthographicSize = 30f;
			MockKiwiBird kiwiBird = (MockKiwiBird)ScriptableObject.CreateInstance ("MockKiwiBird");
			kiwiBird.position = new Vector2 (22, 0);
			Vector2 originalPos = kiwiBird.position;
			kiwiBird.handleTeleport ();
			Assert.That(kiwiBird.position.x == -originalPos.x);
		}		

		[Test]
		[Category("Teleport Tests")]
		public void TeleportLeftToRightTest()
		{
			Camera.main = new CameraMain ();
			Camera.main.camera = new CameraMainCamera ();
			Camera.main.camera.orthographicSize = 30f;
			MockKiwiBird kiwiBird = (MockKiwiBird)ScriptableObject.CreateInstance ("MockKiwiBird");
			kiwiBird.position = new Vector2 (-22, 0);
			Vector2 originalPos = kiwiBird.position;
			kiwiBird.handleTeleport ();
			Assert.That(kiwiBird.position.x == -originalPos.x);
		}

		[Test]
		[Category("Teleport Tests")]
		public void TeleportRemainTest()
		{
			Camera.main = new CameraMain ();
			Camera.main.camera = new CameraMainCamera ();
			Camera.main.camera.orthographicSize = 30f;
			MockKiwiBird kiwiBird = (MockKiwiBird)ScriptableObject.CreateInstance ("MockKiwiBird");
			kiwiBird.position = new Vector2 (17, 0);
			Vector2 originalPos = kiwiBird.position;
			kiwiBird.handleTeleport ();
			Assert.That(kiwiBird.position.x == originalPos.x);
		}

		[Test]
		[Category("Enemy Tests")]
		public void FallingEnemyCollisionTest()
		{
			GameObject mockEnemy = new GameObject ("pref_falling_enemy");
			mockEnemy.tag = Tags.TAG_ENEMY;
			Collision2D collision2D = new Collision2D ();
			collision2D.gameObject = mockEnemy;
			MockKiwiBird kiwiBird = (MockKiwiBird)ScriptableObject.CreateInstance ("MockKiwiBird");
			kiwiBird.handleEnemyCollision (collision2D);
			Assert.That(kiwiBird.getDeathStatus() == true);
		}		

		[Test]
		[Category("Enemy Tests")]
		public void StationaryEnemyCollisionTest()
		{
			GameObject mockEnemy = new GameObject ("pref_stationary_enemy");
			mockEnemy.tag = Tags.TAG_ENEMY;
			Collision2D collision2D = new Collision2D ();
			collision2D.gameObject = mockEnemy;
			MockKiwiBird kiwiBird = (MockKiwiBird)ScriptableObject.CreateInstance ("MockKiwiBird");
			kiwiBird.handleEnemyCollision (collision2D);
			Assert.That(kiwiBird.getDeathStatus() == true);
		}		

		[Test]
		[Category("Enemy Tests")]
		public void ShootingEnemyCollisionTest()
		{
			GameObject mockEnemy = new GameObject ("Shooting_enemy");
			mockEnemy.tag = Tags.TAG_ENEMY;
			Collision2D collision2D = new Collision2D ();
			collision2D.gameObject = mockEnemy;
			MockKiwiBird kiwiBird = (MockKiwiBird)ScriptableObject.CreateInstance ("MockKiwiBird");
			kiwiBird.handleEnemyCollision (collision2D);
			Assert.That(kiwiBird.getDeathStatus() == true);
		}
	}
}
