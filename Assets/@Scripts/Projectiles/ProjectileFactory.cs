using Core.Services.AssetManagement;
using Data;
using NTC.Global.Pool;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileFactory
    {
        private readonly ProjectileSpawner _spawner;

        public ProjectileFactory(ProjectileSpawner spawner)
        {
            _spawner = spawner;
        }

        public Projectile Create(ProjectileConfig projectile, Vector3 position, Quaternion quaternion)
        {
            Projectile instance = NightPool.Spawn(AddressablesProvider.LoadPrefab<Projectile>(projectile.Prefab), position, quaternion);
            instance.Inject(projectile.Data, _spawner);
            return instance;
        }

        public void Destroy(Projectile projectile)
        {
            NightPool.Despawn(projectile);
        }
    }
}