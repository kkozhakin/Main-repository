package dir_size.recursive_action;

// TODO: note that we should not create contentions... (it makes bad results...)
// TODO: https://github.com/javacreed/java-fork-join-example

import java.io.File;
import java.util.Objects;
import java.util.concurrent.ForkJoinPool;
import java.util.concurrent.ForkJoinTask;
import java.util.concurrent.RecursiveAction;
import java.util.concurrent.atomic.AtomicLong;

public class DirSize {

    private DirSize() {}

    public static long sizeOf(final File file) {
        final ForkJoinPool pool = new ForkJoinPool();
        try {
            final AtomicLong sizeAccumulator = new AtomicLong();
            pool.invoke(new SizeOfFileAction(file, sizeAccumulator));
            return sizeAccumulator.get();
        } finally {
            pool.shutdown();
        }
    }

    private static class SizeOfFileAction extends RecursiveAction {

        private final File file;
        private final AtomicLong sizeAccumulator;

        public SizeOfFileAction(final File file, final AtomicLong sizeAccumulator) {
            this.file = Objects.requireNonNull(file);
            this.sizeAccumulator = Objects.requireNonNull(sizeAccumulator);
        }

        @Override
        protected void compute() {
            if (file.isFile()) {
                sizeAccumulator.addAndGet(file.length());
            } else {
                final File[] children = file.listFiles();
                if (children != null) {
                    for (final File child : children) {
                        ForkJoinTask.invokeAll(new SizeOfFileAction(child, sizeAccumulator));
                    }
                }
            }
        }
    }
}

class TestAverage {
    public static final File TEST_DIR = new File("C:\\hse\\students");

    public static void main(String[] args) {
        long total = 0;
        for (int i = 0; i < 8; i++) {
            long start = System.nanoTime();
            long size = DirSize.sizeOf(TEST_DIR);
            long taken = System.nanoTime() - start;
            total += taken;
            System.out.println("size = " + size + "; time = " + taken);
        }
        System.out.println("total average = " + total / 8); // about 1.5 sec... //TODO: explained by the AtomicLong usage...
    }
}