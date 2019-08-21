package p2_sender_receiver;

import java.util.concurrent.ThreadLocalRandom;

public class Receiver implements Runnable{

    private Data data;

    Receiver(Data data){
        this.data = data;
    }

    public void run() {
        for(String receivedMessage = data.receive(); !"End".equals(receivedMessage); receivedMessage = data.receive()){
            System.out.println(receivedMessage);
            // ...
            try {
                Thread.sleep(ThreadLocalRandom.current().nextInt(1000, 5000));
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
                System.out.println("Thread interrupted: " + e);
            }
        }
    }
}
