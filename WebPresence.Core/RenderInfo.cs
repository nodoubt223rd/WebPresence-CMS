
namespace WebPresence.Core
{
    public class RenderInfo
    {
        string _PartialRendering = null;

        internal string PartialRendering
        {
            get
            {
                if (_PartialRendering == null) return null;
                string temp = _PartialRendering;
                _PartialRendering = string.Empty;
                return temp;
            }
            set
            {
                _PartialRendering = value;
            }
        }
        public string Prefix { get; set; }
        public string PartialPrefix { get; set; }
        public string GetPartialrendering() { return PartialRendering; }
    }    
}
