using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public class SoundFactory
    {
        //private static List<Song> playingSongs = new List<Song>();
        private static Song currentSong;
        public SoundEffect smallJump { get; private set; }
        public SoundEffect superJump { get; private set; }
        public SoundEffect collect1UP { get; private set; }
        public SoundEffect breakBlock { get; private set; }
        public SoundEffect bump { get; private set; }
        public SoundEffect coin { get; private set; }
        public SoundEffect fireball { get; private set; }
        public SoundEffect flagpole { get; private set; }
        public SoundEffect kickShell { get; private set; }
        public SoundEffect pipe { get; private set; }
        public SoundEffect collectPowerUp { get; private set; }
        public SoundEffect powerUpAppears { get; private set; }
        public SoundEffect stomp { get; private set; }
        public SoundEffect marioDeath { get; private set; }
        public SoundEffect gameOver { get; private set; }
        public SoundEffect wonderFlowerCollect { get; private set; }
        public Song mainTheme { get; private set; }
        public Song loopTheme { get; private set; }
        public Song gustyWonderTheme { get; private set; }

        private static SoundFactory instance = new SoundFactory();

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public SoundFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            smallJump = content.Load<SoundEffect>("smb_jump-small");
            superJump = content.Load<SoundEffect>("smb_jump-super");
            collect1UP = content.Load<SoundEffect>("smb_1-up");
            breakBlock = content.Load<SoundEffect>("smb_breakblock");
            bump = content.Load<SoundEffect>("smb_bump");
            coin = content.Load<SoundEffect>("smb_coin");
            fireball = content.Load<SoundEffect>("smb_fireball");
            flagpole = content.Load<SoundEffect>("smb_flagpole");
            kickShell = content.Load<SoundEffect>("smb_kick");
            pipe = content.Load<SoundEffect>("smb_pipe");
            collectPowerUp = content.Load<SoundEffect>("smb_powerup");
            powerUpAppears = content.Load<SoundEffect>("smb_powerup_appears");
            wonderFlowerCollect = content.Load<SoundEffect>("wonder-flower-collect-soundNEW1");

            stomp = content.Load<SoundEffect>("smb_stomp");
            marioDeath = content.Load<SoundEffect>("smb_mariodie");

            mainTheme = content.Load<Song>("Ground_Theme");
            loopTheme = content.Load<Song>("Ground_ThemeLoop");
            gustyWonderTheme = content.Load<Song>("Gusty_Garden_Galaxy_8Bit");
            currentSong = loopTheme;
            MediaPlayer.Play(mainTheme);
        }

        public static void PlaySound(SoundEffect sound, float volume = 0.8f)
        {
            sound.Play(volume, 0f, 0f);
        }
        public void PlayMusic(Song song)
        {
            currentSong = song;
            MediaPlayer.Play(song);
        }
        public void PauseMusic()
        {
            MediaPlayer.Pause();
        }
        public void RestartSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Play(mainTheme);
        }
        public void Update()
        {
            if(MediaPlayer.State == MediaState.Stopped && !MediaPlayer.IsRepeating)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(currentSong);
                MediaPlayer.IsRepeating = true;
            }
        }
    }
}
