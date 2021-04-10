using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings.Framework.Critters
{
    internal class ButterflyFollower : Critter
    {
        public const float maxSpeed = 3f;
        private int flapTimer;
        private int checkForLandingSpotTimer;
        private int landedTimer;
        private int flapSpeed = 50;
        private Vector2 motion;
        private float motionMultiplier = 1f;
        private bool summerButterfly;
        private bool islandButterfly;
        public bool stayInbounds;

        private readonly float spawnOffsetY;
        private readonly float spawnOffsetX;

        public ButterflyFollower(Vector2 position, bool islandButterfly = false)
        {
            // Determine if X spawn will be to left or right of player
            spawnOffsetX = 20f + (Game1.random.Next(0, 2) * 64f);
            spawnOffsetY = 30f + Game1.random.Next(0, 5);

            base.position = position * 64f;
            base.startingPosition = base.position;
            if (Game1.currentSeason.Equals("spring"))
            {
                base.baseFrame = ((Game1.random.NextDouble() < 0.5) ? (Game1.random.Next(3) * 3 + 160) : (Game1.random.Next(3) * 3 + 180));
            }
            else
            {
                base.baseFrame = ((Game1.random.NextDouble() < 0.5) ? (Game1.random.Next(3) * 4 + 128) : (Game1.random.Next(3) * 4 + 148));
                this.summerButterfly = true;
            }
            if (islandButterfly)
            {
                this.islandButterfly = islandButterfly;
                base.baseFrame = Game1.random.Next(4) * 4 + 364;
                this.summerButterfly = true;
            }

            this.motion = new Vector2((float)(Game1.random.NextDouble() + 0.25) * 3f * (float)((!(Game1.random.NextDouble() < 0.5)) ? 1 : (-1)) / 2f, (float)(Game1.random.NextDouble() + 0.5) * 3f * (float)((!(Game1.random.NextDouble() < 0.5)) ? 1 : (-1)) / 2f);
            this.flapSpeed = Game1.random.Next(45, 80);
            base.sprite = new AnimatedSprite(Critter.critterTexture, base.baseFrame, 16, 16);
            base.sprite.loop = false;
            base.startingPosition = position;

            this.stayInbounds = true;
        }

        public void doneWithFlap(Farmer who)
        {
            this.flapTimer = 200 + Game1.random.Next(-5, 6);
        }

        public override bool update(GameTime time, GameLocation environment)
        {
            Vector2 targetPosition = Game1.player.position + new Vector2(spawnOffsetX, spawnOffsetY);
            Vector2 smoothedPosition = Vector2.Lerp(this.position, targetPosition, 0.05f);
            Vector2 smoothedPositionSlow = Vector2.Lerp(this.position, targetPosition, 0.02f);

            //setting up a "wander zone" where the Will'o'the'Wisp is less restricted within a defined distance of the player
            if (Vector2.Distance(targetPosition, this.position) >= 64f)
            {
                this.position = smoothedPosition;
            }
            else
            {
                this.position = smoothedPositionSlow;
            }

            this.flapTimer -= time.ElapsedGameTime.Milliseconds;
            if (this.flapTimer <= 0 && base.sprite.CurrentAnimation == null)
            {
                this.motionMultiplier = 1f;
                this.motion.X += (float)Game1.random.Next(-80, 81) / 100f;
                this.motion.Y = (float)(Game1.random.NextDouble() + 0.25) * -3f / 2f;
                if (Math.Abs(this.motion.X) > 1.5f)
                {
                    this.motion.X = 3f * (float)Math.Sign(this.motion.X) / 2f;
                }
                if (Math.Abs(this.motion.Y) > 3f)
                {
                    this.motion.Y = 3f * (float)Math.Sign(this.motion.Y);
                }
                if (this.summerButterfly)
                {
                    base.sprite.setCurrentAnimation(new List<FarmerSprite.AnimationFrame>
                    {
                        new FarmerSprite.AnimationFrame(base.baseFrame + 1, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame + 2, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame + 3, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame + 2, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame + 1, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame, this.flapSpeed, secondaryArm: false, flip: false, doneWithFlap)
                    });
                }
                else
                {
                    base.sprite.setCurrentAnimation(new List<FarmerSprite.AnimationFrame>
                    {
                        new FarmerSprite.AnimationFrame(base.baseFrame + 1, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame + 2, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame + 1, this.flapSpeed),
                        new FarmerSprite.AnimationFrame(base.baseFrame, this.flapSpeed, secondaryArm: false, flip: false, doneWithFlap)
                    });
                }
            }

            base.position += this.motion * this.motionMultiplier;
            this.motion.Y += 0.005f * (float)time.ElapsedGameTime.Milliseconds;
            this.motionMultiplier -= 0.0005f * (float)time.ElapsedGameTime.Milliseconds;
            if (this.motionMultiplier <= 0f)
            {
                this.motionMultiplier = 0f;
            }
            return base.update(time, environment);
        }

        public override void draw(SpriteBatch b)
        {
        }

        public override void drawAboveFrontLayer(SpriteBatch b)
        {
            base.sprite.draw(b, Game1.GlobalToLocal(Game1.viewport, base.position + new Vector2(-64f, -128f + base.yJumpOffset + base.yOffset)), base.position.Y / 10000f, 0, 0, Color.White, base.flip, 4f);
        }
    }
}
