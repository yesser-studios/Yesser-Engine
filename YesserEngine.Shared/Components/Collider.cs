using YesserEngine;
using YesserEngine.Components;

namespace YesserEngine.Components
{
    public class Collider : IComponent
    {
        public GameObject RegisteredIn { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }
        public float XOffset { get; set; }
        public float YOffset { get; set; }

        public virtual void Initialize()
        {
            if (RegisteredIn != null)
            {
                Width = RegisteredIn.Width;
                Height = RegisteredIn.Height;
                XOffset = 0f;
                YOffset = 0f;
            }
        }

        public virtual bool CollidesWith(Collider other)
        {
            if (other == null) return false;

            float x = RegisteredIn != null ? RegisteredIn.X + XOffset : XOffset;
            float y = RegisteredIn != null ? RegisteredIn.Y + YOffset : YOffset;
            float otherX = other.RegisteredIn != null ? other.RegisteredIn.X + other.XOffset : other.XOffset;
            float otherY = other.RegisteredIn != null ? other.RegisteredIn.Y + other.YOffset : other.YOffset;

            return (x + (Width / 2) >= otherX - (other.Width / 2))
                && (otherX + (other.Width / 2) >= x - (Width / 2))
                && (y + (Height / 2) >= otherY - (other.Height / 2))
                && (otherY + (other.Height / 2) >= y - (Height / 2));
        }
    }
}
