#region Using directives

using System.Windows.Forms;

#endregion

// ReSharper disable CheckNamespace
public static class FormExtensions
// ReSharper restore CheckNamespace
{
    public static void GoFullscreen(this Form f, bool fullscreen)
    {
        if (fullscreen) {
            f.WindowState = FormWindowState.Normal;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Bounds = Screen.PrimaryScreen.Bounds;
        }
        else {
            f.WindowState = FormWindowState.Maximized;
            f.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}