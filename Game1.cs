//Este projeto é um estudo do XNA MonoGame 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace simpleGAme
{
    public class Game1 : Game
    {
        private const string HMS = "hh:mm:ss";
        private GraphicsDeviceManager _graphics;    //Gerenciador de gráficos, é inicializado no construtor da classe.
                                                    
        private SpriteBatch _spriteBatch;           //Desenhador de Sprite, é inicializado recebendo como argumento uma
                                                    //instância de GraphicsDeviceManager. É o responsável por desenhar
                                                    //sprites na tela.
        private Shuttle shuttle;                    //É uma instância de classe para a Nave, sendo desenhada com
                                                    //shuttle.Draw()

        private Background[] bg = new Background[2];//instância vetorizada não inicializada de Background, para
                                                    //que seja possível armazenar múltiplos elementos de background
                                                    //em série
                                                    
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
            string _hms = gameTime.TotalGameTime.ToString().Substring(0,8);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font,
                                    $"Joguinho de nave feito\nfeito para fins de estudo\nTempo de jogo:{_hms}",
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
