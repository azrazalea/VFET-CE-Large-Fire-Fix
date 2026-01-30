using RimWorld;
using Verse;

namespace VFET_CE_LargeFireFix
{
    /// <summary>
    /// A visual-only spark that doesn't attempt to start fires.
    ///
    /// The vanilla Spark class calls FireUtility.TryStartFireIn() on impact,
    /// which Combat Extended patches to add a 50% chance to ignite pawns.
    /// This causes VFET's Large Fire to constantly set nearby pawns ablaze.
    ///
    /// This class inherits from Spark (required for VFET's cast) but overrides
    /// the impact behavior to simply destroy the spark without fire effects.
    /// </summary>
    public class Spark_Visual : Spark
    {
        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            // Skip the base Spark.Impact which calls FireUtility.TryStartFireIn
            // Instead, just destroy the projectile like a visual effect

            // Call Projectile.Impact behavior without the fire-starting logic
            // We access the grandparent (Projectile) behavior by not calling base

            // Just destroy the spark - it's purely visual
            this.Destroy(DestroyMode.Vanish);
        }
    }
}
