using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Color cl = Color.Black;
        private Texture2D shuttle;
        private Texture2D stars;
        private Texture2D earth;
        private SpriteFont font;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            shuttle = Content.Load<Texture2D>("shuttle");
            stars = Content.Load<Texture2D>("stars");
            earth = Content.Load<Texture2D>("earth");
            font = Content.Load<SpriteFont>("testFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var kState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
              ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            /*
            if (kState.IsKeyDown(Keys.Space))
                cl = Color.White;
            if (kState.IsKeyDown(Keys.G))
                cl = Color.Green;
            if (kState.IsKeyDown(Keys.S))
                cl = Color.Silver;
            if (kState.IsKeyDown(Keys.R))
                cl = Color.Red;
            if (kState.IsKeyDown(Keys.B))
                cl = Color.Blue;
            */
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(cl);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(stars,
                              new Rectangle(0,0,800,480),
                              Color.White);

            _spriteBatch.Draw(earth, 
                              new Vector2(400,240),
                              Color.White);
            
            _spriteBatch.Draw(shuttle,
                              new Vector2(450,240),
                              Color.White);
            Vector2 centroTexto = font.MeasureString("Ola mundo!") / 2;

            Vector2 posicaoCentral = new Vector2(Window.ClientBounds.Width  / 2,
                                                 Window.ClientBounds.Height / 2);
            
            _spriteBatch.DrawString(font,
                                    "Ola Mundo!",
                                    posicaoCentral,
                                    Color.White,
                                    0,
                                    centroTexto,
                                    1.0f,
                                    SpriteEffects.None,0.5f);
            
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
