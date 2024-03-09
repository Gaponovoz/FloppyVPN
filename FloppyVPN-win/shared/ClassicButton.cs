using System.Drawing;
using System.Windows.Forms;

namespace FloppyVPN
{
	internal class ClassicButton : Button
	{
		// Constructor
		public ClassicButton()
		{
			// Set initial style
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
			this.FlatAppearance.MouseDownBackColor = Color.Transparent;
			this.FlatAppearance.MouseOverBackColor = Color.Transparent;
			this.BackColor = Color.Transparent; 
			this.ForeColor = Color.Black;
		}

		// Override OnMouseDown event to change button style
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.BackColor = Color.DarkBlue; // Change this to your desired background color when mouse is down
			this.ForeColor = Color.Gray; // Change this to your desired text color when mouse is down
		}

		// Override OnMouseUp event to reset button style
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			// Reset button style on mouse up
			this.BackColor = Color.Blue; // Change this to your desired default background color
			this.ForeColor = Color.White; // Change this to your desired default text color
		}
	}
}