using UnityEngine;

namespace ChestSystem
{
	public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
	{
		private static T instance;
		public static T Instance { get { return instance; } }

		private void Awake()
		{
			if (instance == null)
			{
				instance = (T)this;
				return;
			}
			Destroy(instance);
		}
	}
}
