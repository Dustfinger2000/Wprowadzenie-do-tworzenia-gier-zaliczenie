using UnityEngine;

[CreateAssetMenu(fileName="New Character", menuName = "Characters")]
public class Stats : ScriptableObject
{
	new public string name= "new character";
	public CharacterType Type;
	public float baseHealth;
	public float baseSpeed;
	public float baseRotationSpeed;
	public float baseArmor;
	public float baseAttackStrength;
	public float baseAttackSpeed;
	public float baseEnergy;
}
public enum CharacterType{Player,NPC,Enemy};