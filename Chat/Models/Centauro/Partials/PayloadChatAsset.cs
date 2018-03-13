using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models.Centauro.Partials
{
    public class PayloadChatAsset
    {
        public string ChatId { get; set; }
        public string AssetName { get; set; }
        public string FetchUrl { get; set; }
        public FetchHeaders FetchHeaders { get; set; }
    }
}
