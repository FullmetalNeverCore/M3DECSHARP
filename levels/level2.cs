using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ncore.m3decsharp.basic_tools; 
using System.Collections.Generic; 
using System.Linq; 

//trying to draw a red rectangle
namespace ncore.m3decsharp.levels
{
    class Level2 : Game
    {
        private GraphicsDeviceManager _grph; 
        private Texture2D _hortx; 
        private Vector2 _horpos; 
        private Camera _cam; 
        private Vector2 _playerPos; 
        private SpriteBatch _sprite; 

        public Level2()
        {
            _grph = new GraphicsDeviceManager(this); //graphics initialization 
            Content.RootDirectory = "levels"; 
            IsMouseVisible = true; 
        }

        protected override void Initialize()
        {
            //window size
            
            _grph.PreferredBackBufferWidth = 800;
            _grph.PreferredBackBufferHeight = 600;

            _grph.ApplyChanges(); 

            _cam = new Camera(GraphicsDevice.Viewport);
            _playerPos = new Vector2(400,300); //coords of init player pos 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _sprite = new SpriteBatch(GraphicsDevice);

            //stretch texture to horizon
            _hortx = new Texture2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Color[] data = new Color[GraphicsDevice.Viewport.Width * GraphicsDevice.Viewport.Height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Red; 
            }
            _hortx.SetData(data);
            _horpos = new Vector2(0, GraphicsDevice.Viewport.Height / 2);
        }
        private void UpdatePlayerPosition(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float moveSpeed = 5f; // Speed of the player movement

            // Handle player movement based on input
            if (keyboardState.IsKeyDown(Keys.W))
                _playerPos.Y -= moveSpeed;
            if (keyboardState.IsKeyDown(Keys.S))
                _playerPos.Y += moveSpeed;
            if (keyboardState.IsKeyDown(Keys.A))
                _playerPos.X -= moveSpeed;
            if (keyboardState.IsKeyDown(Keys.D))
                _playerPos.X += moveSpeed;

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdatePlayerPosition(gameTime);

            Vector2 campos = _playerPos; 
            _cam.Update(campos); //sending data to camera 

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _sprite.Begin(transformMatrix: _cam.transform);
            // Draw the horizon texture repeatedly across the screen
            int screenWidth = GraphicsDevice.Viewport.Width;
            int txwidth = _hortx.Width; 

            //how many tiles need to be drawn to cover a horizon
            int numberOfTiles = (int)Math.Ceiling((double)screenWidth / txwidth);

            for(int i = 0;i<numberOfTiles;i++)
            {
                _sprite.Draw(_hortx, new Vector2(i * txwidth,_horpos.Y),Color.White);
            }


            _sprite.End();

            base.Draw(gameTime);
        }
    }
}