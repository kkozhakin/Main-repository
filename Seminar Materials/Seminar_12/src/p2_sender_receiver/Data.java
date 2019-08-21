package p2_sender_receiver;

/*
The Sender is supposed to send a data packet to the Receiver
The Receiver cannot process the data packet until the Sender is finished sending it
Similarly, the Sender mustn’t attempt to send another packet unless the Receiver has already processed the previous packet

Why Enclose wait() in a while Loop?
Since notify() and notifyAll() randomly wakes up threads that are waiting on this object’s monitor,
it’s not always important that the condition is met. Sometimes it can happen that the thread is woken up,
but the condition isn’t actually satisfied yet.
We can also define a check to save us from spurious wake-ups – where a thread can wake up from waiting
without ever having received a notification. (spurious wakeup - ложное пробуждение)
 */
public class Data {

    private String packet;

    // True if receiver should wait
    // False if sender should wait
    private boolean transfer = true; //i.e. receiver should wait first...

    public synchronized void send(String packet) {
        while (!transfer) {
            try {
                wait();
            } catch (InterruptedException e)  {
                Thread.currentThread().interrupt();
                System.out.println("Thread interrupted: " + e);
            }
        }
        transfer = false;
        this.packet = packet;
        notifyAll();
    }

    public synchronized String receive() {
        while (transfer) {
            try {
                wait();
            } catch (InterruptedException e)  {
                Thread.currentThread().interrupt();
                System.out.println("Thread interrupted: " + e);
            }
        }
        transfer = true;
        notifyAll();
        return packet;
    }

    public static void main(String[] args) {
        Data data = new Data();
        Thread sender = new Thread(new Sender(data));
        Thread receiver = new Thread(new Receiver(data));

        sender.start();
        receiver.start();
    }
}
