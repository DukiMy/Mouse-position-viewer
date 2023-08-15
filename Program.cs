namespace mouse_position_viewer;

using System;
using System.Windows.Forms;
using System.Drawing;
public class MousePositionWindow : Form
{
    private Label lblMousePosition;
    private Timer updateTimer;

    public MousePositionWindow()
    {
        this.Text = "Mouse Position";
        this.Width = 200;
        this.Height = 100;

        lblMousePosition = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        this.Controls.Add(lblMousePosition);

        updateTimer = new Timer
        {
            Interval = 50 // Update every 50 milliseconds
        };
        updateTimer.Tick += UpdateMousePosition;
        updateTimer.Start();
    }

    private void UpdateMousePosition(object sender, EventArgs e)
    {
        Point globalPosition = Cursor.Position;
        lblMousePosition.Text = $"X: {globalPosition.X}, Y: {globalPosition.Y}";
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MousePositionWindow());
    }
}
