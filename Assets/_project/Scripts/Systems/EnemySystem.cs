using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;

namespace Game.Scripts
{
    [UpdateAfter(typeof(EndFramePhysicsSystem))]
    public class EnemySystem : SystemBase
    {
        private const float DistanceDelta = 0.9f;

        private struct MovementRaycast
        {
            [ReadOnly] public PhysicsWorld PhysicsWorld;

            public bool CheckRay(float3 position, float3 direction, float3 currentDirection)
            {
                if (direction.Equals(-currentDirection))
                    return true;

                var ray = new RaycastInput()
                {
                    Start = position,
                    End = position + direction * DistanceDelta,
                    Filter = new CollisionFilter()
                    {
                        GroupIndex = 0,
                        BelongsTo = 1u << 1,
                        CollidesWith = 1u << 2
                    }
                };

                return PhysicsWorld.CastRay(ray);
            }
        }

        private Random _randomNumberGenerator = new Random(1234);

        protected override void OnUpdate()
        {
            var raycaster = new MovementRaycast()
            {
                PhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld
            };

            _randomNumberGenerator.NextInt();
            var randomNumberGenerator = _randomNumberGenerator;

            Entities
                .ForEach((ref MovableComponent movable, ref EnemyComponent enemy, in Translation translation) =>
                {
                    if (math.distance(translation.Value, enemy.PreviousCell) > DistanceDelta)
                    {
                        enemy.PreviousCell = math.round(translation.Value);

                        var directions = new NativeList<float3>(Allocator.Temp);

                        if (!raycaster.CheckRay(translation.Value, new float3(0, 0, -1), movable.Direction))
                        {
                            directions.Add(new float3(0, 0, -1));
                        }
                        
                        if (!raycaster.CheckRay(translation.Value, new float3(0, 0, 1), movable.Direction))
                        {
                            directions.Add(new float3(0, 0, 1));
                        }
                        
                        if (!raycaster.CheckRay(translation.Value, new float3(-1, 0, 0), movable.Direction))
                        {
                            directions.Add(new float3(-1, 0, 0));
                        }
                        
                        if (!raycaster.CheckRay(translation.Value, new float3(1, 0, 0), movable.Direction))
                        {
                            directions.Add(new float3(1, 0, 0));
                        }

                        movable.Direction = directions[randomNumberGenerator.NextInt(directions.Length)];

                        directions.Dispose();
                    }
                })
                .Schedule();
        }
    }
}
