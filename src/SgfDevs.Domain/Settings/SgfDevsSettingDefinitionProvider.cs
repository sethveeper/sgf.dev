using Volo.Abp.Settings;

namespace SgfDevs.Settings
{
    public class SgfDevsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(SgfDevsSettings.MySetting1));
        }
    }
}
