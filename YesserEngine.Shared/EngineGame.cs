using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using YesserEngine.CustomEventArgs;

namespace YesserEngine
{
    public class EngineGame : Game
    {
        public event EventHandler<ContentEventArgs> LoadContentEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler<ContentEventArgs> DrawEvent;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private bool _instaExit = false;

        public EngineGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            if (_instaExit)
                Exit();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if (LoadContentEvent != null)
            {
                var args = new ContentEventArgs(_spriteBatch);
                LoadContentEvent(this, args);
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();

            if (UpdateEvent != null)
                UpdateEvent(this, EventArgs.Empty);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            if (DrawEvent != null)
            {
                var args = new ContentEventArgs(_spriteBatch);
                DrawEvent(this, args);
            }

            base.Draw(gameTime);
        }

        public virtual void RegisterGameObject(IGameObject gameObject)
        {
            if (gameObject is null)
                return;

            LoadContentEvent += gameObject.LoadContent;
            UpdateEvent += gameObject.Update;
            DrawEvent += gameObject.Draw;

            gameObject.Initialize();
        }

        /// <summary>
        /// Registers multiple game objects that implement <see cref="IGameObject"/>
        /// to have their Initialize method called instantly and LoadContent, Update and Draw methods upon the corresponding events fired.
        /// </summary>
        /// <param name="gameObjects">The game objects to be registered</param>
        public virtual void RegisterGameObjects(params IGameObject[] gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                RegisterGameObject(gameObject);
            }
        }

#if DEBUG
        public EngineGame(bool instaExit)
        {
            _instaExit = instaExit;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void InvokeLoadContentEvent(ContentEventArgs args)
        {
            LoadContentEvent(this, args);
        }
        public void InvokeUpdateEvent(EventArgs args)
        {
            UpdateEvent(this, args);
        }
        public void InvokeDrawEvent(ContentEventArgs args)
        {
            DrawEvent(this, args);
        }
#endif
    }
}
