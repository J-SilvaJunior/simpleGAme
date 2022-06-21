using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace simpleGAme
{
    class Shuttle
    {
        private Vector2 shuttlePos;
        private Texture2D texture;
        private float shuttleSpd;
        private float shuttleDirection;


        public Shuttle(Texture2D texture, Vector2 shuttlePos)
        {
            this.shuttlePos = shuttlePos;
            this.texture = texture;
            this.shuttleSpd = 300f;
            shuttleDirection = 0f;

        }
        public void ShuttleMove(KeyboardState key, GameTime gameTime)
        {
            if (key.GetPressedKeyCount() <= 2)
            {
                float rad = (float)System.Math.PI/180;
                bool n, s, e, w;
                (n, s, e, w) = (key.IsKeyDown(Keys.W), key.IsKeyDown(Keys.S), key.IsKeyDown(Keys.D), key.IsKeyDown(Keys.A));
                if (n) { shuttlePos.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * shuttleSpd; }
                if (s) { shuttlePos.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * shuttleSpd; }
                if (e) { shuttlePos.X += (float)gameTime.ElapsedGameTime.TotalSeconds * shuttleSpd; shuttleDirection = rad *  90; }
                if (w) { shuttlePos.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * shuttleSpd; shuttleDirection = rad * 270; }

                if (n)
                {
                    if (n && w)         shuttleDirection = rad * 315;
                    else if (n && e)    shuttleDirection = rad * 45;
                    else                shuttleDirection = rad * 0;
                }
                if (s)
                {
                    if (s && w)         shuttleDirection = rad * 225;
                    else if (s && e)    shuttleDirection = rad * 135;
                    else                shuttleDirection = rad * 180;
                }
            }
            

        }
        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            {
                sb.Draw(texture, shuttlePos, null, Color.White, shuttleDirection, new Vector2(texture.Width / 2, texture.Height / 2), 0.2f, SpriteEffects.None, 0f);
            }
            sb.End();
        }
    }
}
