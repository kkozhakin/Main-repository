package dir_size.recursive_task;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.concurrent.ForkJoinPool;
import java.util.concurrent.RecursiveTask;

// TODO: https://github.com/javacreed/java-fork-join-example

public class DirSize {

    private DirSize() {}

    public static long sizeOf(final File file) {
        final ForkJoinPool pool = new ForkJoinPool();
        try {
            return pool.invoke(new SizeOfFileTask(file));
        } finally {
            pool.shutdown();
        }
    }

    private static class SizeOfFileTask extends RecursiveTask<Long> {
        private final File file;

        public SizeOfFileTask(final File file) {
            this.file = Objects.requireNonNull(file);
        }

        @Override
        protected Long compute() {
            if (file.isFile()) {
                return file.length();
            }
            final List<SizeOfFileTask> tasks = new ArrayList<>();
            final File[] children = file.listFiles();
            if (children != null) {
                for (final File child : children) {
                    final SizeOfFileTask task = new SizeOfFileTask(child);
                    task.fork();
                    tasks.add(task);
                }
            }
            long size = 0;
            for (final SizeOfFileTask task : tasks) {
                size += task.join();
            }
            return size;
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
        System.out.println("total average = " + total / 8); // about 0.8 sec...
    }
}