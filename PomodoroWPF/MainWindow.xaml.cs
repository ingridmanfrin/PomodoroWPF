using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PomodoroWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
            => Debug.WriteLine($"SAMPLE 2: Closing dialog with parameter: {eventArgs.Parameter ?? string.Empty}");

        private void MudarCorBtnSelecionado(Button btn)
        {
            btn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#DDFFFFFF");
            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#7F989797");
            btn.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#7F989797");
        }

        private void MudarCorBtnNaoSelecionado(Button btn)
        {
            btn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#7FFFFFFF");
            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#7FD8D8D8");
            btn.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#7FD8D8D8");
        }

        private void MudarCorTema(string background, string retangulo)
        {
            GridBackground.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(background);
            RetanguloSuperior.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(retangulo);
            RetanguloInferior.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(retangulo);
        }


        private void BtnPomodoro_Click(object sender, RoutedEventArgs e)
        {
            MudarCorTema("#FFFBC54F", "#FFFFD16C");

            MudarCorBtnSelecionado(BtnPomodoro);
            MudarCorBtnNaoSelecionado(BtnPausaCurta);
            MudarCorBtnNaoSelecionado(BtnPausaLonga);

            LabelTimer.Content = "25:00";
        }

        private void BtnPausaCurta_Click(object sender, RoutedEventArgs e)
        {
            MudarCorTema("#FF4BB999", "#FF6EBFA7");

            MudarCorBtnSelecionado(BtnPausaCurta);
            MudarCorBtnNaoSelecionado(BtnPomodoro);
            MudarCorBtnNaoSelecionado(BtnPausaLonga);

            LabelTimer.Content = "05:00";

        }

        private void BtnPausaLonga_Click(object sender, RoutedEventArgs e)
        {
            MudarCorTema("#FF50BCE0", "#FF73C4E0");

            MudarCorBtnSelecionado(BtnPausaLonga);
            MudarCorBtnNaoSelecionado(BtnPomodoro);
            MudarCorBtnNaoSelecionado(BtnPausaCurta);

            LabelTimer.Content = "15:00";
        }
    }
}
