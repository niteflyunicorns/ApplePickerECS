using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class AppleAuthoring : MonoBehaviour
{
    public float bottomY;
    public float speed;
    public float dropRate;
    // need to get sceneName or difficulty somehow

    private class AppleBaker : Baker<AppleAuthoring>
    {
        public override void Bake( AppleAuthoring authoring )
        {
            var entity = GetEntity( TransformUsageFlags.Dynamic );
            var applePropComponent = new AppleProperties
            {
                BottomY = authoring.bottomY,
                Speed = authoring.speed,
                DropRate = authoring.dropRate
            };

            AddComponent( entity, applePropComponent );
        }
    }
}

public struct AppleProperties : IComponentData
{
    public float BottomY;
    public float Speed;
    public float DropRate;
    public float StartPos;
}