using Microsoft.JSInterop;
using Nosthy.Blazor.DexieWrapper.Definitions;
using Nosthy.Blazor.DexieWrapper.JsModule;

namespace Nosthy.Blazor.DexieWrapper.JsInterop
{
    public class CommandExecuterJsInterop
    {
        private readonly IModule _module;

        public bool CanUseObjectReference { get; set; }

        public CommandExecuterJsInterop(IModuleFactory jsModuleFactory)
        {
            _module = jsModuleFactory.CreateModule("scripts/commandExecuter.js");
            CanUseObjectReference = _module is EsModule;
        }

        public async Task<T> InitDbAndExecute<T>(DbDefinition dbDefinition, string storeName, List<Command> commands, CancellationToken cancellationToken)
        {
            return await _module.InvokeAsync<T>("initDbAndExecute", cancellationToken, dbDefinition, storeName, commands);
        }

        public async Task<T> Execute<T>(IJSObjectReference dbJsObjectRef, string storeName, List<Command> commands, CancellationToken cancellationToken)
        {
            return await _module.InvokeAsync<T>("execute", cancellationToken, dbJsObjectRef, storeName, commands);
        }

        public async Task InitDbAndExecuteNonQuery(DbDefinition dbDefinition, string storeName, List<Command> commands, CancellationToken cancellationToken)
        {
            await _module.InvokeVoidAsync("initDbAndExecuteNonQuery", cancellationToken, dbDefinition, storeName, commands);
        }

        public async Task ExecuteNonQuery(IJSObjectReference dbJsObjectRef, string storeName, List<Command> commands, CancellationToken cancellationToken)
        {
            await _module.InvokeVoidAsync("executeNonQuery", cancellationToken, dbJsObjectRef, storeName, commands);
        }

        public async Task<IJSObjectReference> InitDb(DbDefinition dbDefinition, CancellationToken cancellationToken)
        {
            return await _module.InvokeAsync<IJSObjectReference>("initDb", cancellationToken, dbDefinition);
        }
    }
}
