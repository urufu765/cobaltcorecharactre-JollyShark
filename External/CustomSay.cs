namespace JollyJolly;

internal sealed class CustomSay : Say
{
    private static int NextId = 1;
    private readonly int Id;
    public string? what;
    public CustomSay()
    {
        this.Id = NextId++;
    }

    public override bool Execute(G g, IScriptTarget target, ScriptCtx ctx)
    {
        if (string.IsNullOrEmpty(what)) return base.Execute(g, target, ctx);

        hash = $"{GetType().FullName}:{Id}";
        DB.currentLocale.strings[GetLocKey(ctx.script, hash)] = what;
        return base.Execute(g, target, ctx);
    }
}