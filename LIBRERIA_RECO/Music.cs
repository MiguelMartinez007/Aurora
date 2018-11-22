using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace LIBRERIA_RECO
{
    class Music
    {
        public void aactivada()
        {
            SoundPlayer s1 = new SoundPlayer("alarma activada.wav");
            s1.Play();
        }
        public void adesac()
        {
            SoundPlayer s1 = new SoundPlayer("alarma Desactivada.wav");
            s1.Play();
        }
        public void apeli()
        {
            SoundPlayer s1 = new SoundPlayer("alerta peligro.wav");
            s1.Play();
        }
        public void atele()
        {
            SoundPlayer s1 = new SoundPlayer("atelevisio.wav");
            s1.Play();
        }
        public void etele()
        {
            SoundPlayer s1 = new SoundPlayer("etelevisio.wav");
            s1.Play();
        }
        public void wifi()
        {
            SoundPlayer s1 = new SoundPlayer("wifi.wav");
            s1.Play();
        }
    }
}
