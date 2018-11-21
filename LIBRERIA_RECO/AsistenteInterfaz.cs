using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace LIBRERIA_RECO
{
    public partial class AsistenteInterfaz : UserControl
    {
        public AsistenteInterfaz()
        {
            InitializeComponent();
            inicializar();
        }

        AV av = new AV();
        SpeechRecognitionEngine reconocer = new SpeechRecognitionEngine(); // instanciamiento para reconocer lo que diga elusuario
        SpeechSynthesizer voz = new SpeechSynthesizer(); // instanciamiento para que el programa sea capas de hablar
        int intervaloGeneral = 0;


        /* Funciones del programador */

        // Función para inicializar todos los eventos de la libreria que reconozera la voz
        void inicializar()
        {
            reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("a"))));
            reconocer.RequestRecognizerUpdate();
            reconocer.SpeechRecognized += reconocer_SpeechRecognized;
            voz.SetOutputToDefaultAudioDevice();
            reconocer.AudioLevelUpdated += reconocer_AudioLevelUpdated;
            reconocer.SetInputToDefaultAudioDevice();
            reconocer.RecognizeAsync(RecognizeMode.Multiple);
            reconocer.MaxAlternates = 5;
        }

        private void reconocer_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            //NivelAudio.Text = av.nivelAudio.ToString();
            //ProgressBarNivelAudio.Value = av.nivelAudio;
        }

        private void reconocer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Escucha.Text = av.speech;
            Responde.Text = av.respuestaAV;

        }

        private void AsistenteInterfaz_Load(object sender, EventArgs e)
        {
            av.inicializar();
            intervaloGeneral = av.intervaloReconocimientoVoz;
        }

        private void segundero_Tick(object sender, EventArgs e)
        {
            Intervalo.Text = av.intervaloReconocimientoVoz.ToString();
            //ProgressBarIntervalo.Value = (av.intervaloReconocimientoVoz * 100 / intervaloGeneral);
            if (av.intervaloReconocimientoVoz == 0)
            {
                Mic.Text = "Mic: OFF";
                Mic.BackColor = Color.FromArgb(134, 0, 0);
            }
            else
            {
                Mic.Text = "Mic: ON";
                Mic.BackColor = Color.FromArgb(34, 184, 7);
            }
            Escucha.Text = av.speech;
            Responde.Text = av.respuestaAV;
            DateTime date = DateTime.Now;
            //fecha.Text = "Fecha " + date.ToString("(dd/MM/yy)");
        }


    }
}
