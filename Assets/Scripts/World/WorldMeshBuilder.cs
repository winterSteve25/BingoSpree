using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace World
{
    public class WorldMeshBuilder : MonoBehaviour
    {
        [SerializeField] private MeshCollider meshCollider;
        [SerializeField] private Tilemap tilemap;
        
        [Button]
        private void Rebuild()
        {
            var mesh = new Mesh();

            tilemap.CompressBounds();
            var bound = tilemap.cellBounds;

            var topLeft = tilemap.CellToWorld(new Vector3Int(bound.xMin, bound.yMax));
            var topRight = tilemap.CellToWorld(new Vector3Int(bound.xMax, bound.yMax));
            var botLeft = tilemap.CellToWorld(new Vector3Int(bound.xMin, bound.yMin));
            var botRight = tilemap.CellToWorld(new Vector3Int(bound.xMax, bound.yMin));

            mesh.vertices = new []
            {
                topLeft,
                topRight,
                botLeft,
                botRight
            };

            mesh.triangles = new[]
            {
                2, 0, 3,
                0, 1, 3
            };

            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            meshCollider.sharedMesh = mesh;
        }
    }
}