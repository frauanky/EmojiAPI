using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmojiAPI.Models
{
    public class EmojiLib
    {
        public Emoji[] Emojis { get; set; }

        public EmojiLib()
        {
            Emojis = new Emoji[] {
                new Emoji() { theEmoji = "😤" } ,
                new Emoji() { theEmoji = "😠" } ,
                new Emoji() { theEmoji = "😐" } ,
                new Emoji() { theEmoji = "😃" } ,
                new Emoji() { theEmoji = "😄" }
            };
        }

        public Emoji getEmojiForSentiment(double sentiment)
        {
            if (sentiment <= 0.2) return Emojis[0];
            if (sentiment <= 0.4 && sentiment > 0.2) return Emojis[1];
            if (sentiment <= 0.7 && sentiment > 0.4) return Emojis[2];
            if (sentiment <= 0.9 && sentiment > 0.7) return Emojis[3];
            if (sentiment <= 1.0 && sentiment > 0.9) return Emojis[4];
            return null;
        }
    }
}
