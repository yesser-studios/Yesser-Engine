using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using YesserEngine.CustomEventArgs;

namespace YesserEngine
{
    public class EngineGame : Game
    {
        /// <summary>
        /// The width of the drawable game screen.
        /// </summary>
        public float GameScreenWidth { get => _gameResolution.X; }

        /// <summary>
        /// The height of the drawable game screen.
        /// </summary>
        public float GameScreenHeight { get => _gameResolution.Y; }

        /// <summary>
        /// This event gets called when the <see cref="LoadContent"/> method gets called.
        /// </summary>
        public event EventHandler<ContentEventArgs> LoadContentEvent;

        /// <summary>
        /// This event gets called when the <see cref="Update(GameTime)"/> method gets called.
        /// </summary>
        public event EventHandler UpdateEvent;

        /// <summary>
        /// This event gets called when the <see cref="Draw(GameTime)"/> method gets called.
        /// </summary>
        public event EventHandler<DrawEventArgs> DrawEvent;

        protected Point _gameResolution;
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        protected RenderTarget2D _renderTarget;
        protected Rectangle _renderTargetDestination;

        /// <summary>
        /// The main constructor for the game.
        /// </summary>
        public EngineGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _gameResolution = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _renderTarget = new RenderTarget2D(
                GraphicsDevice,
                _gameResolution.X,
                _gameResolution.Y);

            _renderTargetDestination = GetRenderTargetDestination(
                _gameResolution,
                _graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);

#if DEBUG
            if (_instaExit)
                Exit();
#endif

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if (LoadContentEvent != null)
            {
                var args = new ContentEventArgs(Content);
                LoadContentEvent(this, args);
            }

            base.LoadContent();
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
                var args = new DrawEventArgs(_spriteBatch);
                DrawEvent(this, args);
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Registers a game object that implements <see cref="IGameObject"/>
        /// to have its Initialize method called instantly and LoadContent, Update and Draw methods upon the corresponding events fired.
        /// </summary>
        /// <param name="gameObject">The game object to be registered</param>
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

        Rectangle GetRenderTargetDestination(Point resolution, int preferredBackBufferWidth, int preferredBackBufferHeight)
        {
            float resolutionRatio = (float)resolution.X / resolution.Y;
            float screenRatio;
            Point bounds = new Point(preferredBackBufferWidth, preferredBackBufferHeight);
            screenRatio = (float)bounds.X / bounds.Y;
            float scale;
            Rectangle rectangle = new Rectangle();

            if (resolutionRatio < screenRatio)
                scale = (float)bounds.Y / resolution.Y;
            else if (resolutionRatio > screenRatio)
                scale = (float)bounds.X / resolution.X;
            else
            {
                // Resolution and window/screen share aspect ratio
                rectangle.Size = bounds;
                return rectangle;
            }
            rectangle.Width = (int)(resolution.X * scale);
            rectangle.Height = (int)(resolution.Y * scale);
            return CenterRectangle(new Rectangle(Point.Zero, bounds), rectangle);
        }

        static Rectangle CenterRectangle(Rectangle outerRectangle, Rectangle innerRectangle)
        {
            Point delta = outerRectangle.Center - innerRectangle.Center;
            innerRectangle.Offset(delta);
            return innerRectangle;
        }

#if DEBUG
        #region Debugging/Testing Methods
        private readonly bool _instaExit = false;

        /// <summary>
        /// A debugging constructor used for testing game window appearance.
        /// DO NOT use outside tests and other debug builds.
        /// This constructor will only be built on the DEBUG configuration.
        /// </summary>
        /// <param name="instaExit">This <see cref="bool"/> determines whether the game window should instantly exit after initialization.</param>
        public EngineGame(bool instaExit)
        {
            _instaExit = instaExit;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// This method programmatically invokes the <see cref="LoadContentEvent"/>.
        /// It is primarily to be used alongside <see cref="EngineGame(bool)"/> with the instaExit parameter for testing.
        /// This method will only be built on the DEBUG configuration.
        /// </summary>
        /// <param name="args">The <see cref="ContentEventArgs"/> to pass into the event. Use <see cref="ContentEventArgs.Empty"/> to input empty args.</param>
        public void InvokeLoadContentEvent(ContentEventArgs args)
        {
            LoadContentEvent(this, args);
        }

        /// <summary>
        /// This method programmatically invokes the <see cref="UpdateEvent"/>.
        /// It is primarily to be used alongside <see cref="EngineGame(bool)"/> with the instaExit parameter for testing.
        /// This method will only be built on the DEBUG configuration.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs"/> to pass into the event. Use <see cref="EventArgs.Empty"/> to input empty args.</param>
        public void InvokeUpdateEvent(EventArgs args)
        {
            UpdateEvent(this, args);
        }

        /// <summary>
        /// This method programmatically invokes the <see cref="DrawEvent"/>.
        /// It is primarily to be used alongside <see cref="EngineGame(bool)"/> with the instaExit parameter for testing.
        /// This method will only be built on the DEBUG configuration.
        /// </summary>
        /// <param name="args">The <see cref="DrawEventArgs"/> to pass into the event. Use <see cref="DrawEventArgs.Empty"/> to input empty args.</param>
        public void InvokeDrawEvent(DrawEventArgs args)
        {
            DrawEvent(this, args);
        }
        #endregion
#endif
    }
}
