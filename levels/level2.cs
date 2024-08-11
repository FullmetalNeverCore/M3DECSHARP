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
            Content.RootDirectory = "Content"; 
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
            _hortx = new Texture2D(GraphicsDevice, 1,1);
            _hortx.SetData(new[]{Color.Red});
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

            _cam.Update(_playerPos); //sending data to camera 
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdatePlayerPosition(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _sprite.Begin(transformMatrix: _cam.transform);

            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            // This will be a horizontal line that extends infinitely along the X-axis
            Rectangle redLineRect = new Rectangle((int)(_playerPos.X - screenWidth / 2), 0, screenWidth, screenHeight);

            _sprite.Draw(_hortx, redLineRect, Color.Red);

            _sprite.End();

            base.Draw(gameTime);
        }
    }
}