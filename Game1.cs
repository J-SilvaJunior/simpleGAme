//Este projeto é um estudo do XNA MonoGame 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace simpleGAme
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;                        //Gerenciador de gráficos, é inicializado no construtor da classe.
                                                                        //
        private SpriteBatch _spriteBatch;                               //Desenhador de Sprite, é inicializado recebendo como argumento uma
                                                                        //instância de GraphicsDeviceManager. É o responsável por desenhar
                                                                        //sprites na tela.
                                                                        //
        private Color cl = Color.Blue;                                 //CL = Cor, utilizei para alterar, em testes, a cor da tela. 
                                                                        //O Template vem como padrão Color.CornflowerBlue.
                                                                        //
        private Shuttle shuttle;                                        //É a variável de Textura 2D para a Nave, é a penúltima a ser desenhada,
                                                                        //antes do texto. Texture2D neste projeto são inicilizadas em
                                                                        //this.LoadContent(), dentro dele utilizando
                                                                        //Content.Load<T>(String nomeDoAsset), onde T é o tipo que ele vai
                                                                        //inicializar, neste caso,
                                                                        //shuttle = Content.Load<Texture2D>("shuttle")
                                                                        //
        private Texture2D stars;                                        //É a variável de Textura 2D para o Background Estrelado
                                                                        //Como Background, ela deve ser a primeira a ser desenhada.
                                                                        //
        private Texture2D earth;                                        //É a variável de Textura 2D para a Terra, é a segunda a ser desenhada
                                                                        //
                                                                        //
        private SpriteFont font;                                        //Variável que guarda uma fonte e seus caractéres na memória
                                                                        //devido a necessidade de guardar ela como sprites.
                                                                        //
        //private Vector2 shuttlePos;                                     //Posição da nave no espaço, como Vector2, ou seja, posição X e Y
                                                                        //para pegar o centro da tela, deve se utilizar, após a inicialização
                                                                        //dos gráficos, na instância de GraphicsDeviceManager, os dois valores
                                                                        //(_graphics.PreferredBackBufferWidth  / 2) e,
                                                                        //(_graphics.PreferredBackBufferHeight / 2) . 
                                                                        //
        //private float shuttleSpd                                      //Velocidade da nave. Quando utilizada, deve ser multiplicada por
                                                                        //(float)GameTime.ElapsedGameTime.TotalSeconds .
                                                                        //
        //private float shuttleDrct = (float) System.Math.PI * 0.5f;    //Rotação, medida em radiano. 360° || 0° é o mesmo que PI * 2
                                                                        //https://pt.wikipedia.org/wiki/Radiano

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //shuttleSpd = 500f;
            base.Initialize();
            Window.Title = "Aventuras do Mineirinho no Espaço Don Zellital";
            //_graphics.PreferredBackBufferHeight = 720;
            //_graphics.PreferredBackBufferWidth = 1280;
            //_graphics.ApplyChanges();
            //shuttlePos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           shuttle = new Shuttle(Content.Load<Texture2D>("shuttle"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
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
            shuttle.ShuttleMove(kState, gameTime);
            //if (kState.IsKeyDown(Keys.Space))
            base.Update(gameTime);
        }
        
        

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(cl);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(stars,
                              new Rectangle(0,0,1280,500),
                              Color.White);

            _spriteBatch.Draw(earth, 
                              new Vector2(400,240),
                              Color.White);
            _spriteBatch.End();
            Vector2 centroTexto = font.MeasureString("Ola Mundo!") / 2;

            Vector2 posicaoCentral = new Vector2(Window.ClientBounds.Width  / 2,
                                                 Window.ClientBounds.Height / 2);
            shuttle.Draw(_spriteBatch);
            
            
            
            _spriteBatch.Begin();         
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
            /* -------------Caiu em desuso -> Nova implementação em classe
            _spriteBatch.Draw(shuttle,
                              shuttlePos,
                              null,
                              Color.White,
                              shuttleDrct,
                              new Vector2(shuttle.Width / 2, shuttle.Height / 2), 
                              Vector2.One,
                              SpriteEffects.None,
                              0f); 
            */
            
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
            
            
            
            
            
            base.Draw(gameTime);
        }
    }

}
