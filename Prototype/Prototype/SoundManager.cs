using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Prototype
{

    public static class SoundManager
    {

        private static SoundEffect Start_Bgm;
        private static SoundEffectInstance Start_Bgm_Instance;

        private static SoundEffect Stage1_3_Bgm;
        private static SoundEffectInstance Stage1_3_Bgm_Instance;

        private static List<SoundEffect> explosions = new List<SoundEffect>();
        private static int explosionCount = 4;
        private static SoundEffect playerShot;
        private static SoundEffect enemyShot;
        private static SoundEffect enemy3Shot;



        private static Random rand = new Random();

        public static void Initialize(ContentManager content)
        {
            try
            {

                Start_Bgm = content.Load<SoundEffect>(@"Sounds\\Start");
                Start_Bgm_Instance = Start_Bgm.CreateInstance();
                Start_Bgm_Instance.IsLooped = true;

                Stage1_3_Bgm = content.Load<SoundEffect>(@"Sounds\\Stage1_3");
                Stage1_3_Bgm_Instance = Stage1_3_Bgm.CreateInstance();
                Stage1_3_Bgm_Instance.IsLooped = true;

                playerShot = content.Load<SoundEffect>(@"Sounds\\Shot1");
                enemyShot = content.Load<SoundEffect>(@"Sounds\\Shot2");

                enemy3Shot = content.Load<SoundEffect>(@"Sounds\\Explosion1");

                for (int x = 1; x <= explosionCount; x++)
                {
                    explosions.Add(content.Load<SoundEffect>(@"sounds\Explosion" + x.ToString()));
                }
            }
            catch
            {
                Debug.Write("SoundManager Initialization Failed");
            }
        }

        public static void PlayStart()
        {
            try
            {
                //Start_Bgm_Instance.Play();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }
        public static void StopStart()
        {
            try
            {
                //Start_Bgm_Instance.Stop();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }
        public static void PlayStage1_3()
        {
            try
            {
                //Stage1_3_Bgm_Instance.Play();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }
        public static void StopStage1_3()
        {
            try
            {
                //Stage1_3_Bgm_Instance.Stop();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }
        public static void PlayExplosion()
        {
            try
            {
                //explosions[rand.Next(0, explosionCount)].Play();
            }
            catch
            {
                Debug.Write("PlayExplosion Failed");
            }
        }
        public static void PlayPlayerShot()
        {
            try
            {
                //playerShot.Play();
            }
            catch
            {
                Debug.Write("PlayPlayerShot Failed");
            }
        }
        public static void PlayEnemyShot()
        {
            try
            {
                //enemyShot.Play();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }
        public static void Enemy3Shot()
        {
            try
            {
                //enemy3Shot.Play();
            }
            catch
            {
                Debug.Write("PlayEnemyShot Failed");
            }
        }
    }
    
}
