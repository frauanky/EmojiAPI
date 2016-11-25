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
                new Emoji() { theEmoji = "😆" } ,
                new Emoji() { theEmoji = "😀" } ,
                new Emoji() { theEmoji = "😀" } ,
                new Emoji() { theEmoji = "😀" } ,
                new Emoji() { theEmoji = "😀" } ,
                new Emoji() { theEmoji = "😀" }
            };
        }
    }
}
