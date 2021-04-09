using System.Collections.Generic;

namespace CosmeticRings.Framework.Interfaces
{
    public interface IJsonAssetsApi
    {
        void LoadAssets(string path);

        int GetObjectId(string name);
        List<string> GetAllObjectsFromContentPack(string cp);
    }
}
