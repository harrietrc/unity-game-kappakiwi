using UnityEngine;

namespace UnityTest {
	public class Collision2D
	{
		public GameObject gameObject;
	}

	public class Screen
	{
		public static float width = 720;
		public static float height = 1024;
	}

	public static class Camera
	{
		public static CameraMain main;
	}

	public class CameraMain
	{
		public CameraMainCamera camera;
	}

	public class CameraMainCamera
	{
		public float orthographicSize = 30f;
	}
}
