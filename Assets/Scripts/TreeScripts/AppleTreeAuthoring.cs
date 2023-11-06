using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

public class AppleTreeAuthoring : MonoBehaviour
{
    public float speed;
    public float leftAndRightEdge;
    public float changeDirectionChance;
    public float spawnLocation;
    public GameObject applePrefab;
    public GameObject rotApplePrefab;
    public GameObject poisApplePrefab;
    
    private class AppleTreeBaker : Baker<AppleTreeAuthoring>
    {
        public override void Bake(AppleTreeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var treePropComponent = new AppleTreeProperties
            {
                Speed = authoring.speed,
                LeftAndRightEdge = authoring.leftAndRightEdge,
                ChangeDirectionChance = authoring.changeDirectionChance,
                SpawnLocation = authoring.spawnLocation,
                Random = Random.CreateFromIndex( ( uint )entity.Index )
            };

            // var mouseMoveComponent = new MoveWithMouse {
            //     move = true
            // };
            
            AddComponent( entity, treePropComponent );
            AddComponent<Tree>(entity);
            // AddComponent( entity, mouseMoveComponent );
        }
    }
}

public struct AppleTreeProperties : IComponentData
{
    public float Speed;
    public float LeftAndRightEdge;
    public float ChangeDirectionChance;
    public float3 SpawnLocation;

    public Random Random;
}

// tree tag
public struct Tree : IComponentData { }

// public struct MoveWithMouse: IComponentData {
//     public bool move;
// }