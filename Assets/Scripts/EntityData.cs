using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/EntityData")]
public class EntityData : ScriptableObject
{
    public string entityName;
    public int damage;
    public float speed;
}
