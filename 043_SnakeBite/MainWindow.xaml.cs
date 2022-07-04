using System.Windows;

namespace _043_SnakeBite
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnPlay_Click(object sender, RoutedEventArgs e)
    {
      Game game= new Game();
      game.Show();
    }

    private void btnQuit_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
