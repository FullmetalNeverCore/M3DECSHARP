using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ncore.m3decsharp.basic_tools
{
    class Camera
    {
        public Matrix transform { get; private set; } //holds transformation of matrix for the camera  it combines everything below,simulating camera moves
        public Vector2 pos {get; private set;}
        public float zoom {get; set;}
        public float rot {get;set;}

        private Viewport _viewport; 

        public Camera(Viewport viewport)
        {
            _viewport = viewport;
            zoom = 1f;
            rot = 0f;
            pos = Vector2.Zero;
            UpdateTransform();
        }   

        public void Update(Vector2 pos,float zoom = 1f,float rot=0f)
        {
            this.pos = pos; //nice naming
            this.zoom = zoom;
            this.rot = rot; 
            UpdateTransform();
        }

        private void UpdateTransform()
        {
            
            transform = Matrix.CreateTranslation(-pos.X, -pos.Y, 0) *
                        Matrix.CreateRotationZ(rot) *
                        Matrix.CreateScale(zoom, zoom, 1) *
                        Matrix.CreateTranslation(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0);
        }
    }
}
