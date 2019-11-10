using System;
namespace MyGame
{
	public class View
	{
		protected ViewManager _viewManager;

		public View (ViewManager viewManager)
		{
			_viewManager = viewManager;
		}
		public virtual void Draw () { }
		public virtual void Update () { }
		public virtual void ProcessEvent () { }
	}
}
