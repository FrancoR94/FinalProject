using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project
{
	public abstract class GameObjectBase
	{
		protected Texture texture;
		protected Sprite sprite;
		protected Vector2f position;
		private bool lateDispose; //Para eliminar el elemento de una lista luego de recorrerla y no durante.
		public bool toDelete;
		public GameObjectBase(string texturePath, Vector2f startPosition)
		{
			texture = new Texture(texturePath);
			sprite = new Sprite(texture);
			position = startPosition;
			sprite.Position = position;
			toDelete = false;
			lateDispose = false;
		}

		public virtual void Update()
		{
			sprite.Position = position;
		}

		public virtual void Draw(RenderWindow window)
		{
			window.Draw(sprite);
		}

		public virtual void DisposeNow()
		{
			sprite.Dispose();
			texture.Dispose();
			toDelete = true;
		}

		public void LateDispose()
		{
			lateDispose = true;
		}

		public virtual void CheckGarbash()
		{
			if (lateDispose)
			{
				DisposeNow();
			}
		}

		public Vector2f GetPosition()
		{
			return position;
		}
	}
}
