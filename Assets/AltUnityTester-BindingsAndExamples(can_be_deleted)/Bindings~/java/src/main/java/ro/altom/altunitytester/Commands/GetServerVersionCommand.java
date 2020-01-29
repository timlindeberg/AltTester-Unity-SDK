package ro.altom.altunitytester.Commands;

import ro.altom.altunitytester.AltBaseSettings;
import ro.altom.altunitytester.AltUnityDriver;


public class GetServerVersionCommand extends AltBaseCommand {
    public GetServerVersionCommand(AltBaseSettings altBaseSettings) {
        super(altBaseSettings);
    }
    public void Execute() throws Exception {
        send(CreateCommand("getServerVersion", altBaseSettings.logEnabled.toString()));
        String serverVersion = recvall();
        if (serverVersion.contains("error:")) {
            handleErrors(serverVersion);
        }
        String driverVersion= AltUnityDriver.VERSION;
        
        if(!driverVersion.equals(serverVersion))
        {
            String message="Mismatch version. You are using different version of server and driver. Server version: " + serverVersion + " and Driver version: " + driverVersion;
            super.WriteInLogFile(message);
            throw new Exception(message);
        }
    }
}

