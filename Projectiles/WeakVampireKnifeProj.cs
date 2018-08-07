using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class WeakVampireKnifeProj : KnifeProjectile
	{
		public override void SetDefaults()
		{
			projectile.Name = "VampW Knife";
			projectile.width = 16;
			projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
          		}

		public override void AI()
		{
                                                                //this is projectile dust
           int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width-3, projectile.height-3, 244, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.DarkRed, 1.8f);
           Main.dust[DustID2].noGravity = true;
                                                          //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
			//projectile.alpha = (int)projectile.localAI[0] * 2;
			
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            int random = Main.rand.Next(0, 5);
            Player owner = Main.player[projectile.owner];
            int healamnt = 0;
            healamnt = (int)(projectile.damage * .075);
            if (healamnt >= 1)
            {
                projectile.vampireHeal((int)(projectile.damage), new Vector2(projectile.position.X, projectile.position.Y));
            }
            else if(random == 3)
            {
                projectile.vampireHeal((int)(projectile.damage)*3, new Vector2(projectile.position.X, projectile.position.Y));
            }
            Hoods(n);
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 3) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}