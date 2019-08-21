package dir_size.executor_service;


import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

// TODO: https://github.com/javacreed/java-fork-join-example
// TODO: explain - why this does not work? What is happening here?

class DirSize {
    private DirSize() {}

    private static class SizeOfFileCallable implements Callable<Long> {

        private final File file;
        private final ExecutorService executor;

        SizeOfFileCallable(final File file, final ExecutorService executor) {
            this.file = Objects.requireNonNull(file);
            this.executor = Objects.requireNonNull(executor);
        }

        @Override
        public Long call() throws Exception {
            System.out.println("Computing size of file: " + file);
            long size = 0;
            if (file.isFile()) {
                size = file.length();
            } else {
                final List<Future<Long>> futures = new ArrayList<>();
                File[] files = file.listFiles();
                if (files != null)
                    for (final File child : files) {
                        futures.add(executor.submit(new SizeOfFileCallable(child, executor)));
                    }

                for (final Future<Long> future : futures) {
                    size += future.get();
                }
            }

            return size;
        }
    }

    static long sizeOf(final File file) {
        final int availableProcessors = Runtime.getRuntime().availableProcessors();
        System.out.println("availableProcessors = " + availableProcessors);
        final ExecutorService executor = Executors.newFixedThreadPool(availableProcessors);
        try {
            return executor.submit(new SizeOfFileCallable(file, executor)).get();
        } catch (final Exception e) {
            throw new RuntimeException("Failed to calculate the dir size", e);
        } finally {
            executor.shutdown();
        }
    }
}

class TestAverage {
    private static final File TEST_DIR = new File("C:\\hse\\students");

    public static void main(String[] args) {
        long total = 0;
        for (int i = 0; i < 8; i++) {
            long start = System.nanoTime();
            long size = DirSize.sizeOf(TEST_DIR);
            long taken = System.nanoTime() - start;
            total += taken;
            System.out.println("size = " + size + "; time = " + taken);
        }
        System.out.println("total average = " + total / 8); // ???
    }
}