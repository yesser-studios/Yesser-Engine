using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YesserEngine.Components;
using YesserEngine.CustomEventArgs;

namespace YesserEngine
{
    public class GameObject : IGameObject
    {
        #region Properties
        /// <summary>
        /// The <see cref="Texture2D"/> of this <see cref="GameObject"/>
        /// </summary>
        public Texture2D Texture { get => texture; }

        // TODO: Change this docstring when camera support added
        /// <summary>
        /// The position of this <see cref="GameObject"/> on the screen.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The scale of this <see cref="GameObject"/>. Scales its texture.
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// The width of the <see cref="Texture"/>
        /// </summary>
        public float Width { get => Texture.Width * Scale; }
        
        /// <summary>
        /// The height of the <see cref="Texture"/>
        /// </summary>
        public float Height { get => Texture.Height * Scale; }

        /// <summary>
        /// The X axis of the <see cref="Position"/>.
        /// </summary>
        public float X { get => Position.X; }

        /// <summary>
        /// The Y axis of the <see cref="Position"/>.
        /// </summary>
        public float Y { get => Position.Y; }

        /// <summary>
        /// The <see cref="EngineGame"/> where this <see cref="GameObject"/> is registered.
        /// See also: <seealso cref="EngineGame.RegisterGameObject(IGameObject)"/>
        /// </summary>
        public EngineGame RegisteredIn {  get; set; }

        /// <summary>
        /// The registered <see cref="IComponent"/>s of this <see cref="GameObject"/>.
        /// </summary>
        public List<IComponent> Components { get; set; }
        #endregion

        protected Texture2D texture;
        protected string textureString;

        public GameObject(string textureContentString, Vector2 position, float scale)
        {
            textureString = textureContentString;
            Position = position;
            Scale = scale;
        }

        public virtual void Initialize() { }

        public virtual void Draw(object sender, DrawEventArgs e)
            => e.SpriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                0,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                Scale,
                SpriteEffects.None,
                0);

        public virtual void LoadContent(object sender, ContentEventArgs e)
            => texture = e.Content.Load<Texture2D>(textureString);

        public virtual void Update(object sender, EventArgs e) { }

        public ScreenSide CheckOutOfScreen()
        {
            ScreenSide outOfScreen = ScreenSide.Center;
            if (X - (Width / 2) < 0) outOfScreen = ScreenSide.Left;
            if (Y - (Height / 2) < 0) outOfScreen = ScreenSide.Top;
            if (X + (Width / 2) > RegisteredIn.GameScreenWidth) outOfScreen = ScreenSide.Right;
            if (Y + (Height / 2) > RegisteredIn.GameScreenHeight) outOfScreen = ScreenSide.Bottom;

            return outOfScreen;
        }

        public void AddComponent(IComponent component)
        {
            Components.Add(component);
            component.RegisteredIn = this;
            component.Initialize();
        }
    }
}
