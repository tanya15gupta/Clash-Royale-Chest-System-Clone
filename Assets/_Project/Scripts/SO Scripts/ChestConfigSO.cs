using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Chest Configurations", order = 2)]
public class ChestConfigSO : ScriptableObject
{
	public ChestConfig[] ChestConfigs;

	[Serializable]
	public class ChestConfig
	{
		public ChestTypes ChestType;
		public ChestSO ChestScriptableObject;
	}
}
