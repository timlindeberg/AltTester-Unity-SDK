package ro.altom.altunitytester.Commands.UnityCommand;

import ro.altom.altunitytester.IMessageHandler;
import ro.altom.altunitytester.Commands.AltBaseCommand;

public class AltUnloadScene extends AltBaseCommand {
    
    private AltUnloadSceneParams params;

    public AltUnloadScene(IMessageHandler messageHandler, String sceneName) {
        super(messageHandler);
        params = new AltUnloadSceneParams(sceneName);
        params.setCommandName("unloadScene");
    }

    public void Execute() {
        SendCommand(params);
        String data = recvall(params, String.class);
        validateResponse("Ok", data);

        data = recvall(params, String.class);
        validateResponse("Scene Unloaded", data);
    }
}
