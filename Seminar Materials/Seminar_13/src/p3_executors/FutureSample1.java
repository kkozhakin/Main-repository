package p3_executors;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

public class FutureSample1 {

    static <T> Object getResult(Future<T> future, Object resultBeforeGet){
        Object result = resultBeforeGet;
        do{
            try{
                result = future.get(); // waits for completion...
//                result = future.get(1, TimeUnit.MILLISECONDS); // waits until timeout exception or completion...
                System.out.println("result = " + result);
            } catch (Exception ex){
                System.out.println("got exception: " + ex + "; result = " + result);
            }
        }
        while (!future.isDone());
        return result;
    }

    public static void main(String[] args) {

        ExecutorService executorService = Executors.newSingleThreadExecutor();
        Future<?> future = executorService.submit(() -> {
            System.out.println("I am runnable working in thread: " + Thread.currentThread());
            try {
                Thread.sleep(50);
            } catch (InterruptedException ie){
                //
            }
        });
        System.out.println("future = " + future);

        Object result = getResult(future, "Done");
        System.out.println("upon completion: result = " + result);

        //TODO: note that the application is alive since the thread pool exists...We need shutdown it..
        executorService.shutdown();
    }
}
