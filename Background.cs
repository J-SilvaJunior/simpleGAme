using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace simpleGAme
{
    public class Background
    {
        private Texture2D texture;
        private Vector2 frameSize;
        private Color colorMask;
        private Vector2 position;
        private bool lastLayer;
    
        public Background()
        {

        }
        public Background(Texture2D texture, Vector2 frameSize, Color colorMask)
        {
            //  Inicializa o background como lastLayer
            this.texture = texture;
            this.frameSize = frameSize;
            this.colorMask = colorMask;
            position = new Vector2(0, 0);
            lastLayer = true;
        }
        //
        public Background(Texture2D texture, Vector2? frameSize, Vector2 position, Color colorMask)
        {
            //  Inicializa o background 
            this.texture = texture;
            if (frameSize == null)
                this.frameSize = new Vector2(texture.Width, texture.Height);
            else
                this.frameSize = (Vector2)frameSize;
            this.colorMask = colorMask;
            this.position = position;
            lastLayer = false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            {
                if (lastLayer)
                    sb.Draw(texture,
                            new Rectangle((int)position.X,
                                          (int)position.Y,
                                          (int)frameSize.X,
                                          (int)frameSize.Y),
                            colorMask);
                else
                    sb.Draw(texture,
                            new Vector2(position.X,
                                        position.Y),
                            colorMask);
            }
            sb.End();
        }
    }
}
