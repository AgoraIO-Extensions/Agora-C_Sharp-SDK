using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public class MusicCollection
    {
        ///
        /// @ignore
        ///
        public int count;
        ///
        /// @ignore
        ///
        public int total;
        ///
        /// @ignore
        ///
        public int page;
        ///
        /// @ignore
        ///
        public int pageSize;
        ///
        /// @ignore
        ///
        public Music[] music;
    }

    ///
    /// @ignore
    ///
    public class IWord
    {
        ///
        /// @ignore
        ///
        public int begin;

        ///
        /// @ignore
        ///
        public int duration;

        ///
        /// @ignore
        ///
        public double refPitch;

        ///
        /// @ignore
        ///
        public string word;

        ///
        /// @ignore
        ///
        public int score;
    }

    ///
    /// @ignore
    ///
    public class ISentence
    {
        ///
        /// @ignore
        ///
        public string content;

        ///
        /// @ignore
        ///
        public int begin;

        ///
        /// @ignore
        ///
        public int duration;

        ///
        /// @ignore
        ///
        public IWord[] word;

        ///
        /// @ignore
        ///
        public int wordCount;

        ///
        /// @ignore
        ///
        public int score;
    }

    ///
    /// @ignore
    ///
    public class ILyricInfo
    {
        ///
        /// @ignore
        ///
        public string name;

        ///
        /// @ignore
        ///
        public string singer;

        ///
        /// @ignore
        ///
        public int preludeEndPosition;

        ///
        /// @ignore
        ///
        public int duration;

        ///
        /// @ignore
        ///
        public bool hasPitch;

        ///
        /// @ignore
        ///
        public LyricSourceType sourceType;

        ///
        /// @ignore
        ///
        public ISentence[] sentence;

        ///
        /// @ignore
        ///
        public int sentenceCount;
    }

}