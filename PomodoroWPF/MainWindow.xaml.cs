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
using System.Windows.Threading;

namespace PomodoroWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); // DispatcherTimer: é o tipo da variável dispapatcherTimer
        Stopwatch stopWatch = new Stopwatch();
        int metaEmMinutos = 1; //versão final colocar 25, ao invés de 1

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(TimerTick); //Tick: é uma propriedade(caracteristica) do DispatcherTimer ..EventHandler:quem manipula o evento..(TimerTick): aqui eu referenciei minha classe TimerTick
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        void TimerTick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan tempoPercorrido = stopWatch.Elapsed;  //stopWatch.Elapsed: tempo decorrido ou percorrido
                TimeSpan tempoTotal = new TimeSpan(0, 0, metaEmMinutos, 0, 0); //Transformar metaEmMinutos em minutos em tipo TimeSpan
                TimeSpan tempoRestante = tempoTotal - tempoPercorrido; //Subtrair um TimeSpan do outro TimeSpan
                string tempoRestanteString = String.Format("{0:00}:{1:00}:{2:00}", tempoRestante.Minutes, tempoRestante.Seconds, tempoRestante.Milliseconds / 10);

                LabelTimer.Content = tempoRestanteString;

                if (tempoPercorrido.Seconds >= metaEmMinutos) // >= para obrigar a entrar nesse if e parar o cronometro, mesmo se o valor for maior (em caso de erro no pc, ou alguma outra coisa)
                {
                    if (stopWatch.IsRunning)
                    {
                        stopWatch.Stop();
                    }
                }
            }
        }
        private void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        private void BtnPausar_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
            }

        }

        private void BtnResetar_Click(object sender, RoutedEventArgs e)
        {
            Resetar();

        }

        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
            => Debug.WriteLine($"SAMPLE 2: Closing dialog with parameter: {eventArgs.Parameter ?? string.Empty}");

        private void Resetar()
        {
            stopWatch.Reset();

            TimeSpan tempoTotal = new TimeSpan(0, 0, metaEmMinutos, 0, 0);
            string tempoRestanteString = String.Format("{0:00}:{1:00}:{2:00}", tempoTotal.Minutes, tempoTotal.Seconds, tempoTotal.Milliseconds / 10);
            LabelTimer.Content = tempoRestanteString;
        }

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

            metaEmMinutos = 25;
            Resetar();
        }

        private void BtnPausaCurta_Click(object sender, RoutedEventArgs e)
        {
            MudarCorTema("#FF4BB999", "#FF6EBFA7");

            MudarCorBtnSelecionado(BtnPausaCurta);
            MudarCorBtnNaoSelecionado(BtnPomodoro);
            MudarCorBtnNaoSelecionado(BtnPausaLonga);

            metaEmMinutos = 5;
            Resetar();
        }

        private void BtnPausaLonga_Click(object sender, RoutedEventArgs e)
        {
            MudarCorTema("#FF50BCE0", "#FF73C4E0");

            MudarCorBtnSelecionado(BtnPausaLonga);
            MudarCorBtnNaoSelecionado(BtnPomodoro);
            MudarCorBtnNaoSelecionado(BtnPausaCurta);

            metaEmMinutos = 15;
            Resetar();
        }


    }
}
