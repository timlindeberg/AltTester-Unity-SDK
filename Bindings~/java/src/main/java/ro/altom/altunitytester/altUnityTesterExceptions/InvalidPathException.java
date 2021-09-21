package ro.altom.altunitytester.altUnityTesterExceptions;

public class InvalidPathException extends AltUnityException {
    /**
     *
     */
    private static final long serialVersionUID = 3158967400312394991L;

    public InvalidPathException() {
    }

    public InvalidPathException(String message) {
        super(message);
    }

    public InvalidPathException(Throwable exception) {
        super(exception);
    }

    public InvalidPathException(String message, Throwable exception) {
        super(message, exception);
    }
}
