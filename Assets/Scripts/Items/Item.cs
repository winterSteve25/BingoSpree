using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "New Item", fileName = "New Item")]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Rarity Rarity { get; private set; }
    }
}