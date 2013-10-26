namespace ParallaxScrolling
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ParallaxScrollingGame : Game
    {
        public ParallaxScrollingGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a camera instance and limit its moving range
            _camera = new Camera(GraphicsDevice.Viewport) { Limits = new Rectangle(0, 0, 3200, 600) };

            // Create 9 layers with parallax ranging from 0% to 100% (only horizontal)
            _layers = new List<Layer>
            {
                new Layer(_camera) { Parallax = new Vector2(0.0f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.1f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.2f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.3f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.4f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.5f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.6f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(0.8f, 1.0f) },
                new Layer(_camera) { Parallax = new Vector2(1.0f, 1.0f) }
            };

            // Add one sprite to each layer
            _layers[0].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer1") });
            _layers[1].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer2") });
            _layers[2].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer3") });
            _layers[3].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer4") });
            _layers[4].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer5") });
            _layers[5].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer6") });
            _layers[6].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer7") });
            _layers[7].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer8") });
            _layers[8].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer9") });

            // Add a few duplicates in different positions
            _layers[7].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer8"), Position = new Vector2(900, 0) });
            _layers[8].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer9"), Position = new Vector2(1600, 0)});
        }


        protected override void Update(GameTime gameTime)
        {
            float elapsedTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.Right))
                _camera.Move(new Vector2(400.0f * elapsedTime, 0.0f), true);

            if (keyboardState.IsKeyDown(Keys.Left))
                _camera.Move(new Vector2(-400.0f * elapsedTime, 0.0f), true);

            if (keyboardState.IsKeyDown(Keys.Down))
                _camera.Move(new Vector2(0.0f, 400.0f * elapsedTime), true);

            if (keyboardState.IsKeyDown(Keys.Up))
                _camera.Move(new Vector2(0.0f, -400.0f * elapsedTime), true);

            if (keyboardState.IsKeyDown(Keys.PageUp))
                _camera.Zoom += 0.5f * elapsedTime;

            if (keyboardState.IsKeyDown(Keys.PageDown))
                _camera.Zoom -= 0.5f * elapsedTime;

            if (keyboardState.IsKeyDown(Keys.Insert))
                _camera.Rotation += 1.5f * elapsedTime;

            if (keyboardState.IsKeyDown(Keys.Delete))
                _camera.Rotation -= 1.5f * elapsedTime;

            if(keyboardState.IsKeyDown(Keys.R))
            {
                _camera.Position = Vector2.Zero;
                _camera.Zoom = 1.0f;
                _camera.Rotation = 0.0f;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Layer layer in _layers)
                layer.Draw(_spriteBatch);

            base.Draw(gameTime);
        }

        private Camera _camera;
        private readonly GraphicsDeviceManager _graphics;
        private List<Layer> _layers;
        private SpriteBatch _spriteBatch;
    }
}
