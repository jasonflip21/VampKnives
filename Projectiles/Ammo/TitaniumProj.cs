﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Ammo
{
    public class TitaniumProj : KnifeProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            projectile.hostile = false;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.timeLeft = 300;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Hoods(n);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Tink, (int)projectile.position.X, (int)projectile.position.Y, 1, 0.5f);
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 1, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Gray, 1f);
            return true;
        }
    }
}