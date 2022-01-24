using System;

namespace GameClassLibrary
{
    public abstract class GameCharacter : GameElement, IMovable
    {
        protected GameCharacter(int x, int y) : base(x, y) { }

        public virtual void Move() { }
        public virtual void Move(char[,] field) { }
    }
}
