package read_write_lock_1;

public class Writer extends Thread{
    private boolean isRunning = true;
    private Dictionary dictionary = null;

    public Writer(Dictionary d, String threadName) {
        this.dictionary = d;
        this.setName(threadName);
    }
    @Override
    public void run() {
        while (this.isRunning) {
            System.out.println(Thread.currentThread());
            String [] keys = dictionary.getKeys();
            for (String key : keys) {
                String newValue = getNewValueFromDatastore(key);
                //updating dictionary with WRITE LOCK
                dictionary.set(key, newValue);
            }

            //update every seconds
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
    public void stopWriter(){
        this.isRunning = false;
        this.interrupt();
    }
    public String getNewValueFromDatastore(String key){
        //This part is not implemented...
        return "newValue";
    }
}
