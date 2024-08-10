using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


//trying to draw a red rectangle
namespace ncore.m3decsharp.levels
{
    class Level1 : Game
    {
        private GraphicsDeviceManager _grph; 
        private Texture2D _blocktx; 
        private Rectangle _blockrec; 
        private SpriteBatch _sprite; 

        public Level1()
        {
            _grph = new GraphicsDeviceManager(this); //graphics initialization 
            Content.RootDirectory = "levels"; 
            IsMouseVisible = true; //potential error? 
        }

        protected override void Initialize()
        {
            //window size
            _grph.PreferredBackBufferWidth = 800;
            _grph.PreferredBackBufferHeight = 600;

            _grph.ApplyChanges(); 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _sprite = new SpriteBatch(GraphicsDevice);

            //1x1 red txture 
            _blocktx = new Texture2D(GraphicsDevice,1,1); // 1,1 texture size 
            _blocktx.SetData(new[] {Color.Red});

            //position of block drawing 
            _blockrec = new Rectangle(100,100,200,200); //x,y,width,height
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _sprite.Begin();
            _sprite.Draw(_blocktx,_blockrec,Color.White);
            _sprite.End();

            base.Draw(gameTime);
        }
    }
}