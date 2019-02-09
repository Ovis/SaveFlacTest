using CUETools.Codecs;
using CUETools.Codecs.FLAKE;
using System.IO;

namespace SaveFlacTest
{
    public class SaveFlac
    {
        static void Main(string[] args)
        {
            using (var audioSource = new WAVReader(@"D:\track01.wav", null)){
                var buff = new AudioBuffer(audioSource, 0x10000);
                using (var flakeWriter = new FlakeWriter(@"D:\track01.flac",null, audioSource.PCM) { CompressionLevel = 8 })
                    while (audioSource.Read(buff, -1) != 0)
                    {
                        flakeWriter.Write(buff);
                    }
            }
        }
    }

}
