//Este projeto é um estudo do XNA MonoGame 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace simpleGAme
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;    //Gerenciador de gráficos, é inicializado no construtor da classe.
                                                    
        private SpriteBatch _spriteBatch;           //Desenhador de Sprite, é inicializado recebendo como argumento uma
                                                    //instância de GraphicsDeviceManager. É o responsável por desenhar
                                                    //sprites na tela.
        private Shuttle shuttle;                    //É a variável de Textura 2D para a Nave, é a penúltima a ser desenhada,
                                                    //antes do texto. Texture2D neste projeto são inicilizadas em
                                                    //this.LoadContent(), dentro dele utilizando
                                                    //Content.Load<T>(String nomeDoAsset), onde T é o tipo que ele vai
                                                    //inicializar, neste caso,
                                                    //shuttle = Content.Load<Texture2D>("shuttle")

        private Background[] bg = new Background[2];//instância não inicializada do background
                                                    
        private SpriteFont font;                    //Variável que guarda uma fonte e seus caractéres na memória
                                                    //devido a necessidade de guardar ela como sprites.
                                                    
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
            Window.Title = "Aventuras do Mineirinho no Espaço Don Zellital";
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            shuttle = new Shuttle(Content.Load<Texture2D>("shuttle"),
                                  new Vector2(_graphics.PreferredBackBufferWidth / 2,
                                              _graphics.PreferredBackBufferHeight / 2));
            
            bg[0] = new Background(Content.Load<Texture2D>("stars"),
                                   new Vector2(_graphics.PreferredBackBufferWidth,
                                               _graphics.PreferredBackBufferHeight),
                                   Color.White);


            bg[1] = new Background(Content.Load<Texture2D>("earth"),
                                   null,
                                   new Vector2(260,200),
                                   Color.White);
            font = Content.Load<SpriteFont>("testFont");
            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            var kState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
              ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            shuttle.ShuttleMove(kState, gameTime);

            //chamando a atualização padrão
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);
            for (int i = 0; i < bg.Length; i++)
            {
                bg[i].Draw(_spriteBatch);
            }


            //centralização, colocar no lugar certo depois
            Vector2 centroTexto = Vector2.Zero; //font.MeasureString("Joguinho de nave feito\nfeito para fins de estudo") / 2;
            Vector2 posicaoCentral = new Vector2(0,
                                                 0);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font,
                                    "Joguinho de nave feito\nfeito para fins de estudo",
                                    posicaoCentral,
                                    Color.White,
                                    0,
                                    centroTexto,
                                    1.0f,
                                    SpriteEffects.None,
                                    0.5f);
            _spriteBatch.End();
            shuttle.Draw(_spriteBatch);
            base.Draw(gameTime);
        }

    }

}
