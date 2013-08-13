using System.Windows;
using System.Windows.Input;

namespace Responsive_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Target.Focus();
        }

        private void Content_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter || string.IsNullOrEmpty(Target.Text) || string.IsNullOrEmpty(Content.Text)) return;

            var target = double.Parse(Target.Text);
            var content = double.Parse(Content.Text);

            var result = ((target/content) * 100).ToString().Replace(",",".");

            var clipboardContent = string.Format("{0}%; /* {1}px / {2}px */", result,target,content);

            Clipboard.SetText(clipboardContent);
            Target.Focus();
            Target.Text = "";
            Log.Items.Insert(0,clipboardContent);
        }

        private void Target_OnGotFocus(object sender, RoutedEventArgs e)
        {
            Target.Text = "";
        }

        private void Content_OnGotFocus(object sender, RoutedEventArgs e)
        {
            Content.Text = "";
        }
    }
}
