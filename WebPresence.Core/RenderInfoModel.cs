
namespace WebPresence.Core
{
    public class RenderInfoModel<M> : RenderInfo
    {
        public RenderInfoModel()
        {
        }
        public RenderInfoModel(string prefix, string partialPrefix, string partialRendering, M model)
        {
            Prefix = prefix;
            PartialPrefix = partialPrefix;
            PartialRendering = partialRendering;
            Model = model;
        }

        public M Model { get; set; }
    }
}
