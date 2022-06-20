using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1Game
{
    public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;    //Gerenciador de gráficos
        private SpriteBatch _spriteBatch;           //Desenhador de Sprite

        private Color cl = Color.Black; //CL = Cor, utilizei para alterar, em testes, a cor da tela
        private Texture2D shuttle;      //É a variável de Textura 2D para a Nave
        private Texture2D stars;        //É a variável de Textura 2D para o Background Estrelado
        private Texture2D earth;        //É a variável de Textura 2D para a terra
        private SpriteFont font;        //
        private Vector2 shuttlePos;     //
        private float shuttleSpd;   //

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            shuttleSpd = 1000f;
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

            //if (kState.IsKeyDown(Keys.Space))


            if (kState.IsKeyDown(Keys.W))
                ShuttleMove('w', gameTime);
            
            if (kState.IsKeyDown(Keys.S))
                ShuttleMove('s', gameTime);

            if (kState.IsKeyDown(Keys.A))
                ShuttleMove('a', gameTime);

            if (kState.IsKeyDown(Keys.D))
                ShuttleMove('d', gameTime);

            base.Update(gameTime);
        }

        void ShuttleMove(char key,GameTime gameTime)
        {
            switch (key)
            {
                case 'w':
                    shuttlePos.Y -= shuttleSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;                
                case 'a':
                    shuttlePos.X -= shuttleSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 's':
                    shuttlePos.Y += shuttleSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 'd':
                    shuttlePos.X += shuttleSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;

            }
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
            Vector2 centroTexto = font.MeasureString("Ola Mundo!") / 2;

            Vector2 posicaoCentral = new Vector2(Window.ClientBounds.Width  / 2,
                                                 Window.ClientBounds.Height / 2);

            
            _spriteBatch.Draw(shuttle,
                              shuttlePos,
                              null,
                              Color.White,
                              1,
                              new Vector2(shuttle.Width / 2, shuttle.Height / 2), 
                              Vector2.One,
                              SpriteEffects.None,
                              0f); 
            /*
            _spriteBatch.Draw(shuttle,
                              new Rectangle((int)posicaoCentral.X,
                                            (int)posicaoCentral.Y,
                                            shuttle.Width,
                                            shuttle.Height),
                              null,
                              Color.White,
                              0.9f,
                              new Vector2(shuttle.Width / 2,
                                          shuttle.Height / 2),
                              SpriteEffects.None, 1f);
            */
            
            _spriteBatch.DrawString(font,
                                    "Ola Mundo!",
                                    posicaoCentral,
                                    Color.White,
                                    0,
                                    centroTexto,
                                    1.0f,
                                    SpriteEffects.None,
                                    0.5f);
            
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
