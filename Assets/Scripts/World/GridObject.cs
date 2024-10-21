using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace World
{
    public class GridObject : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        
        [Button]
        private void Snap()
        {
            var cellSize = tilemap.cellSize;
            var meshSize = GetComponent<MeshFilter>().sharedMesh.bounds.size;

            var corner = transform.position;
            corner.x -= (meshSize.x * transform.localScale.x) * 0.5f;
            corner.z -= (meshSize.z * transform.localScale.z) * 0.5f;
            corner.x += cellSize.x * 0.5f;
            corner.z += cellSize.x * 0.5f;

            var cellPos = tilemap.WorldToCell(corner);
            var worldPos = tilemap.CellToWorld(cellPos);
            
            worldPos.y = (meshSize.y * transform.localScale.y) * 0.5f;
            worldPos.x += (meshSize.x * transform.localScale.x) * 0.5f;
            worldPos.z += (meshSize.z * transform.localScale.z) * 0.5f;
            
            transform.position = worldPos;
        }
    }
}