package p3_executors;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class FutureSample2 extends FutureSample1{
    public static void main(String[] args) {

        ExecutorService executorService = Executors.newFixedThreadPool(2);
        Future<String> future = executorService.submit(() -> {
            System.out.println("I am runnable working in thread: " + Thread.currentThread());
            try {
                Thread.sleep(50);
            } catch (InterruptedException ie){
                //
            }
        }, "Done!");

        System.out.println("future = " + future);

        Object result = getResult(future, "???");

        System.out.println("upon completion: result = " + result);

        //TODO: note that the application is alive since the thread pool exists...We need shutdown it..
        executorService.shutdown();
    }
}
