using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Chest Scriptable Objects", order = 1)]
public class ChestSO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private float unlockDuration;
    [SerializeField] private int minGems;
    [SerializeField] private int maxGems;
    [SerializeField] private int minCoins;
    [SerializeField] private int maxCoins;
    [SerializeField] private int unlockAmount;
    [SerializeField] private Texture chestTexture;

    public string Name              { get { return name; } }
    public float UnlockDuration     { get { return unlockDuration; } }
    public int MinGems              { get { return minGems; } }
    public int MaxGems              { get { return maxGems; } }
    public int MinCoins             { get { return minCoins; } }
    public int MaxCoins             { get { return maxCoins; } }
    public int UnlockAmount         { get { return unlockAmount; } }
    public Texture ChestTexture      { get { return chestTexture; } }
}
