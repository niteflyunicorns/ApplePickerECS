using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial struct SceneManagementSystem : ISystem
{
    [ BurstCompile ]
    public void OnCreate( ref SystemState state )
    {

    }

    [ BurstCompile ]
    public void OnUpdate( ref SystemState state )
    {
        // instantiate numBaskets
        foreach ( var ( transform, properties ) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<SceneProperties>>() )
        {
            for ( int i = 0; i < properties.ValueRO.NumBaskets; i++ ) {
                Entity basketInstance = state.EntityManager.Instantiate( properties.ValueRO.BasketPrefab );

                var pos = new float3( 0f, 0f, 0f );
                pos.y = properties.ValueRO.BasketBottomY + ( properties.ValueRO.BasketSpacingY * i );
                transform.ValueRW.Position = pos;
                properties.ValueRW.BasketNumber = i;

            }
        }

        // detect collision from apple

        // if collided:
            // destroy apple
            // add to score

        // if apple < bottomY
            // destroy basket
            // reset scene

        // if numBaskets < 0
            // reload scene
    }
}