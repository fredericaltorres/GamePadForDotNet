using System;
using System.Collections.Generic;
using System.IO;
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
            s.Tag = Path.GetFileNameWithoutExtension(fileName);
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

        public string GetText (object key)
        {
            return _soundPlayers[key].Tag.ToString();
        }
    }
}
