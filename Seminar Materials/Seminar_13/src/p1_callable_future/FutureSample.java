package p1_callable_future;

import java.util.concurrent.Callable;
import java.util.concurrent.FutureTask;

public class FutureSample {

    public static void main(String[] args) {

        Callable<String> myComputation = () -> {
            System.out.println("I am callable working in thread: " + Thread.currentThread());
            try {
                Thread.sleep(3000);
            } catch (InterruptedException ie){
                //
            }
            return "Callable.Done!";
        };

        FutureTask<String> task = new FutureTask<>(myComputation);
        Thread thread = new Thread(task); //todo: note - task is Runnable...
        thread.start();

        String result = null;
        try {
            result = task.get(); //todo: note - task is Future as well...
        } catch (Exception ex) {
            System.out.println("got exception: " + ex);
        }

        System.out.println("result = " + result);
    }
}
