using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WinGamePad.Lib
{
    public class SoundManager
    {
        public Dictionary<object, SoundPlayer> _soundPlayers = new Dictionary<object, SoundPlayer>();

        public void Add(object key, string fileName)
        {
            SoundPlayer s = new SoundPlayer(fileName);
            _soundPlayers.Add(key, s);
        }

        public bool Contains(object key)
        {
            return this._soundPlayers.ContainsKey(key);
        }

        public void Play(object key)
        {
            _soundPlayers[key].Play();
        }
    }
}
