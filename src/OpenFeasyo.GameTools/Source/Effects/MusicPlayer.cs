﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace OpenFeasyo.GameTools.Effects
{
    public class MusicPlayer
    {
        private Dictionary<string, List<Song>> playlists = new Dictionary<string, List<Song>>();
        private int currentSong = 0;
        private string currentPlaylist = "";

        public MusicPlayer()
        {

        }

        public void AddSong(string name, Song song)
        {
            playlists.Add(name, new List<Song>() { song });
        }

        public void Update()
        {
            if (MediaPlayer.State != MediaState.Playing)
            {
                Play(currentPlaylist);
            }
            else {
                if (GameTools.Mute)
                {
                    Stop();
                }
            }

        }

        public void Play(string playlist)
        {
            if (!playlists.ContainsKey(playlist)) {
                return;
            }

            if (playlist != currentPlaylist)
            {
                currentPlaylist = playlist;
                currentSong = 0;
                if (MediaPlayer.State == MediaState.Playing) {
                    MediaPlayer.Stop();
                }
            }

            if (playlists[playlist].Count == 0 || 
                GameTools.Mute ||
                MediaPlayer.State == MediaState.Playing) return;
            
            if (playlists[playlist].Count <= currentSong)
            {
                currentSong = 0;
            }

            
            MediaPlayer.IsRepeating = false;
            try
            {
                MediaPlayer.Play(playlists[playlist][currentSong]);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message + " \n" + e.StackTrace);
            }

            currentSong++;
        }

        public void Stop()
        {
            if (MediaPlayer.State != MediaState.Playing) return;
            MediaPlayer.Stop();
        }

        private Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();

        public void AddSoundEffect(string name, SoundEffect effect)
        {
            _sounds.Add(name, effect);
        }

        public void PlayEffect(string name)
        {
            if (_sounds.ContainsKey(name) && !GameTools.Mute)
            {
                _sounds[name].Play();
            }
        }

        public void Destroy() {
            _sounds.Clear();
            playlists.Clear();
        }

        public Dictionary<string, SoundEffect> Sounds { get { return _sounds; } }
    }
}
