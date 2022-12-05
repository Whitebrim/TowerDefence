using Projectiles;
using UnityEngine;

namespace Towers
{
    public class CrystalTower : ShootingTower
    {
        protected override void AimAtTarget()
        {
            Debug.DrawLine(ShootingPoint.position, Target.Position, Color.cyan);
        }

        protected override Projectile Shoot()
        {
            Projectile projectile = base.Shoot();
            projectile.GetComponent<GuidedProjectileMovement>().Target = Target.transform;
            return projectile;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, Data.AggroRadius);
        }
    }
}