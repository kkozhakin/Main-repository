package p3_spurious_wakeup;

/*
    TODO: consider / discuss the following task:
    1. Have threads that try to access some shared data in synchronized manner.
    2. Have a thread that uses a lock to deal with data while other threads are waiting for it
       (e.g. there are 2 of them waiting, as in point 1 above).
    3. Have a thread that inputs some commands:
    - command notify - allows one waiting thread to wakeup and get a lock;
    - command interrupt - allows another thread to wakeup and - having no guarding loop - get access to shared data
      thus violating mutual exclusion requirements.
    - the goal is to demonstrate that having notify() is not enough for a proper behavior when controlling threads;
      and guarding loops are needed to deal with spurious wake-ups.
    4. TODO: note that legal wakeup is done by notify(), while spurious wakeup is done by interrupt().
    5. TODO: propose - how to organize that demo scenario in user controlled manner(e.g. interactively)?
 */
public class SpuriousWakeup {

}


