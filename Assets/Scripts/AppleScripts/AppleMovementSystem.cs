using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct AppleMovementSystem : ISystem
{
    [ BurstCompile ]
    public void onCreate( ref SystemState state )
    {

    }
    
    [ BurstCompile ]
    public void OnUpdate(ref SystemState state)
    {
        foreach ( var ( transform, properties ) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<AppleProperties>>() )
        {
/*             var pos = transform.ValueRO.Position;
            var speed = properties.ValueRO.Speed;

            pos.x += speed * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position = pos;

            if ( pos.x < properties.ValueRO.BottomY )
            {
                // state.EntityManager.DestroyEntity( entity );
            }
 */
        }
    }
}